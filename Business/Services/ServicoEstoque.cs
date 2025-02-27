using Business.Repositorios;
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
        Task<List<EstoqueVM>> getEstoque();
        Task<EstoqueVM> addEstoque(EstoqueVM item);
        Task<EstoqueVM> updateEstoque(EstoqueVM item);
        Task<bool> estoqueExiste(int id);
        Task deleteEstoque(int id);
        Task<EstoqueVM> getEstoqueId(int id);
    }

    public class ServicoEstoque : IServicoEstoque
    {
        private readonly IRepositorioEstoque _repositorioEstoque;

        public ServicoEstoque(IRepositorioEstoque repositorioEstoque)
        {
            _repositorioEstoque = repositorioEstoque ?? throw new ArgumentNullException(nameof(repositorioEstoque));
        }
        public async Task<EstoqueVM> addEstoque(EstoqueVM item)
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
            await _repositorioEstoque.addEstoque(estoque);  
            return item;
        }

        public async Task deleteEstoque(int id)
        {
           if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            await _repositorioEstoque.deleteEstoque(id);
        }

        public async Task<bool> estoqueExiste(int id)
        {
            return await _repositorioEstoque.estoqueExiste(id);
        }

        public async Task<List<EstoqueVM>> getEstoque()
        {
 
            List<Estoque> listaEstoque = await _repositorioEstoque.getEstoque();
            List<EstoqueVM> listaEstoqueVM = listaEstoque
            .Select(e => new EstoqueVM
            {
                id = e.id,
                nome = e.nome,
                quantidade = e.quantidade,
                precoUnitario = e.precoUnitario,
                categoria = e.categoria,
            }).ToList();

            return listaEstoqueVM;

        }

        public async Task<EstoqueVM> getEstoqueId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            var estoque = await _repositorioEstoque.getEstoqueId(id);
            EstoqueVM item = new EstoqueVM();
            item.id = id;
            item.nome = estoque.nome;
            item.quantidade = estoque.quantidade;
            item.categoria = estoque.categoria;
            item.precoUnitario = estoque.precoUnitario;
            
            return item ?? throw new KeyNotFoundException($"Estoque com Id {id} não encontrado.");
        }

        public async Task<EstoqueVM> updateEstoque(EstoqueVM item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (item.id <= 0) throw new ArgumentException("Id inválido.", nameof(item));
            Estoque estoque = new Estoque();
            estoque.id = item.id;
            estoque.nome = item.nome;  
            estoque.categoria = item.categoria;
            estoque.precoUnitario= item.precoUnitario;

            await _repositorioEstoque.updateEstoque(estoque);
            return item;
        }

        
    }
}
