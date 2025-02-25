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
    public class RepositorioFuncionario(AppDbContext dbContext) : IRepositorioFuncionario
    {
        public async Task<FuncionarioVM> AddFuncionario(FuncionarioVM funcionario)
        {
            dbContext.Funcionario.Add(funcionario);
            await dbContext.SaveChangesAsync();
            return funcionario;
        }

        public async Task DeleteFuncionario(int id)
        {
            var funcionario = dbContext.Funcionario.FirstOrDefault(n => n.id  == id);
            dbContext.Remove(funcionario);
            await dbContext.SaveChangesAsync();
        }   

        public async Task<List<FuncionarioVM>> GetFuncionarios()
        {
            return await dbContext.Funcionario.ToListAsync();
        }

        public async Task<FuncionarioVM> GetFuncionarioId(int id)
        {
            return dbContext.Funcionario.FirstOrDefault(n => n.id == id);
        }

        public async Task UpdateFuncionario(FuncionarioVM funcionario)
        {
            dbContext.Entry(funcionario).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    
    }
}
