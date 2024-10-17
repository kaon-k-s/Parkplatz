using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkplatz
{
    public class Datenbank
    {
        // Deklaration der MySQL-Verbindung
        private MySqlConnection con;

        // Konstruktor der Klasse Datenbank, der die Verbindungsinformationen initialisiert
        public Datenbank()
        {
            string conStr = "SERVER=localhost;DATABASE=parkplatz; UID=root;PASSWORD=''";
            con = new MySqlConnection(conStr);
        }

        // Methode zum Öffnen der Verbindung zur Datenbank
        private void oeffnen()
        {
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verbindung konnte nicht geöffnet werden: " + ex.Message);
            }
        }

        // Methode zum Schließen der Verbindung zur Datenbank
        private void schliessen()
        {
            if (con != null)
            {
                try
                {
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Verbindung konnte nicht geschlossen werden: " + ex.Message);
                }
            }
        }

        public void neuEinfahrt(Parkvorgaenge park)
        {
            try
            {
                oeffnen();
                MySqlCommand cmd = con.CreateCommand();
                // Prepare the SQL query using parameter placeholders
                cmd.CommandText = "INSERT INTO parkvorgaenge (`id`, `kennzeichen`, `einfahrtszeit`, `status`) " +
                                  "VALUES (NULL, @kennzeichen, @einfahrtszeit, @status)";

                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@kennzeichen", park.Kennzeichen);
                cmd.Parameters.AddWithValue("@einfahrtszeit", park.Einfahrtszeit.ToString("yyyy-MM-dd HH:mm:ss")); // Use 24-hour format
                cmd.Parameters.AddWithValue("@status", "Eingefahren");
                cmd.ExecuteNonQuery();
                schliessen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Speichern des Einfahrtszeit fehlgeschlagen: {ex.Message}", "Failed to save vehicle entry time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public Parkvorgaenge suchenAuto(string kennzchEingabe)
        {
            Parkvorgaenge suchPark = null; // Initialize to null in case the vehicle is not found
            try
            {
                oeffnen();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM parkvorgaenge WHERE kennzeichen=@kennzeichen AND status='Eingefahren' LIMIT 1";
                cmd.Parameters.AddWithValue("@kennzeichen", kennzchEingabe); // Use parameterized query to prevent SQL injection

                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) // If there is a result
                {
                    suchPark = new Parkvorgaenge(
                        dr.GetInt32("id"),
                        dr.GetString("kennzeichen"),
                        dr.GetDateTime("einfahrtszeit"),
                        dr.IsDBNull(dr.GetOrdinal("ausfahrtszeit")) ? (DateTime?)null : dr.GetDateTime("ausfahrtszeit"), // Handle NULL ausfahrtszeit
                        dr.IsDBNull(dr.GetOrdinal("gebuehr")) ? 0 : dr.GetDecimal("gebuehr"), // Handle NULL gebuehr
                        dr.IsDBNull(dr.GetOrdinal("bezahlt")) ? 0 : dr.GetDecimal("bezahlt"), // Handle NULL bezahlt
                        dr.GetString("status")
                    );
                }
                dr.Close();
                schliessen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Suchen nach Fahrzeug fehlgeschlagen: {ex.Message}", "Failed to find vehicle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return suchPark;
        }

        public void updateGebuehr(int id, decimal gebuehr)
        {
            try
            {
                oeffnen();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE parkvorgaenge SET gebuehr=@gebuehr WHERE id=@id AND status='Eingefahren'";
                cmd.Parameters.AddWithValue("@gebuehr", gebuehr);
                cmd.Parameters.AddWithValue("@id", id);
                
                cmd.ExecuteNonQuery();
                schliessen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern der Bezahlung: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool speichernBezahlung(int id, decimal bezahlt, DateTime ausfahrtszeit)
        {
            try
            {
                oeffnen();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE parkvorgaenge SET bezahlt=@bezahlt, ausfahrtszeit=@ausfahrtszeit WHERE id=@id AND status='Eingefahren'";
                cmd.Parameters.AddWithValue("@bezahlt", bezahlt);
                cmd.Parameters.AddWithValue("@ausfahrtszeit", ausfahrtszeit.ToString("yyyy-MM-dd HH:mm:ss")); // Format the exit time
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery(); // Execute the query and get the number of affected rows
                schliessen();

                // If at least one row was affected, return true (success)
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern der Bezahlung: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Return false if an exception occurs
            }
        }

        // Method to update the exit time and status when a car exits
        public void updateAusfahrt(int id, DateTime ausfahrtszeit)
        {
            try
            {
                oeffnen();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE parkvorgaenge SET ausfahrtszeit=@ausfahrtszeit, status='Ausgefahren' WHERE id=@id AND status='Eingefahren'";
                cmd.Parameters.AddWithValue("@ausfahrtszeit", ausfahrtszeit.ToString("yyyy-MM-dd HH:mm:ss")); // Format the exit time
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery(); // Execute the update query
                schliessen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern der Ausfahrtszeit: {ex.Message}",
                                "Fehler",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public List<string> getKorrektBezahlt()
        {
            List<string> korrektList = new List<string>();
            try
            {
                oeffnen();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT kennzeichen, TIMESTAMPDIFF(HOUR, einfahrtszeit, ausfahrtszeit) AS parkdauer, bezahlt, gebuehr " +
                                  "FROM parkvorgaenge " +
                                  "WHERE status = 'Ausgefahren' AND bezahlt >= gebuehr";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string kennzeichen = dr.GetString("kennzeichen");
                    int parkdauer = dr.GetInt32("parkdauer");
                    korrektList.Add($"{kennzeichen} (Parkdauer: {parkdauer} Stunden)");
                }
                dr.Close();
                schliessen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Abrufen der korrekt bezahlten Fahrzeuge: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return korrektList;
        }

        public List<string> getNichtBezahltOderZuWenig()
        {
            List<string> wenigKeineList = new List<string>();
            try
            {
                oeffnen();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT kennzeichen, bezahlt, gebuehr " +
                                  "FROM parkvorgaenge " +
                                  "WHERE status = 'Ausgefahren' AND (bezahlt = 0 OR bezahlt < gebuehr)";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string kennzeichen = dr.GetString("kennzeichen");
                    decimal bezahlt = dr.IsDBNull(dr.GetOrdinal("bezahlt")) ? 0 : dr.GetDecimal("bezahlt");
                    decimal gebuehr = dr.GetDecimal("gebuehr");
                    wenigKeineList.Add($"{kennzeichen} (Bezahlt: {bezahlt}€, Gebühr: {gebuehr}€)");
                }
                dr.Close();
                schliessen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Abrufen der Fahrzeuge ohne Zahlung oder zu wenig: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return wenigKeineList;
        }

        public List<string> getNichtAusgefahren()
        {
            List<string> nichtAusgefahrenList = new List<string>();
            try
            {
                oeffnen();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT kennzeichen FROM parkvorgaenge WHERE status = 'Eingefahren'";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string kennzeichen = dr.GetString("kennzeichen");
                    nichtAusgefahrenList.Add(kennzeichen);
                }
                dr.Close();
                schliessen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Abrufen der nicht ausgefahrenen Fahrzeuge: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nichtAusgefahrenList;
        }


    }
}