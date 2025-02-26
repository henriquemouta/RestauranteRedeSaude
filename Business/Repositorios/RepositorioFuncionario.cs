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
        Task<List<FuncionarioVM>> getFuncionarios();
        Task<FuncionarioVM> getFuncionarioId(int id);
        Task<FuncionarioVM> addFuncionario(FuncionarioVM funcionario);
        Task updateFuncionario(FuncionarioVM funcionarioVM);
        Task deleteFuncionario(int id);
    }
    public class RepositorioFuncionario(AppDbContext dbContext) : IRepositorioFuncionario
    {
        public async Task<FuncionarioVM> addFuncionario(FuncionarioVM funcionario)
        {
            dbContext.Funcionario.Add(funcionario);
            await dbContext.SaveChangesAsync();
            return funcionario;
        }

        public async Task deleteFuncionario(int id)
        {
            var funcionario = dbContext.Funcionario.FirstOrDefault(n => n.id  == id);
            dbContext.Remove(funcionario);
            await dbContext.SaveChangesAsync();
        }   

        public async Task<List<FuncionarioVM>> getFuncionarios()
        {
            return await dbContext.Funcionario.ToListAsync();
        }

        public async Task<FuncionarioVM> getFuncionarioId(int id)
        {
            return dbContext.Funcionario.FirstOrDefault(n => n.id == id);
        }

        public async Task updateFuncionario(FuncionarioVM funcionario)
        {
            dbContext.Entry(funcionario).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    
    }
}
