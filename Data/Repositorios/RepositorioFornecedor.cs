using Data.Data;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;


namespace Business.Repositorios
{

    public interface IRepositorioFornecedor
    {
        Task<List<Fornecedor>> getFornecedores();
        Task<Fornecedor> getFornecedorId(int id);
        Task<Fornecedor> addFornecedor(Fornecedor fornecedor);
        Task updateFornecedor(Fornecedor fornecedorVM);
        Task deleteFornecedor(int id);
    }
    public class RepositorioFornecedor : IRepositorioFornecedor
    {
        private readonly AppDbContext _dbContext;
        public RepositorioFornecedor(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Fornecedor> addFornecedor(Fornecedor fornecedor)
        { try
            {
                _dbContext.Fornecedor.Add(fornecedor);
                await _dbContext.SaveChangesAsync();
                return fornecedor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task deleteFornecedor(int id)
        {
            try
            {
                var fornecedor = await _dbContext.Fornecedor.FindAsync(id);
                if (fornecedor == null)
                {
                    throw new KeyNotFoundException("Fornecedor não encontrado.");
                }
                _dbContext.Fornecedor.Remove(fornecedor);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<List<Fornecedor>> getFornecedores()
        {
            return await _dbContext.Fornecedor.AsNoTracking().ToListAsync();
        }
        public async Task<Fornecedor> getFornecedorId(int id)
        {
            return await _dbContext.Fornecedor.AsNoTracking().FirstOrDefaultAsync(n => n.id == id);
        }
        public async Task updateFornecedor(Fornecedor fornecedor)
        {
            try
            {
                _dbContext.Entry(fornecedor).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
