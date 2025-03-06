using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositorios
{
    public interface IRepositorioPrato : IRepositorio<Prato>
    {
      
    }

    public class RepositorioPrato :Repositorio<Prato>, IRepositorioPrato
    {
        public RepositorioPrato(AppDbContext context) : base(context) { }
    }
}
