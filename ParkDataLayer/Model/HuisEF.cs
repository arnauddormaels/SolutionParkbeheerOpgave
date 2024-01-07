using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuisEF
    {
        public HuisEF(int id, string straat, int nr, bool actief, string parkId, List<HuurContractEF> huurcontracten)
        {
            Id = id;
            Straat = straat;
            Nr = nr;
            Actief = actief;
            ParkId = parkId;
            Huurcontracten = huurcontracten;
        }

        public HuisEF(int id, string straat, int nr, bool actief, string parkId)
        {
            Id = id;
            Straat = straat;
            Nr = nr;
            Actief = actief;
            ParkId = parkId;
        }

        public HuisEF(int id, string straat, int nr, bool actief, ParkEF park)
        {
            Id = id;
            Straat = straat;
            Nr = nr;
            Actief = actief;
            Park = park;
        }

        public int Id { get;  set; }
        [Required]
        [MaxLength(250)]
        public string Straat { get;  set; }
        [Required]
        public int Nr { get;  set; }
        [Required]
        public bool Actief { get; set; }
        public string ParkId { get; set; }
        [Required]
        public ParkEF Park { get;  set; }
        public List<HuurContractEF> Huurcontracten { get; set; }
    }
}
