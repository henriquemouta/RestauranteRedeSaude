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

    public class ServicoPrato(IRepositorioPrato repositorioPrato) : IServicoPrato
    {
        public async Task<List<Prato>> getPratos()
        {
            return await repositorioPrato.getPratos(); 
        }

        public async Task<Prato> getPratoId(int id)
        {
            return await repositorioPrato.getPratoId(id);
        }

        public async Task deletePrato(int id)
        {
            await repositorioPrato.deletePrato(id);
        }

        public async Task<Prato> addPrato(Prato prato)
        {
            return await repositorioPrato.addPrato(prato);  
        }

        public async Task updatePrato(Prato prato)
        {
            await repositorioPrato.updatePrato(prato);
        }
    }
}
