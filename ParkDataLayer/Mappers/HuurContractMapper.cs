using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class HuurContractMapper
    {   
        public static Huurcontract MapToHuurContractModel(HuurContractEF huurContractEF)
        {
            Huurperiode huurperiode = HuurPeriodeMapper.MapToHuurPeriodeModel(huurContractEF.Huurperiode);
            Huurder huurder = HuurderMapper.MapToHuurderModel(huurContractEF.Huurder);
            Huis huis = HuisMapper.MapToHuisModelWithoutDictionary(huurContractEF.Huis);

            return new Huurcontract(huurContractEF.Id, huurperiode, huurder, huis);
        }

        public static HuurContractEF MapToHuurContractEF(Huurcontract huurcontract)
        {
            HuurperiodeEF huurperiode = HuurPeriodeMapper.MapToHuurPeriodeEF(huurcontract.Huurperiode);
            return new HuurContractEF(huurcontract.Id, huurperiode, huurcontract.Huurder.Id, huurcontract.Huis.Id);
        }

    }
}
