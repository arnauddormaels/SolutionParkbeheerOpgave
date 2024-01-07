using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurContractEF
    {
        public HuurContractEF(string id, int huurperiodeId, int huurderId, int huisId)
        {
            Id = id;
            HuurperiodeId = huurperiodeId;
            HuurderId = huurderId;
            HuisId = huisId;
        }

        public HuurContractEF(string id, HuurperiodeEF huurperiode, int huurderId, int huisId)
        {
            Id = id;
            Huurperiode = huurperiode;
            HuurderId = huurderId;
            HuisId = huisId;
        }

        [Key]
        [MaxLength(25)]
        public string Id { get; set; }
        [Required]
        public int HuurperiodeId { get; set; }
        [Required]
        public HuurperiodeEF Huurperiode { get; set; }
        public int HuurderId { get; set; }
        [Required]
        public HuurderEF Huurder { get; set; }
        public int HuisId { get; set; }
        [Required]
        public HuisEF Huis { get; set; }
    }
}
