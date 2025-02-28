using Business.Repositorios;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Logging;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewsModels.ViewsModels.Estoque;
using ViewsModels.ViewsModels.Fornecedor;
using ViewsModels.ViewsModels.Prato;

namespace Business.Services
{
    public interface IServicoPrato 
    {
        Task<IQueryable<PratoVM>> getPratos();
        Task<PratoVM> getPratoId(int id);
        Task<PratoIncluirVM> addPrato(PratoIncluirVM prato);
        Task<PratoUpdateVM> updatePrato(PratoUpdateVM prato);
        Task deletePrato(int id);
    }

    public class ServicoPrato : IServicoPrato
    {
        private readonly IRepositorioPrato repositorioPrato;
        public ServicoPrato(IRepositorioPrato repositorioPrato)
        {
            this.repositorioPrato = repositorioPrato ?? throw new ArgumentNullException(nameof(repositorioPrato));
        }
        public async Task<IQueryable<PratoVM>> getPratos()
        {
            IQueryable<Prato> pratos = await repositorioPrato.getPratos();
            return pratos.Select(e => new PratoVM
            {
                id = e.id,
                nome = e.nome,
                preco = e.preco,
                categoria = e.categoria,

            });
        }

        public async Task<PratoVM> getPratoId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));

            var prato = await repositorioPrato.getPratoId(id);
            PratoVM item = new PratoVM();
            item.id = prato.id;
            item.preco = prato.preco;
            item.nome = prato.nome;
            item.categoria = prato.categoria;
            


            return item ?? throw new KeyNotFoundException($"Prato com Id {id} não encontrado.");
        }

        public async Task deletePrato(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));

            await repositorioPrato.deletePrato(id);

            await repositorioPrato.saveChangesAsync();
        }

        public async Task<PratoIncluirVM> addPrato(PratoIncluirVM prato)
        {
            if (prato == null) throw new ArgumentNullException(nameof(prato));

            if (string.IsNullOrWhiteSpace(prato.nome)) throw new ArgumentException("Nome é obrigatório.", nameof(prato));


            Prato item = new Prato();
            item.id = prato.id;
            item.preco = prato.preco;
            item.nome = prato.nome;
            item.categoria = prato.categoria;
            item.dataCriacao = DateTime.Now;

            await repositorioPrato.addPrato(item);
            await repositorioPrato.saveChangesAsync();
            return prato;
            
        }

        public async Task<PratoUpdateVM> updatePrato(PratoUpdateVM prato)
        {
            if (prato == null) throw new ArgumentNullException(nameof(prato));
            if (prato.id <= 0) throw new ArgumentException("Id inválido.", nameof(prato));
            Prato item = await repositorioPrato.getPratoId(prato.id);
            item.id = prato.id;
            item.preco = prato.preco;
            item.nome = prato.nome;
            item.categoria = prato.categoria;

            await repositorioPrato.updatePrato(item);
            await repositorioPrato.saveChangesAsync();
            return prato;
        }
    }
}
