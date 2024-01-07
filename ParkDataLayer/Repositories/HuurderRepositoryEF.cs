using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private DatabaseContext ctx;

        public HuurderRepositoryEF(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public Huurder GeefHuurder(int id)
        {
            try
            {
          return HuurderMapper.MapToHuurderModel( ctx.Huurders.AsNoTracking().First(h => h.Id == id));  

            }catch(Exception ex)
            {
                throw new RepositoryException("GeefHuurders");
            }
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                return HuurderMapper.MapToHuurderModelList(ctx.Huurders.AsNoTracking().Where(h => h.Naam.ToLower().Contains(naam.ToLower())).ToList());
            }catch(Exception ex)
            {
                throw new RepositoryException("GeefHuurders");
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            if(ctx.Huurders.Any(h => h.Naam == naam 
            && contact.Tel == h.Tel
            && contact.Email == h.Email
            && contact.Adres == h.Adres))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HeeftHuurder(int id)
        {
            if (ctx.Huurders.Any(h => h.Id == id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void UpdateHuurder(Huurder huurder)
        {
            HuurderEF huurderUpdate = HuurderMapper.MapToHuurderEF(huurder);

            HuurderEF huurderEF = ctx.Huurders.Where(h=> h.Id == huurder.Id).First();

            ctx.Entry(huurderEF).CurrentValues.SetValues(huurderUpdate);

            ctx.SaveChanges();
        }

        public Huurder VoegHuurderToe(Huurder h)
        {
            HuurderEF huurderEF = HuurderMapper.MapToHuurderEF(h);

            ctx.Huurders.Add(huurderEF);

            ctx.SaveChanges();
            return HuurderMapper.MapToHuurderModel(huurderEF);

        }
    }
}
