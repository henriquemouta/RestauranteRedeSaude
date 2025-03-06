using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public interface IRepositorioEstoque : IRepositorio<Estoque>
    {


    }

    public class RepositorioEstoque : Repositorio<Estoque>, IRepositorioEstoque
    {

        public RepositorioEstoque(AppDbContext dbContext) : base(dbContext) { }

    }
}
