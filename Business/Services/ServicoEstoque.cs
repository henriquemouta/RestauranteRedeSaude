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
        Task<List<EstoqueVM>> getEstoque();

        Task<EstoqueVM> addEstoque(EstoqueVM item);

        Task updateEstoque(EstoqueVM item);

        Task<bool> estoqueExiste(int id);

        Task deleteEstoque(int id);

        Task<EstoqueVM> getEstoqueId(int id);
    }

    public class ServicoEstoque(IRepositorioEstoque repositorioEstoque) : IServicoEstoque
    {
        public async Task<EstoqueVM> addEstoque(EstoqueVM item)
        {
            return await repositorioEstoque.addEstoque(item);
        }

        public Task deleteEstoque(int id)
        {
           return repositorioEstoque.deleteEstoque(id);
        }

        public async Task<bool> estoqueExiste(int id)
        {
            return await repositorioEstoque.estoqueExiste(id);
        }

        public async Task<List<EstoqueVM>> getEstoque()
        {
            return await repositorioEstoque.getEstoque();
        }

        public async Task<EstoqueVM> getEstoqueId(int id)
        {
            return await repositorioEstoque.getEstoqueId(id);
        }

        public Task updateEstoque(EstoqueVM item)
        {
            return repositorioEstoque.updateEstoque(item);
        }

        
    }
}
