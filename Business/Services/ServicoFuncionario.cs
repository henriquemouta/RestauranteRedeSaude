using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositorios;
using Models.ViewModels;

namespace Business.Services
{
    public interface IServicoFuncionario
    {
        Task<List<FuncionarioVM>> GetFuncionarios();
        Task<FuncionarioVM> GetFuncionarioVM();
        Task<FuncionarioVM> AddFuncionario(FuncionarioVM funcionario);
        Task UpdateFuncionar(FuncionarioVM funcionario);
        Task DeleteFuncionario(int id);
    }

    public class ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario) : IServicoFuncionario
    {
        Task<FuncionarioVM> IServicoFuncionario.AddFuncionario(FuncionarioVM funcionario)
        {
            return repositorioFuncionario.AddFuncionario(funcionario);
        }

        Task IServicoFuncionario.DeleteFuncionario(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<FuncionarioVM>> IServicoFuncionario.GetFuncionarios()
        {
            return repositorioFuncionario.GetFuncionarios();        }

        Task<FuncionarioVM> IServicoFuncionario.GetFuncionarioVM()
        {
            throw new NotImplementedException();
        }

        Task IServicoFuncionario.UpdateFuncionar(FuncionarioVM funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
