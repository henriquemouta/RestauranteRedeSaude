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
        Task<List<Funcionario>> getFuncionarios();
        Task<Funcionario> getFuncionarioId(int id);
        Task<Funcionario> addFuncionario(Funcionario funcionario);
        Task updateFuncionar(Funcionario funcionario);
        Task deleteFuncionario(int id);
    }

    public class ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario) : IServicoFuncionario
    {
        public async Task<Funcionario> addFuncionario(Funcionario funcionario)
        {
            return await repositorioFuncionario.addFuncionario(funcionario);
        }

        public async Task deleteFuncionario(int id)
        {
             await repositorioFuncionario.deleteFuncionario(id);
        }

        public async Task<List<Funcionario>> getFuncionarios()
        {
            return await repositorioFuncionario.getFuncionarios();        }

        public async Task<Funcionario> getFuncionarioId(int id)
        {
            return await repositorioFuncionario.getFuncionarioId(id);
        }

        public async Task updateFuncionar(Funcionario funcionario)
        {
            await repositorioFuncionario.updateFuncionario(funcionario);
        }
    }
}
