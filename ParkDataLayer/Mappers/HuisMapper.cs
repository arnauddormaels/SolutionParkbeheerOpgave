using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class HuisMapper
    {
        public static HuisEF MapToHuisEF(Huis huis)
        {
            return new HuisEF(huis.Id, huis.Straat, huis.Nr, huis.Actief, ParkMapper.MapToParkEF(huis.Park));
        }
        internal static HuisEF MapToHuisEFWithoutPark(Huis huis)
        {
            return new HuisEF(huis.Id, huis.Straat, huis.Nr, huis.Actief, huis.Park.Id);
        }

        public static Huis MapToHuisModelWithoutDictionary(HuisEF huisEF)
        {
            huisEF.Park.Huizen = null;
            Park park = ParkMapper.MapToParkModel(huisEF.Park);
            return new Huis(huisEF.Id, huisEF.Straat, huisEF.Nr, huisEF.Actief, park);

        }
        public static Huis MapToHuisModel(HuisEF huisEF)
        {
           huisEF.Park.Huizen = null;
            Park park = ParkMapper.MapToParkModel(huisEF.Park);

            if (huisEF.Huurcontracten != null && huisEF.Huurcontracten.Count() > 0)
            {
                Dictionary<Huurder,List<Huurcontract>> huurcontracten = new Dictionary<Huurder, List<Huurcontract>>();
               
                huurcontracten = CreateDictionary(huisEF);

                return new Huis(huisEF.Id,huisEF.Straat, huisEF.Nr,huisEF.Actief, park, huurcontracten);
            }
                return new Huis(huisEF.Id,huisEF.Straat, huisEF.Nr, huisEF.Actief,park);
        }

    

        private static Dictionary<Huurder,List<Huurcontract>> CreateDictionary(HuisEF huisEF)
        {
            Dictionary<Huurder, List<Huurcontract>> huurcontracten = new Dictionary<Huurder, List<Huurcontract>>();

            foreach (HuurContractEF huurcontract in huisEF.Huurcontracten)
            {
                Huurder huurder = HuurderMapper.MapToHuurderModel(huurcontract.Huurder);
                Huurcontract contract = HuurContractMapper.MapToHuurContractModel(huurcontract);
                if (huurcontracten.ContainsKey(huurder))
                {
                    huurcontracten[huurder].Add(contract);

                }
                else
                {
                    huurcontracten.Add(huurder, new List<Huurcontract>() { contract });
                }
            }
            return huurcontracten;
        }


    }
}
