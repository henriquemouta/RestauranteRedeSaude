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
        Task<List<Fornecedor>> getFornecedores();
        Task<Fornecedor> getFornecedorId(int id);
        Task<Fornecedor> addFornecedor(Fornecedor fornecedor);
        Task updateFornecedor(Fornecedor fornecedor);
        Task deleteFornecedor(int id);
    }
    public class ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor) : IServicoFornecedor
    {
        public async Task<Fornecedor> addFornecedor(Fornecedor fornecedor)
        {
            return await repositorioFornecedor.addFornecedor(fornecedor);
        }

        public async Task deleteFornecedor(int id)
        {
            await repositorioFornecedor.deleteFornecedor(id); 
        }

        public async Task<List<Fornecedor>> getFornecedores()
        {
            return await repositorioFornecedor.getFornecedores();
        }

        public async Task<Fornecedor> getFornecedorId(int id)
        {
            return await repositorioFornecedor.getFornecedorId(id);
        }

        public async Task updateFornecedor(Fornecedor fornecedor)
        {
            await repositorioFornecedor.updateFornecedor(fornecedor);
        }
    }
}
