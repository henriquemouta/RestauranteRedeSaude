using Business.Repositorios;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewsModels.ViewsModels.Fornecedor;

namespace Business.Services
{
    public interface IServicoFornecedor
    {
        Task<List<FornecedorVM>> get();
        Task<FornecedorVM> getId(int id);
        Task<FornecedorIncluirVM> add(FornecedorIncluirVM fornecedor);
        Task<FornecedorUpdateVM> update(int id, FornecedorUpdateVM fornecedor);
        Task delete(int id);


    }

    public class ServicoFornecedor : IServicoFornecedor
    {
        private readonly IRepositorioFornecedor repositorioFornecedor;

        public ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor)
        {
            repositorioFornecedor = repositorioFornecedor ?? throw new ArgumentNullException(nameof(repositorioFornecedor));
        }


        public async Task<FornecedorIncluirVM> add(FornecedorIncluirVM fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
    
            if (string.IsNullOrWhiteSpace(fornecedor.cnpj)) throw new ArgumentException("CNPJ é obrigatório.", nameof(fornecedor));
            Fornecedor item = new Fornecedor();
            item.id = fornecedor.id;
            item.nome = fornecedor.nome;
            item.cnpj = fornecedor.cnpj;
            item.telefone = fornecedor.telefone;
            item.dataCriacao = DateTime.Now;

           

            repositorioFornecedor.add(item);
            await repositorioFornecedor.saveChangesAsync();
            return fornecedor;
            
        }

        public async Task delete(int id)
        {
            Fornecedor fornecedor = await repositorioFornecedor.get.FirstOrDefaultAsync(obj => obj.id == id);
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            repositorioFornecedor.delete(fornecedor);
            await repositorioFornecedor.saveChangesAsync();

        }

        public async Task<List<FornecedorVM>> get()
        {
            IQueryable<Fornecedor> fornecedors = repositorioFornecedor.get;

            var lista = await fornecedors.Select(e => new FornecedorVM
            {
                id = e.id,
                nome = e.nome,
                cnpj = e.cnpj,
                telefone = e.telefone,

            }).ToListAsync();
            return lista;
        }

        public async Task<FornecedorVM> getId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            var item = await repositorioFornecedor.get.FirstOrDefaultAsync(obj => obj.id == id);
            FornecedorVM fornecedor = new FornecedorVM();
            fornecedor.id = item.id;
            fornecedor.nome = item.nome;
            fornecedor.cnpj = item.cnpj;
            fornecedor.telefone = item.telefone;
            
            return fornecedor ?? throw new KeyNotFoundException($"Fornecedor com Id {id} não encontrado.");
        }

        public async Task<FornecedorUpdateVM> update(int id, FornecedorUpdateVM fornecedor)
        {
            if (fornecedor == null) throw new ArgumentNullException(nameof(fornecedor));
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(fornecedor));

            Fornecedor item = await repositorioFornecedor.get.FirstOrDefaultAsync(obj => obj.id == id);


            item.cnpj = fornecedor.cnpj;
            item.telefone = fornecedor.telefone;
            item.nome = fornecedor.nome;
          
            repositorioFornecedor.update(item);
            await repositorioFornecedor.saveChangesAsync();
            return fornecedor;

        }




    }
}
