using Business.Repositorios;
using Data.Data;
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
        Task<List<Estoque>> getEstoque();
        Task<Estoque> addEstoque(Estoque item);
        Task updateEstoque(Estoque item);
        Task<bool> estoqueExiste(int id);
        Task deleteEstoque(int id);
        Task<Estoque> getEstoqueId(int id);
    }

    public class ServicoEstoque : IServicoEstoque
    {
        private readonly IRepositorioEstoque repositorioEstoque;



        public ServicoEstoque(IRepositorioEstoque repositorioEstoque)
        {
            this.repositorioEstoque = repositorioEstoque ?? throw new ArgumentNullException(nameof(repositorioEstoque));
        }
        public async Task<Estoque> addEstoque(Estoque item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.nome)) throw new ArgumentException("Nome é obrigatorio.", nameof(item));

            await repositorioEstoque.saveChangesAsync();

            return await repositorioEstoque.addEstoque(item);
            
            

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

        public async Task<List<Estoque>> getEstoque()
        {
            return await repositorioEstoque.getEstoque();

        }

        public async Task<Estoque> getEstoqueId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            var estoque = await repositorioEstoque.getEstoqueId(id);
            return estoque ?? throw new KeyNotFoundException($"Estoque com Id {id} não encontrado.");
        }

        public async Task updateEstoque(Estoque item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (item.id <= 0) throw new ArgumentException("Id inválido.", nameof(item));
            await repositorioEstoque.updateEstoque(item);
            await repositorioEstoque.saveChangesAsync();

        }

        
    }
}
