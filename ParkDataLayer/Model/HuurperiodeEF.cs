using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurperiodeEF
    {
        public HuurperiodeEF(DateTime startDatum, DateTime eindDatum, int aantaldagen)
        {
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Aantaldagen = aantaldagen;
        }

        public HuurperiodeEF(int id, DateTime startDatum, DateTime eindDatum, int aantaldagen)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Aantaldagen = aantaldagen;
        }

        public int Id { get; set; }
        [Required]
        public DateTime StartDatum { get; set; }
        [Required]
        public DateTime EindDatum { get; set; }
        [Required]
        public int Aantaldagen { get; set; }
    
    }
}
