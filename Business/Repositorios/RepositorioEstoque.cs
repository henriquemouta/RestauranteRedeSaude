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
        Task<List<EstoqueVM>> getEstoque();

        Task<EstoqueVM> addEstoque(EstoqueVM item);

        Task updateEstoque(EstoqueVM item);

        Task<bool> estoqueExiste(int id);

        Task deleteEstoque(int id);

        Task<EstoqueVM> getEstoqueId(int id);
    }

    public class RepositorioEstoque(AppDbContext dbContext) : IRepositorioEstoque
    {
        public async Task<EstoqueVM> addEstoque(EstoqueVM item)
        {
           dbContext.Estoque.Add(item);
           await dbContext.SaveChangesAsync();
           return item;
           
        }

        public async Task deleteEstoque(int id)
        {
            var estoque = await dbContext.Estoque.FirstOrDefaultAsync(sel => sel.ID == id);
            dbContext.Estoque.Remove(estoque);
            dbContext.SaveChanges();
        }

        public async Task<bool> estoqueExiste(int id)
        {
            return await dbContext.Estoque.AnyAsync(sel => sel.ID == id);
        }

        public async Task<List<EstoqueVM>> getEstoque()
        {
            return await dbContext.Estoque.ToListAsync();
        }

        public async Task<EstoqueVM> getEstoqueId(int id)
        {
            return await dbContext.Estoque.FirstOrDefaultAsync(sel => sel.ID == id);
        }

        public async Task updateEstoque(EstoqueVM item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
