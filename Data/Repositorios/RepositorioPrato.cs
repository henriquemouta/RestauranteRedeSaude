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
       Task<List<Prato>> getPratos();
        Task<Prato> getPratoId(int id);
        Task<Prato> addPrato(Prato prato);
        Task updatePrato(Prato prato);
        Task deletePrato(int id);

    }

    public class RepositorioPrato(AppDbContext dbContext) : IRepositorioPrato
    {
        public async Task<List<Prato>> getPratos()
        {
            return await dbContext.Prato.ToListAsync();
        }

        public async Task<Prato> getPratoId(int id)
        {
            return await dbContext.Prato.FirstOrDefaultAsync(n => n.id == id);
             
        }

        public async Task deletePrato(int id)
        {
            var prato = await dbContext.Prato.FirstOrDefaultAsync(n => n.id == id);
            dbContext.Prato.Remove(prato);
            await dbContext.SaveChangesAsync();
        }

        
        public async Task<Prato> addPrato(Prato prato) { 
            dbContext.Prato.Add(prato);
            await dbContext.SaveChangesAsync();
            return prato;
        }

        public async Task updatePrato(Prato prato)
        {
            dbContext.Entry(prato).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
