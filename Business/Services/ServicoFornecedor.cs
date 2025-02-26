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
        Task<List<FornecedorVM>> getFornecedores();
        Task<FornecedorVM> getFornecedorId(int id);
        Task<FornecedorVM> addFornecedor(FornecedorVM fornecedor);
        Task updateFornecedor(FornecedorVM fornecedor);
        Task deleteFornecedor(int id);
    }
    public class ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor) : IServicoFornecedor
    {
        public async Task<FornecedorVM> addFornecedor(FornecedorVM fornecedor)
        {
            return await repositorioFornecedor.addFornecedor(fornecedor);
        }

        public async Task deleteFornecedor(int id)
        {
            await repositorioFornecedor.deleteFornecedor(id); 
        }

        public async Task<List<FornecedorVM>> getFornecedores()
        {
            return await repositorioFornecedor.getFornecedores();
        }

        public async Task<FornecedorVM> getFornecedorId(int id)
        {
            return await repositorioFornecedor.getFornecedorId(id);
        }

        public async Task updateFornecedor(FornecedorVM fornecedor)
        {
            await repositorioFornecedor.updateFornecedor(fornecedor);
        }
    }
}
