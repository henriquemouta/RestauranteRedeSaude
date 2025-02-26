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
    public class RepositorioFornecedor(AppDbContext dbContext) : IRepositorioFornecedor
    {
        public async Task<Fornecedor> addFornecedor(Fornecedor fornecedor)
        {
            dbContext.Fornecedor.Add(fornecedor);
            await dbContext.SaveChangesAsync();
            return fornecedor;
        }

        public async Task deleteFornecedor(int id)
        {
            var fornecedor = dbContext.Fornecedor.FirstOrDefault(n => n.id == id);
            dbContext.Remove(fornecedor);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Fornecedor>> getFornecedores()
        {
            return await dbContext.Fornecedor.ToListAsync();
        }

        public async Task<Fornecedor> getFornecedorId(int id)
        {
            return dbContext.Fornecedor.FirstOrDefault(n => n.id == id);
        }

        public async Task updateFornecedor(Fornecedor fornecedor)
        {
            dbContext.Entry(fornecedor).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
