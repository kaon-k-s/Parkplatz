namespace Parkplatz
{
    partial class Bericht
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bericht));
            libKorrekt = new ListBox();
            libWenigKeine = new ListBox();
            libNichtAusgefahren = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // libKorrekt
            // 
            libKorrekt.FormattingEnabled = true;
            libKorrekt.Location = new Point(43, 83);
            libKorrekt.Name = "libKorrekt";
            libKorrekt.Size = new Size(285, 344);
            libKorrekt.TabIndex = 0;
            // 
            // libWenigKeine
            // 
            libWenigKeine.FormattingEnabled = true;
            libWenigKeine.Location = new Point(385, 83);
            libWenigKeine.Name = "libWenigKeine";
            libWenigKeine.Size = new Size(285, 344);
            libWenigKeine.TabIndex = 1;
            // 
            // libNichtAusgefahren
            // 
            libNichtAusgefahren.FormattingEnabled = true;
            libNichtAusgefahren.Location = new Point(717, 83);
            libNichtAusgefahren.Name = "libNichtAusgefahren";
            libNichtAusgefahren.Size = new Size(200, 344);
            libNichtAusgefahren.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(43, 40);
            label1.MinimumSize = new Size(285, 0);
            label1.Name = "label1";
            label1.Size = new Size(285, 23);
            label1.TabIndex = 3;
            label1.Text = "Korrekt Bezahlt";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(385, 40);
            label2.MinimumSize = new Size(285, 0);
            label2.Name = "label2";
            label2.Size = new Size(285, 23);
            label2.TabIndex = 4;
            label2.Text = "Zu wenig/keine Zahlung";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(717, 40);
            label3.MinimumSize = new Size(200, 0);
            label3.Name = "label3";
            label3.Size = new Size(200, 23);
            label3.TabIndex = 5;
            label3.Text = "Noch nicht ausgefahren";
            // 
            // Bericht
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 0, 64);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(949, 485);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(libNichtAusgefahren);
            Controls.Add(libWenigKeine);
            Controls.Add(libKorrekt);
            DoubleBuffered = true;
            Name = "Bericht";
            Text = "Bericht";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox libKorrekt;
        private ListBox libWenigKeine;
        private ListBox libNichtAusgefahren;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}