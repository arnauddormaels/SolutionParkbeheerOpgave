using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private DatabaseContext ctx;

        public HuizenRepositoryEF(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public Huis GeefHuis(int id)    //Not Tested
        {
            HuisEF huisEF = ctx.Huizen.AsNoTracking()
                .Include(h=> h.Park)
                .Include(h => h.Huurcontracten)
                .ThenInclude(hc => hc.Huurder)
                  .Include(h => h.Huurcontracten)
                .ThenInclude(hc => hc.Huurperiode)
                .Where(h => h.Id == id).First();
            return HuisMapper.MapToHuisModel(huisEF);

        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            if (ctx.Huizen.Any(h => h.Straat == straat
            && h.Nr == nummer
            && h.ParkId == park.Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HeeftHuis(int id)
        {
            if(ctx.Huizen.Any(h => h.Id == id)) {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void UpdateHuis(Huis huis)
        {
            HuisEF updateHuisEF = HuisMapper.MapToHuisEF(huis);
            HuisEF huisEF = ctx.Huizen.Where(h => h.Id == updateHuisEF.Id).First();

            huisEF.Straat = updateHuisEF.Straat;
            huisEF.Nr = updateHuisEF.Nr;
            huisEF.Actief = updateHuisEF.Actief;
            huisEF.ParkId = updateHuisEF.Park.Id;



            ctx.SaveChanges();
        }

        public Huis VoegHuisToe(Huis huis)
        {
            HuisEF huisEF;
            if (ctx.Parken.Any(p => p.Id == huis.Park.Id) )
            {
                huisEF = HuisMapper.MapToHuisEFWithoutPark(huis);
            }
            else
            {
                huisEF = HuisMapper.MapToHuisEF(huis);

            }
            ctx.Huizen.Add(huisEF);
            ctx.SaveChanges();
            huisEF = ctx.Huizen.Include(h=> h.Park).Where(h=> h.Id == huisEF.Id).First();

            return HuisMapper.MapToHuisModel(huisEF);
        }
    }
}
