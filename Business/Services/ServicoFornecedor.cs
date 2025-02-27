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

    public class ServicoFornecedor : IServicoFornecedor
    {
        private readonly IRepositorioFornecedor repositorioFornecedor;

        public ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor)
        {
            repositorioFornecedor = repositorioFornecedor ?? throw new ArgumentNullException(nameof(repositorioFornecedor));
        }


        public async Task<Fornecedor> addFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
    
            if (string.IsNullOrWhiteSpace(fornecedor.cnpj)) throw new ArgumentException("CNPJ é obrigatório.", nameof(fornecedor));

            await repositorioFornecedor.saveChangesAsync();

            return await repositorioFornecedor.addFornecedor(fornecedor);
            
            
        }

        public async Task deleteFornecedor(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            
            await repositorioFornecedor.deleteFornecedor(id);
            
            await repositorioFornecedor.saveChangesAsync();

        }

        public async Task<List<Fornecedor>> getFornecedores()
        {
            return await repositorioFornecedor.getFornecedores();
        }

        public async Task<Fornecedor> getFornecedorId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            
            var fornecedor = await repositorioFornecedor.getFornecedorId(id);
            
            return fornecedor ?? throw new KeyNotFoundException($"Fornecedor com Id {id} não encontrado.");
        }

        public async Task updateFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            if (fornecedor.id <= 0) throw new ArgumentException("Id inválido.", nameof(fornecedor));
           
            await repositorioFornecedor.updateFornecedor(fornecedor);
            
            await repositorioFornecedor.saveChangesAsync();

        }




    }
}
