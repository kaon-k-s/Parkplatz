namespace Parkplatz
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnBezahlen = new Button();
            panEinfahrt = new Panel();
            label2 = new Label();
            panAusfahrt = new Panel();
            lblEinfahrt = new Label();
            lblAusfahrt = new Label();
            btnBericht = new Button();
            label1 = new Label();
            label3 = new Label();
            lblSumme = new Label();
            lblParkdauer = new Label();
            tbKennzchEingabe = new TextBox();
            label8 = new Label();
            tbKreditkarte = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            btnKennzchEingabe = new Button();
            SuspendLayout();
            // 
            // btnBezahlen
            // 
            btnBezahlen.BackColor = Color.DarkViolet;
            btnBezahlen.BackgroundImageLayout = ImageLayout.Stretch;
            btnBezahlen.FlatAppearance.BorderColor = Color.Indigo;
            btnBezahlen.FlatAppearance.MouseOverBackColor = Color.MediumOrchid;
            btnBezahlen.FlatStyle = FlatStyle.Flat;
            btnBezahlen.Font = new Font("Segoe UI Variable Small Semibol", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBezahlen.ForeColor = SystemColors.ButtonHighlight;
            btnBezahlen.Location = new Point(431, 444);
            btnBezahlen.Name = "btnBezahlen";
            btnBezahlen.Size = new Size(230, 55);
            btnBezahlen.TabIndex = 0;
            btnBezahlen.Text = "Bezahlen";
            btnBezahlen.UseVisualStyleBackColor = false;
            btnBezahlen.Click += btnBezahlen_Click;
            // 
            // panEinfahrt
            // 
            panEinfahrt.AllowDrop = true;
            panEinfahrt.BackColor = Color.DarkMagenta;
            panEinfahrt.Cursor = Cursors.Hand;
            panEinfahrt.Location = new Point(104, 75);
            panEinfahrt.Name = "panEinfahrt";
            panEinfahrt.Size = new Size(104, 96);
            panEinfahrt.TabIndex = 3;
            panEinfahrt.Tag = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.MediumOrchid;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI Variable Small Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(32, 41);
            label2.Name = "label2";
            label2.Size = new Size(176, 22);
            label2.TabIndex = 4;
            label2.Text = "Drag'n'Drop Kennzeichen";
            // 
            // panAusfahrt
            // 
            panAusfahrt.AllowDrop = true;
            panAusfahrt.BackColor = Color.Indigo;
            panAusfahrt.Cursor = Cursors.Hand;
            panAusfahrt.Location = new Point(872, 395);
            panAusfahrt.Name = "panAusfahrt";
            panAusfahrt.Size = new Size(106, 104);
            panAusfahrt.TabIndex = 4;
            panAusfahrt.Tag = "";
            // 
            // lblEinfahrt
            // 
            lblEinfahrt.AutoSize = true;
            lblEinfahrt.BackColor = Color.DarkMagenta;
            lblEinfahrt.BorderStyle = BorderStyle.FixedSingle;
            lblEinfahrt.Font = new Font("Segoe UI Variable Small Semibol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEinfahrt.ForeColor = SystemColors.ButtonHighlight;
            lblEinfahrt.Location = new Point(32, 75);
            lblEinfahrt.Name = "lblEinfahrt";
            lblEinfahrt.Size = new Size(70, 22);
            lblEinfahrt.TabIndex = 5;
            lblEinfahrt.Text = "Einfahrt ";
            // 
            // lblAusfahrt
            // 
            lblAusfahrt.AutoSize = true;
            lblAusfahrt.BackColor = Color.Indigo;
            lblAusfahrt.BorderStyle = BorderStyle.FixedSingle;
            lblAusfahrt.Font = new Font("Segoe UI Variable Small Semibol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAusfahrt.ForeColor = SystemColors.ButtonHighlight;
            lblAusfahrt.Location = new Point(802, 395);
            lblAusfahrt.Name = "lblAusfahrt";
            lblAusfahrt.Size = new Size(71, 22);
            lblAusfahrt.TabIndex = 7;
            lblAusfahrt.Text = "Ausfahrt";
            // 
            // btnBericht
            // 
            btnBericht.BackColor = Color.FromArgb(64, 0, 64);
            btnBericht.BackgroundImageLayout = ImageLayout.Stretch;
            btnBericht.FlatAppearance.BorderColor = Color.Indigo;
            btnBericht.FlatAppearance.MouseOverBackColor = Color.Purple;
            btnBericht.FlatStyle = FlatStyle.Flat;
            btnBericht.Font = new Font("Segoe UI Variable Small Semibol", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBericht.ForeColor = SystemColors.ButtonHighlight;
            btnBericht.Location = new Point(32, 465);
            btnBericht.Name = "btnBericht";
            btnBericht.Size = new Size(102, 34);
            btnBericht.TabIndex = 8;
            btnBericht.Text = "Bericht";
            btnBericht.UseVisualStyleBackColor = false;
            btnBericht.Click += btnBericht_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(32, 430);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 9;
            label1.Text = "Adminbereich";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.BlueViolet;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI Variable Small Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(802, 362);
            label3.Name = "label3";
            label3.Size = new Size(176, 22);
            label3.TabIndex = 10;
            label3.Text = "Drag'n'Drop Kennzeichen";
            // 
            // lblSumme
            // 
            lblSumme.AutoSize = true;
            lblSumme.BackColor = Color.Purple;
            lblSumme.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSumme.ForeColor = SystemColors.ButtonHighlight;
            lblSumme.Location = new Point(431, 211);
            lblSumme.Name = "lblSumme";
            lblSumme.Size = new Size(126, 23);
            lblSumme.TabIndex = 15;
            lblSumme.Text = "Summe 0.00 €";
            // 
            // lblParkdauer
            // 
            lblParkdauer.AutoSize = true;
            lblParkdauer.BackColor = Color.Purple;
            lblParkdauer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblParkdauer.ForeColor = SystemColors.ButtonHighlight;
            lblParkdauer.Location = new Point(431, 178);
            lblParkdauer.Name = "lblParkdauer";
            lblParkdauer.Size = new Size(122, 23);
            lblParkdauer.TabIndex = 13;
            lblParkdauer.Text = "Parkdauer 0 h";
            // 
            // tbKennzchEingabe
            // 
            tbKennzchEingabe.Location = new Point(431, 133);
            tbKennzchEingabe.Name = "tbKennzchEingabe";
            tbKennzchEingabe.Size = new Size(179, 27);
            tbKennzchEingabe.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Purple;
            label8.Font = new Font("Segoe UI", 10F);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(431, 81);
            label8.Name = "label8";
            label8.Size = new Size(193, 23);
            label8.TabIndex = 11;
            label8.Text = "Kennzeichhen eingeben";
            // 
            // tbKreditkarte
            // 
            tbKreditkarte.Location = new Point(431, 392);
            tbKreditkarte.Name = "tbKreditkarte";
            tbKreditkarte.PlaceholderText = "XXXX XXXX XXXX XXXX";
            tbKreditkarte.Size = new Size(230, 27);
            tbKreditkarte.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(64, 0, 64);
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(431, 322);
            label5.Name = "label5";
            label5.Size = new Size(93, 23);
            label5.TabIndex = 17;
            label5.Text = "Kreditkarte";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(431, 357);
            label6.Name = "label6";
            label6.Size = new Size(125, 23);
            label6.TabIndex = 16;
            label6.Text = "Kartennummer";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.MediumSlateBlue;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(819, 41);
            label9.Name = "label9";
            label9.Size = new Size(159, 23);
            label9.TabIndex = 19;
            label9.Text = "Parkplatz 2.00 €/h";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Purple;
            label10.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(431, 41);
            label10.Name = "label10";
            label10.Size = new Size(60, 25);
            label10.TabIndex = 20;
            label10.Text = "Kasse";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Purple;
            label11.Font = new Font("Segoe UI", 8F);
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(431, 104);
            label11.Name = "label11";
            label11.Size = new Size(230, 19);
            label11.TabIndex = 21;
            label11.Text = "(ohne BIndestriche und Leerzeichen)";
            // 
            // btnKennzchEingabe
            // 
            btnKennzchEingabe.BackColor = Color.Purple;
            btnKennzchEingabe.BackgroundImageLayout = ImageLayout.Stretch;
            btnKennzchEingabe.FlatAppearance.BorderColor = Color.Indigo;
            btnKennzchEingabe.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 192);
            btnKennzchEingabe.FlatStyle = FlatStyle.Flat;
            btnKennzchEingabe.Font = new Font("Segoe UI Variable Small Semibol", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnKennzchEingabe.ForeColor = SystemColors.ButtonHighlight;
            btnKennzchEingabe.Location = new Point(616, 128);
            btnKennzchEingabe.Name = "btnKennzchEingabe";
            btnKennzchEingabe.Size = new Size(45, 34);
            btnKennzchEingabe.TabIndex = 22;
            btnKennzchEingabe.Text = "OK";
            btnKennzchEingabe.UseVisualStyleBackColor = false;
            btnKennzchEingabe.Click += btnKennzchEingabe_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 0, 64);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1032, 525);
            Controls.Add(btnKennzchEingabe);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(tbKreditkarte);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(lblSumme);
            Controls.Add(lblParkdauer);
            Controls.Add(tbKennzchEingabe);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnBericht);
            Controls.Add(lblAusfahrt);
            Controls.Add(lblEinfahrt);
            Controls.Add(panAusfahrt);
            Controls.Add(label2);
            Controls.Add(panEinfahrt);
            Controls.Add(btnBezahlen);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBezahlen;
        private Panel panEinfahrt;
        private Label label2;
        private Panel panAusfahrt;
        private Label lblEinfahrt;
        private Label lblAusfahrt;
        private Button btnBericht;
        private Label label1;
        private Label label3;
        private Label lblSumme;
        private Label lblParkdauer;
        private TextBox tbKennzchEingabe;
        private Label label8;
        private TextBox tbKreditkarte;
        private Label label5;
        private Label label6;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button btnKennzchEingabe;
    }
}
