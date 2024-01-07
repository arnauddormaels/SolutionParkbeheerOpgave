using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurderEF
    {
        public HuurderEF(string naam, string? email, string? tel, string? adres)
        {
            Naam = naam;
            Email = email;
            Tel = tel;
            Adres = adres;
        }

        public HuurderEF(int id, string naam, string? email, string? tel, string? adres)
        {
            Id = id;
            Naam = naam;
            Email = email;
            Tel = tel;
            Adres = adres;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }
        
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? Tel { get; set; } 
       
        [MaxLength(100)]
        public string? Adres { get; set; } 
    }
}
