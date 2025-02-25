using Business.Repositorios;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IServicoEstoque
    {
        Task<List<EstoqueVM>> GetEstoque();

        Task<EstoqueVM> CreateEstoqueItem(EstoqueVM item);

        Task UpdateEstoqueItem(EstoqueVM item);

        Task<bool> EstoqueExiste(int id);

        Task DeleteEstoqueItem(int id);

        Task<EstoqueVM> GetEstoqueU(int id);
    }

    public class ServicoEstoque(IRepositorioEstoque repositorioEstoque) : IServicoEstoque
    {
        public async Task<EstoqueVM> CreateEstoqueItem(EstoqueVM item)
        {
            return await repositorioEstoque.CreateEstoqueItem(item);
        }

        public Task DeleteEstoqueItem(int id)
        {
           return repositorioEstoque.DeleteEstoqueItem(id);
        }

        public async Task<bool> EstoqueExiste(int id)
        {
            return await repositorioEstoque.EstoqueExiste(id);
        }

        public async Task<List<EstoqueVM>> GetEstoque()
        {
            return await repositorioEstoque.GetEstoque();
        }

        public async Task<EstoqueVM> GetEstoqueU(int id)
        {
            return await repositorioEstoque.GetEstoqueU(id);
        }

        public Task UpdateEstoqueItem(EstoqueVM item)
        {
            return repositorioEstoque.UpdateEstoqueItem(item);
        }

        
    }
}
