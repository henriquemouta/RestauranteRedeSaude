using Data.Data;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositorios
{
    public interface IRepositorioPrato
    {
       Task<List<PratoVM>> getPratos();
        Task<PratoVM> getPratoId(int id);
        Task<PratoVM> addPrato(PratoVM prato);
        Task updatePrato(PratoVM prato);
        Task deletePrato(int id);

    }

    public class RepositorioPrato(AppDbContext dbContext) : IRepositorioPrato
    {
        public async Task<List<PratoVM>> getPratos()
        {
            return await dbContext.Prato.ToListAsync();
        }

        public async Task<PratoVM> getPratoId(int id)
        {
            return await dbContext.Prato.FirstOrDefaultAsync(n => n.id == id);
             
        }

        public async Task deletePrato(int id)
        {
            var prato = await dbContext.Prato.FirstOrDefaultAsync(n => n.id == id);
            dbContext.Prato.Remove(prato);
            await dbContext.SaveChangesAsync();
        }

        
        public async Task<PratoVM> addPrato(PratoVM prato) { 
            dbContext.Prato.Add(prato);
            await dbContext.SaveChangesAsync();
            return prato;
        }

        public async Task updatePrato(PratoVM prato)
        {
            dbContext.Entry(prato).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
