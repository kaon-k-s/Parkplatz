using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tesseract;

namespace Parkplatz
{
    public partial class Form1 : Form
    {
        private Datenbank db = new Datenbank();
        private DateTime currentDate;
        private decimal summe;
        Parkvorgaenge park = null;
        public Form1()
        {
            InitializeComponent();

            // Enable AllowDrop for panels
            panEinfahrt.AllowDrop = true;
            panAusfahrt.AllowDrop = true;

            // Add DragEnter and DragDrop event handlers
            panEinfahrt.DragEnter += pan_DragEnter;
            panEinfahrt.DragDrop += panEinfahrt_DragDrop;

            panAusfahrt.DragEnter += pan_DragEnter;
            panAusfahrt.DragDrop += panAusfahrt_DragDrop;

            tbKreditkarte.TextChanged += TbKreditkarte_TextChanged;
        }

        // Handle the DragEnter event for both panels
        private void pan_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data being dragged is a file (image)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // Handle DragDrop event for panEinfahrt (Vehicle Entry)
        private void panEinfahrt_DragDrop(object sender, DragEventArgs e)
        {
            // Get the dropped file (image)
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];
                string kennzeichen = ExtractTextFromImage(filePath); // Use OCR to extract text
                MessageBox.Show($"Fahrzeug mit Kennzeichen {kennzeichen} eingefahren um {DateTime.Now}.");

                // Use Regex to replace any non-alphanumeric characters with an empty string
                string cleanedKennzeichen = Regex.Replace(kennzeichen, "[^a-zA-Z0-9]", "");

