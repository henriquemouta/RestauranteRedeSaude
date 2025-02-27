using Business.Repositorios;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IServicoPrato 
    {
        Task<List<Prato>> getPratos();
        Task<Prato> getPratoId(int id);
        Task<Prato> addPrato(Prato prato);
        Task updatePrato(Prato prato);
        Task deletePrato(int id);
    }

    public class ServicoPrato : IServicoPrato
    {
        private readonly IRepositorioPrato repositorioPrato;
        public ServicoPrato(IRepositorioPrato repositorioPrato)
        {
            this.repositorioPrato = repositorioPrato ?? throw new ArgumentNullException(nameof(repositorioPrato));
        }
        public async Task<List<Prato>> getPratos()
        {
            return await repositorioPrato.getPratos(); 
        }

        public async Task<Prato> getPratoId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            var prato = await repositorioPrato.getPratoId(id);
            return prato ?? throw new KeyNotFoundException($"Prato com Id {id} não encontrado.");
        }

        public async Task deletePrato(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            await repositorioPrato.deletePrato(id);
            await repositorioPrato.saveChangesAsync();
        }

        public async Task<Prato> addPrato(Prato prato)
        {
            if (prato == null) throw new ArgumentNullException(nameof(prato));
            if (string.IsNullOrWhiteSpace(prato.nome)) throw new ArgumentException("Nome é obrigatório.", nameof(prato));
            await repositorioPrato.saveChangesAsync();
            return await repositorioPrato.addPrato(prato);
            
        }

        public async Task updatePrato(Prato prato)
        {
            if (prato == null) throw new ArgumentNullException(nameof(prato));
            if (prato.id <= 0) throw new ArgumentException("Id inválido.", nameof(prato));
            await repositorioPrato.updatePrato(prato);
            await repositorioPrato.saveChangesAsync();
        }
    }
}
