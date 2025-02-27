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
        private readonly IRepositorioFornecedor _repositorioFornecedor;
        public ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor)
        {
            _repositorioFornecedor = repositorioFornecedor ?? throw new ArgumentNullException(nameof(repositorioFornecedor));
        }
        public async Task<Fornecedor> addFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            if (string.IsNullOrWhiteSpace(fornecedor.cnpj)) throw new ArgumentException("CNPJ é obrigatório.", nameof(fornecedor));
            return await _repositorioFornecedor.addFornecedor(fornecedor);
        }

        public async Task deleteFornecedor(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            await _repositorioFornecedor.deleteFornecedor(id); 
        }

        public async Task<List<Fornecedor>> getFornecedores()
        {
            return await _repositorioFornecedor.getFornecedores();
        }

        public async Task<Fornecedor> getFornecedorId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            var fornecedor = await _repositorioFornecedor.getFornecedorId(id);
            return fornecedor ?? throw new KeyNotFoundException($"Fornecedor com Id {id} não encontrado.");
        }

        public async Task updateFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            if (fornecedor.id <= 0) throw new ArgumentException("Id inválido.", nameof(fornecedor));
            await _repositorioFornecedor.updateFornecedor(fornecedor);
        }
    }
}
