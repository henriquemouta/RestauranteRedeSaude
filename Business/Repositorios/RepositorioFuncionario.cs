using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.ViewModels;

namespace Business.Repositorios
{

    public interface IRepositorioFuncionario
    {
        Task<List<FuncionarioVM>> GetFuncionarios();
        Task<FuncionarioVM> GetFuncionarioVM(int id);
      
        Task UpdateFuncionario(FuncionarioVM funcionarioVM);
        Task DeleteFuncionario(int id);
    }
    public class RepositorioFuncionario(AppDbContext context) : IRepositorioFuncionario
    {


        Task IRepositorioFuncionario.DeleteFuncionario(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<FuncionarioVM>> IRepositorioFuncionario.GetFuncionarios()
        {
            return context.Funcionario.ToListAsync();
        }

        Task<FuncionarioVM> IRepositorioFuncionario.GetFuncionarioVM(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepositorioFuncionario.UpdateFuncionario(FuncionarioVM funcionarioVM)
        {
            throw new NotImplementedException();
        }
    }
}
