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
        Task<List<PratoVM>> GetPratos();
        Task<PratoVM> GetPratoId(int id);
        Task<PratoVM> AddPrato(PratoVM prato);
        Task UpdatePrato(PratoVM prato);
        Task DeletePrato(int id);

    
    }

    public class ServicoPrato(IRepositorioPrato repositorioPrato) : IServicoPrato
    {
        public async Task<List<PratoVM>> GetPratos()
        {
            return await repositorioPrato.GetPratos(); 
        }

        public async Task<PratoVM> GetPratoId(int id)
        {
            return await repositorioPrato.GetPratoId(id);
        }

        public async Task DeletePrato(int id)
        {
            await repositorioPrato.DeletePrato(id);
        }

        public async Task<PratoVM> AddPrato(PratoVM prato)
        {
            return await repositorioPrato.AddPrato(prato);  
        }

        public async Task UpdatePrato(PratoVM prato)
        {
            await repositorioPrato.UpdatePrato(prato);
        }
    }
}
