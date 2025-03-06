using Business.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Logging;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewsModels.Prato;


namespace Business.Services
{
    public interface IServicoPrato 
    {
        Task<List<PratoVM>> get();
        Task<PratoVM> getId(int id);
        Task<PratoIncluirVM> add(PratoIncluirVM prato);
        Task<PratoUpdateVM> update(int id, PratoUpdateVM prato);
        Task delete(int id);
    }

    public class ServicoPrato : IServicoPrato
    {
        private readonly IRepositorioPrato repositorioPrato;
        public ServicoPrato(IRepositorioPrato repositorioPrato)
        {
            this.repositorioPrato = repositorioPrato ?? throw new ArgumentNullException(nameof(repositorioPrato));
        }
        public async Task<List<PratoVM>> get()
        {
            IQueryable<Prato> pratos = repositorioPrato.get;
            var lista = await pratos.Select(e => new PratoVM
            {
                id = e.id,
                nome = e.nome,
                preco = e.preco,
                categoria = e.categoria,

            }).ToListAsync();
            return lista;
        }

        public async Task<PratoVM> getId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));

            var prato = await repositorioPrato.get.FirstOrDefaultAsync(obj => obj.id == id);
            PratoVM item = new PratoVM();
            item.id = prato.id;
            item.preco = prato.preco;
            item.nome = prato.nome;
            item.categoria = prato.categoria;
            


            return item ?? throw new KeyNotFoundException($"Prato com Id {id} não encontrado.");
        }

        public async Task delete(int id)
        {
            Prato prato = await repositorioPrato.get.FirstOrDefaultAsync(obj => obj.id == id);
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));

            repositorioPrato.delete(prato);

            await repositorioPrato.saveChangesAsync();
        }

        public async Task<PratoIncluirVM> add(PratoIncluirVM prato)
        {
            if (prato == null) throw new ArgumentNullException(nameof(prato));

            if (string.IsNullOrWhiteSpace(prato.nome)) throw new ArgumentException("Nome é obrigatório.", nameof(prato));


            Prato item = new Prato();
            item.id = prato.id;
            item.preco = prato.preco;
            item.nome = prato.nome;
            item.categoria = prato.categoria;
            item.dataCriacao = DateTime.Now;

            repositorioPrato.add(item);
            await repositorioPrato.saveChangesAsync();
            return prato;
            
        }

        public async Task<PratoUpdateVM> update(int id, PratoUpdateVM prato)
        {
            if (prato == null) throw new ArgumentNullException(nameof(prato));
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(prato));
            Prato item = await repositorioPrato.get.FirstOrDefaultAsync(obj => obj.id == id);

            item.preco = prato.preco;
            item.nome = prato.nome;
            item.categoria = prato.categoria;

            repositorioPrato.update(item);
            await repositorioPrato.saveChangesAsync();
            return prato;
        }
    }
}
