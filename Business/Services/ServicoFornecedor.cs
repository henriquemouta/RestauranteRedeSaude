using Business.Repositorios;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IServicoFornecedor
    {
        Task<List<FornecedorVM>> GetFornecedores();
        Task<FornecedorVM> GetFornecedorId(int id);
        Task<FornecedorVM> AddFornecedor(FornecedorVM fornecedor);
        Task UpdateFornecedor(FornecedorVM fornecedor);
        Task DeleteFornecedor(int id);
    }
    public class ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor) : IServicoFornecedor
    {
        public async Task<FornecedorVM> AddFornecedor(FornecedorVM fornecedor)
        {
            return await repositorioFornecedor.AddFornecedor(fornecedor);
        }

        public async Task DeleteFornecedor(int id)
        {
            await repositorioFornecedor.DeleteFornecedor(id); 
        }

        public async Task<List<FornecedorVM>> GetFornecedores()
        {
            return await repositorioFornecedor.GetFornecedores();
        }

        public async Task<FornecedorVM> GetFornecedorId(int id)
        {
            return await repositorioFornecedor.GetFornecedorId(id);
        }

        public async Task UpdateFornecedor(FornecedorVM fornecedor)
        {
            await repositorioFornecedor.UpdateFornecedor(fornecedor);
        }
    }
}
