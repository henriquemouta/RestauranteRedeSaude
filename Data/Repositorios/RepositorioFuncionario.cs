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
        Task<IQueryable<Funcionario>> getFuncionarios();
        Task<Funcionario> getFuncionarioId(int id);
        Task<Funcionario> addFuncionario(Funcionario funcionario);
        Task updateFuncionario(Funcionario funcionarioVM);
        Task deleteFuncionario(int id);

        Task saveChangesAsync();
    }
    public class RepositorioFuncionario : IRepositorioFuncionario
    {
        private readonly AppDbContext _dbContext;
        public RepositorioFuncionario(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Funcionario> addFuncionario(Funcionario funcionario)
        {
            try
            {
                _dbContext.Funcionario.Add(funcionario);
                await _dbContext.SaveChangesAsync();
                return funcionario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task deleteFuncionario(int id)
        {
            try
            {
                var funcionario = await _dbContext.Funcionario.FindAsync(id);
                if (funcionario == null)
                {
                    throw new KeyNotFoundException("Funcionario não encontrado.");
                }
                _dbContext.Funcionario.Remove(funcionario);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<IQueryable<Funcionario>> getFuncionarios()
        {
            return _dbContext.Funcionario.AsNoTracking();
        }

        public async Task<Funcionario> getFuncionarioId(int id)
        {
            return await _dbContext.Funcionario.AsNoTracking().FirstOrDefaultAsync(n => n.id == id);
        }

        public async Task updateFuncionario(Funcionario funcionario)
        {
            try
            {
                _dbContext.Entry(funcionario).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync(); 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task saveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
