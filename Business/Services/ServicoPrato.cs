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
        Task<List<PratoVM>> getPratos();
        Task<PratoVM> getPratoId(int id);
        Task<PratoVM> addPrato(PratoVM prato);
        Task updatePrato(PratoVM prato);
        Task deletePrato(int id);

    
    }

    public class ServicoPrato(IRepositorioPrato repositorioPrato) : IServicoPrato
    {
        public async Task<List<PratoVM>> getPratos()
        {
            return await repositorioPrato.getPratos(); 
        }

        public async Task<PratoVM> getPratoId(int id)
        {
            return await repositorioPrato.getPratoId(id);
        }

        public async Task deletePrato(int id)
        {
            await repositorioPrato.deletePrato(id);
        }

        public async Task<PratoVM> addPrato(PratoVM prato)
        {
            return await repositorioPrato.addPrato(prato);  
        }

        public async Task updatePrato(PratoVM prato)
        {
            await repositorioPrato.updatePrato(prato);
        }
    }
}
