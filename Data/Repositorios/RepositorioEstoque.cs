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
        Task<List<Estoque>> getEstoque();

        Task<Estoque> addEstoque(Estoque item);

        Task updateEstoque(Estoque item);

        Task<bool> estoqueExiste(int id);

        Task deleteEstoque(int id);

        Task<Estoque> getEstoqueId(int id);
    }

    public class RepositorioEstoque(AppDbContext dbContext) : IRepositorioEstoque
    {
        public async Task<Estoque> addEstoque(Estoque item)
        {
           dbContext.Estoque.Add(item);
           await dbContext.SaveChangesAsync();
           return item;
           
        }

        public async Task deleteEstoque(int id)
        {
            var estoque = await dbContext.Estoque.FirstOrDefaultAsync(sel => sel.id == id);
            dbContext.Estoque.Remove(estoque);
            dbContext.SaveChanges();
        }

        public async Task<bool> estoqueExiste(int id)
        {
            return await dbContext.Estoque.AnyAsync(sel => sel.id == id);
        }

        public async Task<List<Estoque>> getEstoque()
        {
            return await dbContext.Estoque.ToListAsync();
        }

        public async Task<Estoque> getEstoqueId(int id)
        {
            return await dbContext.Estoque.FirstOrDefaultAsync(sel => sel.id == id);
        }

        public async Task updateEstoque(Estoque item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
