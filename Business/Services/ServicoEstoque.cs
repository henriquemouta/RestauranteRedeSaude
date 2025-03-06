using Business.Repositorios;
using Data;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Logging;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ViewsModels.ViewsModels.Estoque;

namespace Business.Services
{
    public interface IServicoEstoque
    {
        Task<IQueryable<EstoqueVM>> getEstoque();

        Task<EstoqueIncluirVM> addEstoque(EstoqueIncluirVM item);
        Task<EstoqueUpdateVM> updateEstoque(EstoqueUpdateVM item);
        Task<bool> estoqueExiste(int id);
        Task deleteEstoque(int id);
        Task<EstoqueVM> getEstoqueId(int id);
    }

    public class ServicoEstoque : IServicoEstoque
    {
        private readonly IRepositorioEstoque repositorioEstoque;



        public ServicoEstoque(IRepositorioEstoque repositorioEstoque)
        {
            this.repositorioEstoque = repositorioEstoque ?? throw new ArgumentNullException(nameof(repositorioEstoque));
        }
        public async Task<EstoqueIncluirVM> addEstoque(EstoqueIncluirVM item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.nome)) throw new ArgumentException("Nome é obrigatorio.", nameof(item));

            Estoque estoque = new Estoque();
            estoque.nome = item.nome;
            estoque.id = item.id;
            estoque.quantidade = item.quantidade;
            estoque.categoria = item.categoria;
            estoque.precoUnitario = item.precoUnitario;
            estoque.dataCriacao = DateTime.Now;
            await repositorioEstoque.addEstoque(estoque);
            await repositorioEstoque.saveChangesAsync();
            return item;
        }

        public async Task deleteEstoque(int id)
        {
           if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            await repositorioEstoque.deleteEstoque(id);
            await repositorioEstoque.saveChangesAsync();
        }

        public async Task<bool> estoqueExiste(int id)
        {
            return await repositorioEstoque.estoqueExiste(id);
        }

        public async Task<IQueryable<EstoqueVM>> getEstoque()
        {
            IQueryable<Estoque> estoques = await repositorioEstoque.getEstoque(); 

            return estoques.Select(e => new EstoqueVM
            {
                id = e.id,
                nome = e.nome,
                quantidade = e.quantidade,
                precoUnitario = e.precoUnitario,
                categoria = e.categoria,
            });
        }


        public async Task<EstoqueVM> getEstoqueId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            var estoque = await repositorioEstoque.getEstoqueId(id);
            EstoqueVM item = new EstoqueVM();
            item.id = id;
            item.nome = estoque.nome;
            item.quantidade = estoque.quantidade;
            item.categoria = estoque.categoria;
            item.precoUnitario = estoque.precoUnitario;
            
            return item ?? throw new KeyNotFoundException($"Estoque com Id {id} não encontrado.");
        }

        public async Task<EstoqueUpdateVM> updateEstoque(EstoqueUpdateVM item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (item.id <= 0) throw new ArgumentException("Id inválido.", nameof(item));
           
            

            Estoque estoque = await repositorioEstoque.getEstoqueId(item.id);
            estoque.id = item.id;
            estoque.nome = item.nome;  
            estoque.categoria = item.categoria;
            estoque.precoUnitario= item.precoUnitario;


            await repositorioEstoque.updateEstoque(estoque);
            await repositorioEstoque.saveChangesAsync();
            return item;
        }

        
    }
}
