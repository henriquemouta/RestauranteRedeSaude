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
        Task<List<FuncionarioVM>> GetFuncionarios();
        Task<FuncionarioVM> GetFuncionarioId(int id);
        Task<FuncionarioVM> AddFuncionario(FuncionarioVM funcionario);
        Task UpdateFuncionar(FuncionarioVM funcionario);
        Task DeleteFuncionario(int id);
    }

    public class ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario) : IServicoFuncionario
    {
        public async Task<FuncionarioVM> AddFuncionario(FuncionarioVM funcionario)
        {
            return await repositorioFuncionario.AddFuncionario(funcionario);
        }

        public async Task DeleteFuncionario(int id)
        {
             await repositorioFuncionario.DeleteFuncionario(id);
        }

        public async Task<List<FuncionarioVM>> GetFuncionarios()
        {
            return await repositorioFuncionario.GetFuncionarios();        }

        public async Task<FuncionarioVM> GetFuncionarioId(int id)
        {
            return await repositorioFuncionario.GetFuncionarioId(id);
        }

        public async Task UpdateFuncionar(FuncionarioVM funcionario)
        {
            await repositorioFuncionario.UpdateFuncionario(funcionario);
        }
    }
}
