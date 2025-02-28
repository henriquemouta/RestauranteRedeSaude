using Data.Data;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Business.Repositorios
{

    public interface IRepositorioFornecedor
    {
        Task<IQueryable<Fornecedor>> getFornecedores();
        Task<Fornecedor> getFornecedorId(int id);
        Task<Fornecedor> addFornecedor(Fornecedor fornecedor);
        Task updateFornecedor(Fornecedor fornecedorVM);
        Task deleteFornecedor(int id);

        Task saveChangesAsync();
    }
    public class RepositorioFornecedor : IRepositorioFornecedor
    {
        private readonly AppDbContext _dbContext;
        public RepositorioFornecedor(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Fornecedor> addFornecedor(Fornecedor fornecedor)
        {
            try
            {
                _dbContext.Fornecedor.Add(fornecedor);
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

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public async Task<IQueryable<Fornecedor>> getFornecedores()
        {
            return _dbContext.Fornecedor.AsNoTracking();
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
