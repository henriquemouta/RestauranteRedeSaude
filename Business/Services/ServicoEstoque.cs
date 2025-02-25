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
    }

    public class ServicoEstoque(IRepositorioEstoque repositorioEstoque) : IServicoEstoque
    {
        public async Task<EstoqueVM> CreateEstoqueItem(EstoqueVM item)
        {
            return await repositorioEstoque.CreateEstoqueItem(item);
        }

        public async Task<List<EstoqueVM>> GetEstoque()
        {
            return await repositorioEstoque.GetEstoque();
        }
    }
}
