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
    }

    public class RepositorioEstoque(AppDbContext dbContext) : IRepositorioEstoque
    {
        public async Task<EstoqueVM> CreateEstoqueItem(EstoqueVM item)
        {
           dbContext.Estoque.Add(item);
           await dbContext.SaveChangesAsync();
           return item;
           
        }

        public async Task<List<EstoqueVM>> GetEstoque()
        {
            return await dbContext.Estoque.ToListAsync();
        }
    }
}
