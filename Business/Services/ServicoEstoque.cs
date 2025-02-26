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
        Task<List<Estoque>> getEstoque();

        Task<Estoque> addEstoque(Estoque item);

        Task updateEstoque(Estoque item);

        Task<bool> estoqueExiste(int id);

        Task deleteEstoque(int id);

        Task<Estoque> getEstoqueId(int id);
    }

    public class ServicoEstoque(IRepositorioEstoque repositorioEstoque) : IServicoEstoque
    {
        public async Task<Estoque> addEstoque(Estoque item)
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

        public async Task<List<Estoque>> getEstoque()
        {
            return await repositorioEstoque.getEstoque();
        }

        public async Task<Estoque> getEstoqueId(int id)
        {
            return await repositorioEstoque.getEstoqueId(id);
        }

        public Task updateEstoque(Estoque item)
        {
            return repositorioEstoque.updateEstoque(item);
        }

        
    }
}
