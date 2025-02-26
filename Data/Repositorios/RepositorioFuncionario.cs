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
        Task<List<Funcionario>> getFuncionarios();
        Task<Funcionario> getFuncionarioId(int id);
        Task<Funcionario> addFuncionario(Funcionario funcionario);
        Task updateFuncionario(Funcionario funcionarioVM);
        Task deleteFuncionario(int id);
    }
    public class RepositorioFuncionario(AppDbContext dbContext) : IRepositorioFuncionario
    {
        public async Task<Funcionario> addFuncionario(Funcionario funcionario)
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

        public async Task<List<Funcionario>> getFuncionarios()
        {
            return await dbContext.Funcionario.ToListAsync();
        }

        public async Task<Funcionario> getFuncionarioId(int id)
        {
            return dbContext.Funcionario.FirstOrDefault(n => n.id == id);
        }

        public async Task updateFuncionario(Funcionario funcionario)
        {
            dbContext.Entry(funcionario).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    
    }
}
