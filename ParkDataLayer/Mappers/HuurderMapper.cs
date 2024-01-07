using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class HuurderMapper
    {
        public static HuurderEF MapToHuurderEF(Huurder huurder)
        {
            if(huurder.Id != 0 ) {
                return new HuurderEF(huurder.Id,huurder.Naam, huurder.Contactgegevens.Email, huurder.Contactgegevens.Tel, huurder.Contactgegevens.Adres);
            }
            return new HuurderEF(huurder.Naam, huurder.Contactgegevens.Email, huurder.Contactgegevens.Tel, huurder.Contactgegevens.Adres);

        }

        public static Huurder MapToHuurderModel(HuurderEF huurderEF)
        {

            if(huurderEF.Email == null)
            {
                huurderEF.Email = string.Empty;
            }
            if (huurderEF.Tel == null)
            {
                huurderEF.Tel = string.Empty;
            }
            if (huurderEF.Adres == null)
            {
                huurderEF.Adres = string.Empty;
            }
            return new Huurder(huurderEF.Id, huurderEF.Naam, new Contactgegevens(huurderEF.Email, huurderEF.Tel, huurderEF.Adres));
        }

        public static List<Huurder> MapToHuurderModelList(List<HuurderEF> huurderEFs)
        {
            List<Huurder> huurders = new List<Huurder>();
            if(huurderEFs != null && huurderEFs.Count() > 0)
            {

                foreach(HuurderEF h in huurderEFs)
                {
                    huurders.Add(MapToHuurderModel(h));
                }
            }
            return huurders;
        
        
        }
    }
}
