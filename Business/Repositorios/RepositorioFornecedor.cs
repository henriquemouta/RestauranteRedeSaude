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
        Task<List<FornecedorVM>> getFornecedores();
        Task<FornecedorVM> getFornecedorId(int id);
        Task<FornecedorVM> addFornecedor(FornecedorVM fornecedor);
        Task updateFornecedor(FornecedorVM fornecedorVM);
        Task deleteFornecedor(int id);
    }
    public class RepositorioFornecedor(AppDbContext dbContext) : IRepositorioFornecedor
    {
        public async Task<FornecedorVM> addFornecedor(FornecedorVM fornecedor)
        {
            dbContext.Fornecedor.Add(fornecedor);
            await dbContext.SaveChangesAsync();
            return fornecedor;
        }

        public async Task deleteFornecedor(int id)
        {
            var fornecedor = dbContext.Fornecedor.FirstOrDefault(n => n.ID == id);
            dbContext.Remove(fornecedor);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<FornecedorVM>> getFornecedores()
        {
            return await dbContext.Fornecedor.ToListAsync();
        }

        public async Task<FornecedorVM> getFornecedorId(int id)
        {
            return dbContext.Fornecedor.FirstOrDefault(n => n.ID == id);
        }

        public async Task updateFornecedor(FornecedorVM fornecedor)
        {
            dbContext.Entry(fornecedor).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
