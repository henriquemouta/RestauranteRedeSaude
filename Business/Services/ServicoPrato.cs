using Business.Repositorios;
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
    
    }

    public class ServicoPrato(IRepositorioPrato repositorioPrato) : IServicoPrato
    {
        public async Task<List<PratoVM>> GetPratos()
        {
            return await repositorioPrato.GetPratos(); 
        }
    }
}
