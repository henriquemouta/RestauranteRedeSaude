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
        Task<FuncionarioVM> GetFuncionarioId(int id);
        Task<FuncionarioVM> AddFuncionario(FuncionarioVM funcionario);
        Task UpdateFuncionario(FuncionarioVM funcionarioVM);
        Task DeleteFuncionario(int id);
    }
    public class RepositorioFuncionario(AppDbContext context) : IRepositorioFuncionario
    {
        public async Task<FuncionarioVM> AddFuncionario(FuncionarioVM funcionario)
        {
            context.Funcionario.Add(funcionario);
            await context.SaveChangesAsync();
            return funcionario;
        }

        public async Task DeleteFuncionario(int id)
        {
            var funcionario = context.Funcionario.FirstOrDefault(n => n.id  == id);
            context.Remove(funcionario);
            await context.SaveChangesAsync();
        }   

        public async Task<List<FuncionarioVM>> GetFuncionarios()
        {
            return await context.Funcionario.ToListAsync();
        }

        public async Task<FuncionarioVM> GetFuncionarioId(int id)
        {
            return context.Funcionario.FirstOrDefault(n => n.id == id);
        }

        public async Task UpdateFuncionario(FuncionarioVM funcionarioVM)
        {
            context.Entry(funcionarioVM).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    
    }
}
