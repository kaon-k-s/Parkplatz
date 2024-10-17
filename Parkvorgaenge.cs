using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parkplatz
{
    public class Parkvorgaenge
    {
        private int id;
        private string kennzeichen;
        private DateTime einfahrtszeit;
        private DateTime? ausfahrtszeit;
        [Column(TypeName = "decimal(10,2)")]
        private decimal gebuehr;
        [Column(TypeName = "decimal(10,2)")]
        private decimal bezahlt;
        private string? status;

        public int Id { get => id; set => id = value; }
        public string Kennzeichen { get => kennzeichen; set => kennzeichen = value; }
        public DateTime Einfahrtszeit { get => einfahrtszeit; set => einfahrtszeit = value; }
        public DateTime? Ausfahrtszeit { get => ausfahrtszeit; set => ausfahrtszeit = value; }
        public decimal Gebuehr { get => gebuehr; set => gebuehr = value; }
        public decimal Bezahlt { get => bezahlt; set => bezahlt = value; }
        public string? Status { get => status; set => status = value; }

        public Parkvorgaenge(int id, string kennzeichen, DateTime einfahrtszeit, DateTime? ausfahrtszeit, decimal gebuehr, decimal bezahlt, string? status)
        {
            Id = id;
            Kennzeichen = kennzeichen;
            Einfahrtszeit = einfahrtszeit;
            Ausfahrtszeit = ausfahrtszeit;
            Gebuehr = gebuehr;
            Bezahlt = bezahlt;
            Status = status;
        }
    }
}
