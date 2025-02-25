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
        Task<List<FornecedorVM>> GetFornecedores();
        Task<FornecedorVM> GetFornecedorId(int id);
        Task<FornecedorVM> AddFornecedor(FornecedorVM fornecedor);
        Task UpdateFornecedor(FornecedorVM fornecedorVM);
        Task DeleteFornecedor(int id);
    }
    public class RepositorioFornecedor(AppDbContext dbContext) : IRepositorioFornecedor
    {
        public async Task<FornecedorVM> AddFornecedor(FornecedorVM fornecedor)
        {
            dbContext.Fornecedors.Add(fornecedor);
            await dbContext.SaveChangesAsync();
            return fornecedor;
        }

        public async Task DeleteFornecedor(int id)
        {
            var fornecedor = dbContext.Fornecedors.FirstOrDefault(n => n.Id == id);
            dbContext.Remove(fornecedor);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<FornecedorVM>> GetFornecedores()
        {
            return await dbContext.Fornecedors.ToListAsync();
        }

        public async Task<FornecedorVM> GetFornecedorId(int id)
        {
            return dbContext.Fornecedors.FirstOrDefault(n => n.Id == id);
        }

        public async Task UpdateFornecedor(FornecedorVM fornecedor)
        {
            dbContext.Entry(fornecedor).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
