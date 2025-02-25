using Data.Data;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositorios
{
    public interface IRepositorioPrato
    {
       Task<List<PratoVM>> GetPratos();

       
    }

    public class RepositorioPrato(AppDbContext dbContext) : IRepositorioPrato
    {
        public async Task<List<PratoVM>> GetPratos()
        {
            return await dbContext.Prato.ToListAsync();
        }
    }
}
