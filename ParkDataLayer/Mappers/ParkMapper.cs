using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class ParkMapper
    {
        
        public static Park MapToParkModel(ParkEF parkEF)
        {
            if(parkEF.Huizen != null && parkEF.Huizen.Count > 0) {
                List<Huis> huizen = new List<Huis>();
                foreach(HuisEF huisEF in parkEF.Huizen)
                {
                    huizen.Add(HuisMapper.MapToHuisModel(huisEF));
                }
                return new Park(parkEF.Id, parkEF.Naam, parkEF.Locatie, huizen);
            }

            return new Park(parkEF.Id, parkEF.Naam, parkEF.Locatie);
        }

        public static ParkEF MapToParkEF(Park park)
        {
            return new ParkEF(park.Id,park.Naam, park.Locatie);
        }


    }
}
