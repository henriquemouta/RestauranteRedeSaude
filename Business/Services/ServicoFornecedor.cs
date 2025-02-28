using Business.Repositorios;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewsModels.ViewsModels.Fornecedor;

namespace Business.Services
{
    public interface IServicoFornecedor
    {
        Task<IQueryable<FornecedorVM>> getFornecedores();
        Task<FornecedorVM> getFornecedorId(int id);
        Task<FornecedorIncluirVM> addFornecedor(FornecedorIncluirVM fornecedor);
        Task<FornecedorUpdateVM> updateFornecedor(FornecedorUpdateVM fornecedor);
        Task deleteFornecedor(int id);


    }

    public class ServicoFornecedor : IServicoFornecedor
    {
        private readonly IRepositorioFornecedor repositorioFornecedor;

        public ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor)
        {
            repositorioFornecedor = repositorioFornecedor ?? throw new ArgumentNullException(nameof(repositorioFornecedor));
        }


        public async Task<FornecedorIncluirVM> addFornecedor(FornecedorIncluirVM fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
    
            if (string.IsNullOrWhiteSpace(fornecedor.cnpj)) throw new ArgumentException("CNPJ é obrigatório.", nameof(fornecedor));
            Fornecedor item = new Fornecedor();
            item.id = fornecedor.id;
            item.cnpj = fornecedor.cnpj;
            item.telefone = fornecedor.telefone;
            item.dataCriacao = DateTime.Now;

            await repositorioFornecedor.saveChangesAsync();

            await repositorioFornecedor.addFornecedor(item);

            return fornecedor;
            
        }

        public async Task deleteFornecedor(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            
            await repositorioFornecedor.deleteFornecedor(id);
            await repositorioFornecedor.saveChangesAsync();

        }

        public async Task<IQueryable<FornecedorVM>> getFornecedores()
        {
            IQueryable<Fornecedor> estoques = await repositorioFornecedor.getFornecedores(); 

            return estoques.Select(e => new FornecedorVM
            {
                id = e.id,
                nome = e.nome,
                cnpj = e.cnpj,
                telefone = e.telefone,

            });
        }

        public async Task<FornecedorVM> getFornecedorId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            var item = await repositorioFornecedor.getFornecedorId(id);
            FornecedorVM fornecedor = new FornecedorVM();
            fornecedor.id = item.id;
            fornecedor.nome = item.nome;
            fornecedor.cnpj = item.cnpj;
            fornecedor.telefone = item.telefone;
            return fornecedor ?? throw new KeyNotFoundException($"Fornecedor com Id {id} não encontrado.");
        }

        public async Task<FornecedorUpdateVM> updateFornecedor(FornecedorUpdateVM fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            if (fornecedor.id <= 0) throw new ArgumentException("Id inválido.", nameof(fornecedor));

            Fornecedor item = new Fornecedor();
            item.id = fornecedor.id;
            item.cnpj = fornecedor.cnpj;
            item.telefone = fornecedor.telefone;
            item.nome = fornecedor.nome;
            await repositorioFornecedor.updateFornecedor(item);
            await repositorioFornecedor.saveChangesAsync();
            return fornecedor;

        }




    }
}
