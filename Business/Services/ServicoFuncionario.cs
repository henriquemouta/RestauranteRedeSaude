using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositorios;
using Microsoft.EntityFrameworkCore.Query;
using Models.ViewModels;

namespace Business.Services
{
    public interface IServicoFuncionario
    {
        Task<List<FuncionarioVM>> getFuncionarios();
        Task<FuncionarioVM> getFuncionarioId(int id);
        Task<FuncionarioVM> addFuncionario(FuncionarioVM funcionario);
        Task updateFuncionar(FuncionarioVM funcionario);
        Task deleteFuncionario(int id);
    }

    public class ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario) : IServicoFuncionario
    {
        public async Task<FuncionarioVM> addFuncionario(FuncionarioVM funcionario)
        {
            return await repositorioFuncionario.addFuncionario(funcionario);
        }

        public async Task deleteFuncionario(int id)
        {
             await repositorioFuncionario.deleteFuncionario(id);
        }

        public async Task<List<FuncionarioVM>> getFuncionarios()
        {
            return await repositorioFuncionario.getFuncionarios();        }

        public async Task<FuncionarioVM> getFuncionarioId(int id)
        {
            return await repositorioFuncionario.getFuncionarioId(id);
        }

        public async Task updateFuncionar(FuncionarioVM funcionario)
        {
            await repositorioFuncionario.updateFuncionario(funcionario);
        }
    }
}
