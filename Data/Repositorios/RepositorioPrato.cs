using Data;
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
       Task<IQueryable<Prato>> getPratos();
        Task<Prato> getPratoId(int id);
        Task<Prato> addPrato(Prato prato);
        Task updatePrato(Prato prato);
        Task deletePrato(int id);
        Task saveChangesAsync();
    }

    public class RepositorioPrato : IRepositorioPrato
    {
        private readonly AppDbContext _dbContext;
        public RepositorioPrato(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<Prato>> getPratos()
        {
            return _dbContext.Prato.AsNoTracking();
        }

        public async Task<Prato> getPratoId(int id)
        {
            return await _dbContext.Prato.AsNoTracking().FirstOrDefaultAsync(n => n.id == id);
             
        }

        public async Task deletePrato(int id)
        {
            try
            {
                var prato = await _dbContext.Prato.FindAsync(id);
                if (prato == null)
                {
                    throw new KeyNotFoundException("Prato não encontrado.");
                }
                _dbContext.Prato.Remove(prato);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
        public async Task<Prato> addPrato(Prato prato) 
        {
            try
            {
                _dbContext.Prato.Add(prato);
                await _dbContext.SaveChangesAsync();
                return prato;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task updatePrato(Prato prato)
        {
            try
            {
                _dbContext.Entry(prato).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task saveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
