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
    }

    public class ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario) : IServicoFuncionario
    {
        Task<List<FuncionarioVM>> IServicoFuncionario.GetFuncionarios()
        {
            return repositorioFuncionario.GetFuncionarios();        }
    }
}
