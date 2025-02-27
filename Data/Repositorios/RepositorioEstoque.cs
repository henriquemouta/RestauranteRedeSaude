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
    public interface IRepositorioEstoque
    {
        Task<IQueryable<Estoque>> getEstoque();
        Task<Estoque> getEstoqueId(int id);

        Task addEstoque(Estoque item);

        Task updateEstoque(Estoque item);

        Task deleteEstoque(int id);

        Task<bool> estoqueExiste(int id);

        Task saveChangesAsync();

    }

    public class RepositorioEstoque : IRepositorioEstoque
    {

        private readonly AppDbContext _dbContext;
        public RepositorioEstoque(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task saveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task addEstoque(Estoque item)
        {
            try
            {
                _dbContext.Estoque.Add(item);
                return item;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        public async Task deleteEstoque(int id)
        {
            try
            {
                var estoque = await _dbContext.Estoque.FindAsync(id);
                if (estoque == null)
                {
                    throw new KeyNotFoundException("Item não encontrado.");
                }
                _dbContext.Estoque.Remove(estoque);
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> estoqueExiste(int id)
        {
            return await _dbContext.Estoque.AnyAsync(sel => sel.id == id);
        }

        public async Task<IQueryable<Estoque>> getEstoque()
        {
            return _dbContext.Estoque.AsNoTracking();
        }

        public async Task<Estoque> getEstoqueId(int id)
        {
            return await _dbContext.Estoque.AsNoTracking().FirstOrDefaultAsync(sel => sel.id == id);
        }

        public async Task updateEstoque(Estoque item)
        {
            try
            {
                _dbContext.Entry(item).State = EntityState.Modified;
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
