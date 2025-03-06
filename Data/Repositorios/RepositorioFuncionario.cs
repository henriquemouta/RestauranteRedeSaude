using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;

namespace Business.Repositorios
{

    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {

    }
    public class RepositorioFuncionario :Repositorio<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario(AppDbContext dbContext) : base(dbContext) { }
    }
}