                try
                {
                    currentDate = DateTime.Now;
                    Parkvorgaenge park = new Parkvorgaenge(0, cleanedKennzeichen, currentDate, null, 0, 0, "Eingefahren");

                    db.neuEinfahrt(park);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Speichern des Einfahrtszeit fehlgeschlagen: {ex.Message}", "Failed to vehicle entry time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Handle DragDrop event for panAusfahrt (Vehicle Exit)
        private void panAusfahrt_DragDrop(object sender, DragEventArgs e)
        {
            // Get the dropped file (image)
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];
                string kennzeichen = ExtractTextFromImage(filePath); // Use OCR to extract text

                // Clean the extracted license plate using Regex to remove non-alphanumeric characters
                string cleanedKennzeichen = Regex.Replace(kennzeichen, "[^a-zA-Z0-9]", "");

                try
                {
                    // Look for the vehicle with the status 'Eingefahren'
                    Parkvorgaenge park = db.suchenAuto(cleanedKennzeichen);

                    if (park != null)
                    {
                        DateTime currentTime = DateTime.Now;
                        if (park.Gebuehr == 0) // Check if no fee has been calculated (NULL or 0)
                        {
                            // Automatically calculate the payment (similar to btnKennzchEingabe_Click)
                            DateTime einfahrtszeit = park.Einfahrtszeit;

                            // Calculate the parking duration (rounded up to the nearest hour)
                            TimeSpan parkdauer = currentTime - einfahrtszeit;
                            int totalHours = (int)Math.Ceiling(parkdauer.TotalHours); // Round up to nearest hour

                            // Calculate the parking fee (2€ per hour)
                            summe = totalHours * 2;
                            decimal keineBezahlung = 0;

                            // Update the fee in the database
                            db.updateGebuehr(park.Id, summe);
                            db.speichernBezahlung(park.Id, keineBezahlung, currentTime);

                            // Notify the user to pay on the website to find the specific parking event that wasn't paid
                            MessageBox.Show($"Fahrzeug mit Kennzeichen {cleanedKennzeichen} hat {totalHours} Stunden geparkt. " +
                                            $"Die Gebühr beträgt {summe} €. Bitte zahlen Sie auf unsere Website parkplatz.com",
                                            "Zahlung erforderlich",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                            //// Option: prevent exit from the parking without paying and notify the user to pay right away
                            //MessageBox.Show($"Fahrzeug mit Kennzeichen {cleanedKennzeichen} hat {totalHours} Stunden geparkt. " +
                            //                $"Die Gebühr beträgt {summe} €. Bitte zahlen Sie, bevor Sie ausfahren.",
                            //                "Zahlung erforderlich",
                            //                MessageBoxButtons.OK,
                            //                MessageBoxIcon.Information);

                            //return; // Exit the method so they can't exit before paying
                        }

                        // The vehicle has 15 minutes time to leave the parking after payment to avoid additional charging.
                        // If the vehicle leaved less than in 15 minutes then the Ausfahrtszeit stays the same as payment time.
                        // If more than 15 minutes, then Ausfahrtszeit is set to the current time and additional charge can be applied.
                        TimeSpan timegap = (TimeSpan)(currentTime - park.Ausfahrtszeit);
                        int gapMinutes = (int)Math.Floor(timegap.TotalMinutes); // Round up to nearest minute

                        DateTime ausfahrtszeit;
                        if (gapMinutes > 15)
                        {
                            ausfahrtszeit = DateTime.Now; // Set the current time as the exit time
                        }
                        else
                        {
                            ausfahrtszeit = (DateTime)park.Ausfahrtszeit; //Leave the payment time as the exit time
                        }
                        
                        db.updateAusfahrt(park.Id, ausfahrtszeit);

                        MessageBox.Show($"Fahrzeug mit Kennzeichen {cleanedKennzeichen} ausgefahren um {ausfahrtszeit}.",
                                        "Ausfahrt Erfolgreich",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Fahrzeug mit Kennzeichen {cleanedKennzeichen} wurde nicht gefunden.",
                                        "Fahrzeug nicht gefunden",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Verarbeiten der Ausfahrt: {ex.Message}",
                                    "Fehler",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }


        // Function to extract text from an image using Tesseract OCR
        private string ExtractTextFromImage(string imagePath)
        {
            try
            {
                // Initialize Tesseract OCR engine
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    // Load the image
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        // Perform OCR on the image
                        using (var page = engine.Process(img))
                        {
                            string text = page.GetText().Trim();
                            return text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Lesen des Bildes: " + ex.Message);
                return string.Empty;
            }
        }

        private void btnKennzchEingabe_Click(object sender, EventArgs e)
        {
            try
            {
                string kennzchEingabe = tbKennzchEingabe.Text;
                park = db.suchenAuto(kennzchEingabe); // Find the car entry

                if (park != null)
                {
                    DateTime einfahrtszeit = park.Einfahrtszeit;
                    DateTime currentTime = DateTime.Now;

                    // Calculate the parking duration (rounded up to the nearest hour)
                    TimeSpan parkdauer = currentTime - einfahrtszeit;
                    int totalHours = (int)Math.Ceiling(parkdauer.TotalHours); // Round up to nearest hour

                    // Calculate the parking fee (2€ per hour)
                    summe = totalHours * 2;

                    // Update the UI
                    lblParkdauer.Text = "Parkdauer: " + totalHours + " h";
                    lblSumme.Text = "Summe: " + summe + " €";

                    // Save the calculated summe (fee) in the database using the car's Id
                    db.updateGebuehr(park.Id, summe); // Use the Id to update the payment
                }
                else
                {
                    MessageBox.Show("Fahrzeug wurde nicht gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Berechnen oder Speichern der Bezahlung: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TbKreditkarte_TextChanged(object sender, EventArgs e)
        {
            // Remove all non-digit characters and spaces from the input
            string input = Regex.Replace(tbKreditkarte.Text, @"[^\d]", "");

            // Format the cleaned input with spaces every four digits
            StringBuilder formattedInput = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                // Add a space after every 4 digits
                if (i > 0 && i % 4 == 0)
                {
                    formattedInput.Append(" ");
                }
                formattedInput.Append(input[i]);
            }

            // Update the TextBox with the formatted input
            tbKreditkarte.Text = formattedInput.ToString();
            // Move the caret to the end of the input
            tbKreditkarte.SelectionStart = tbKreditkarte.Text.Length;
        }

        private void btnBezahlen_Click(object sender, EventArgs e)
        {
            // Remove spaces to validate only digits
            string cleanedInput = tbKreditkarte.Text.Replace(" ", "");

            // Check if the cleaned input has exactly 16 digits
            if (cleanedInput.Length != 16 || !Regex.IsMatch(cleanedInput, @"^\d{16}$"))
            {
                MessageBox.Show("Bitte geben Sie eine gültige Kreditkartennummer mit genau 16 Ziffern ein.", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if the validation fails
            }

            // The current time is set as Ausfahrtszeit. This value will be compared to the real Ausfahrtszeit.
            // If difference between real Ausfahrtszeit and "payment" Ausfahrtszeit more than 15 minutes then Ausfahrtszeit
            // is set to the current time and additional charge can be applied.
            // If less than 15 minutes - then the Ausfahrtszeit stays the same as payment time.
            DateTime currentTime = DateTime.Now;
            bool paymentSaved = db.speichernBezahlung(park.Id, summe, currentTime); // Check if the operation was successful

            if (paymentSaved)
            {
                MessageBox.Show("Zahlung verarbeitet für Kreditkartennummer: " + cleanedInput, "Zahlung Erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Zahlung konnte nicht verarbeitet werden. Bitte versuchen Sie es erneut.", "Zahlung Fehlgeschlagen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBericht_Click(object sender, EventArgs e)
        {
            // Pass the existing database connection to the Bericht form
            Bericht berichtForm = new Bericht(db);
            berichtForm.ShowDialog(); // Show the Bericht form as a dialog
        }
    }
}
