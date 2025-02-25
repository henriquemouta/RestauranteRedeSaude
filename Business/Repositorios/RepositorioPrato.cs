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
       Task<List<PratoVM>> GetPratos();
        Task<PratoVM> GetPratoId(int id);
        Task<PratoVM> AddPrato(PratoVM prato);
        Task UpdatePrato(PratoVM prato);
        Task DeletePrato(int id);

    }

    public class RepositorioPrato(AppDbContext dbContext) : IRepositorioPrato
    {
        public async Task<List<PratoVM>> GetPratos()
        {
            return await dbContext.Prato.ToListAsync();
        }

        public async Task<PratoVM> GetPratoId(int id)
        {
            return await dbContext.Prato.FirstOrDefaultAsync(n => n.id == id);
             
        }

        public async Task DeletePrato(int id)
        {
            var prato = await dbContext.Prato.FirstOrDefaultAsync(n => n.id == id);
            dbContext.Prato.Remove(prato);
            await dbContext.SaveChangesAsync();
        }

        
        public async Task<PratoVM> AddPrato(PratoVM prato) { 
            dbContext.Prato.Add(prato);
            await dbContext.SaveChangesAsync();
            return prato;
        }

        public async Task UpdatePrato(PratoVM prato)
        {
            dbContext.Entry(prato).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
