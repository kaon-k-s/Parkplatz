using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkplatz
{
    public partial class Bericht : Form
    {
        private Datenbank db;

        public Bericht(Datenbank datenbank)
        {
            InitializeComponent();
            db = datenbank;

            // Populate the lists when the form is opened
            LoadBerichtData();
        }

        private void LoadBerichtData()
        {
            // 1. Vehicles that paid correctly
            List<string> korrektBezahltList = db.getKorrektBezahlt();
            foreach (string item in korrektBezahltList)
            {
                libKorrekt.Items.Add(item);
            }

            // 2. Vehicles that haven't paid or underpaid
            List<string> wenigKeineBezahltList = db.getNichtBezahltOderZuWenig();
            foreach (string item in wenigKeineBezahltList)
            {
                libWenigKeine.Items.Add(item);
            }

            // 3. Vehicles that haven't exited yet
            List<string> nichtAusgefahrenList = db.getNichtAusgefahren();
            foreach (string item in nichtAusgefahrenList)
            {
                libNichtAusgefahren.Items.Add(item);
            }
        }
    }

}
