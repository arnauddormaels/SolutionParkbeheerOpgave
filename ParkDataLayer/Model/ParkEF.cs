using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class ParkEF
    {
        public ParkEF(string id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }

        public ParkEF(string id, string naam, string locatie, List<HuisEF> huizen)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
            Huizen = huizen;
        }

        [Key]
        [MaxLength(20)]
        public string Id { get; private set; }
        [Required]
        [MaxLength(250)]
        public string Naam { get; private set; }
        [MaxLength(500)]
        public string Locatie { get; private set; }

        public List<HuisEF> Huizen { get; set; }

    }
}
