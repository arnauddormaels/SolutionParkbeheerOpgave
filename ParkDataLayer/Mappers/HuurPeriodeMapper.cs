using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class HuurPeriodeMapper
    {

        public static Huurperiode MapToHuurPeriodeModel(HuurperiodeEF huurperiodeEF)
        {
            return new Huurperiode(huurperiodeEF.StartDatum, huurperiodeEF.Aantaldagen);
        }

        public static HuurperiodeEF MapToHuurPeriodeEF(Huurperiode huurperiode)
        {
            return new HuurperiodeEF(huurperiode.StartDatum, huurperiode.EindDatum, huurperiode.Aantaldagen);
        }
    }
}
