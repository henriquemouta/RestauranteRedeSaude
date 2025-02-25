using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;

namespace Business.Repositorios
{

    public interface IRepositorioFuncionario
    {
        Task<List<FuncionarioVM>> GetFuncionarios();
    }
    public class RepositorioFuncionario(AppDbContext context) : IRepositorioFuncionario
    {
        Task<List<FuncionarioVM>> IRepositorioFuncionario.GetFuncionarios()
        {
            return context.Funcionario.ToListAsync();
        }
    
    }
}
