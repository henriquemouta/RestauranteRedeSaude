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
        Task<List<EstoqueVM>> GetEstoque();

        Task<EstoqueVM> CreateEstoqueItem(EstoqueVM item);

        Task UpdateEstoqueItem(EstoqueVM item);

        Task<bool> EstoqueExiste(int id);

        Task DeleteEstoqueItem(int id);

        Task<EstoqueVM> GetEstoqueU(int id);
    }

    public class RepositorioEstoque(AppDbContext dbContext) : IRepositorioEstoque
    {
        public async Task<EstoqueVM> CreateEstoqueItem(EstoqueVM item)
        {
           dbContext.Estoque.Add(item);
           await dbContext.SaveChangesAsync();
           return item;
           
        }

        public async Task DeleteEstoqueItem(int id)
        {
            var estoque = await dbContext.Estoque.FirstOrDefaultAsync(sel => sel.ID == id);
            dbContext.Estoque.Remove(estoque);
            dbContext.SaveChanges();
        }

        public async Task<bool> EstoqueExiste(int id)
        {
            return await dbContext.Estoque.AnyAsync(sel => sel.ID == id);
        }

        public async Task<List<EstoqueVM>> GetEstoque()
        {
            return await dbContext.Estoque.ToListAsync();
        }

        public async Task<EstoqueVM> GetEstoqueU(int id)
        {
            return await dbContext.Estoque.FirstOrDefaultAsync(sel => sel.ID == id);
        }

        public async Task UpdateEstoqueItem(EstoqueVM item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
