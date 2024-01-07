using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        private DatabaseContext ctx;

        public ContractenRepositoryEF(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            HuurContractEF contractEF = ctx.HuurContracten.Where(c => c.Id.ToLower()== contract.Id.ToLower()).First();

            ctx.HuurContracten.Remove(contractEF);
            ctx.SaveChanges();
        }

        public Huurcontract GeefContract(string id)
        {
            HuurContractEF huurcontract= ctx.HuurContracten
                .Include(hc => hc.Huurder)
                .Include(hc => hc.Huurperiode)
                .Include(hc => hc.Huis)
                .ThenInclude(hc => hc.Park)
                .Where(hc => hc.Id.ToLower()== id.ToLower()).First();

            return HuurContractMapper.MapToHuurContractModel(huurcontract);
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
          List<Huurcontract> huurcontracten = new List<Huurcontract>();
            huurcontracten = ctx.HuurContracten
                
                .Include(hc => hc.Huurder)
                .Include(hc => hc.Huurperiode)
                .Include(hc => hc.Huis)
                .ThenInclude(hc => hc.Park)
                .Where(hc => hc.Huurperiode.StartDatum >= dtBegin
                && (dtEinde == null || hc.Huurperiode.EindDatum <= dtEinde))
                .Select(hc => HuurContractMapper.MapToHuurContractModel(hc)).ToList();
            return huurcontracten;
            
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            return ctx.HuurContracten.Include(x => x.Huurperiode).Where(x =>
            x.Huurperiode.StartDatum == startDatum
            && x.HuurderId == huurderid 
            && x.HuisId == huisid).Any();

        }

        public bool HeeftContract(string id)
        {
            return ctx.HuurContracten.Where(x => x.Id.ToLower() == id.ToLower()).Any();

        }

        public void UpdateContract(Huurcontract contract)
        {
            HuurContractEF updatedContractEF = HuurContractMapper.MapToHuurContractEF(contract);

            HuurContractEF contractEF = ctx.HuurContracten.Include(hc=> hc.Huurperiode).Where(hc => hc.Id.ToLower() == contract.Id.ToLower()).First();

            contractEF.HuurderId = updatedContractEF.HuurderId;
            contractEF.HuisId = updatedContractEF.HuisId;
            contractEF.Huurperiode.Aantaldagen = updatedContractEF.Huurperiode.Aantaldagen;
            contractEF.Huurperiode.StartDatum = updatedContractEF.Huurperiode.StartDatum;
            contractEF.Huurperiode.EindDatum = updatedContractEF.Huurperiode.EindDatum;

            ctx.SaveChanges();
        }

        public void VoegContractToe(Huurcontract contract)
        {
            HuurContractEF huurcontractEF = HuurContractMapper.MapToHuurContractEF(contract);

            ctx.HuurContracten.Add(huurcontractEF);

            ctx.SaveChanges();


        }
    }
}
