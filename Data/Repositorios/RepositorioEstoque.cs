using Data.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public interface IRepositorioEstoque
    {
        IQueryable<Estoque> get { get; }
        //Task<Estoque> getEstoqueId(int id);

        void add(Estoque item);

        void update(Estoque item);

        void delete(Estoque item);

        //Task<bool> estoqueExiste(int id);

        Task saveChangesAsync();

    }

    public class RepositorioEstoque : IRepositorioEstoque
    {

        private readonly AppDbContext _dbContext;
        public RepositorioEstoque(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task saveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void add(Estoque item)
        {
            _dbContext.Estoque.Add(item);

        }

        public void delete(Estoque item)
        {
            _dbContext.Estoque.Remove(item);
            //try
            //{
            //    var estoque = await _dbContext.Estoque.FindAsync(id);
            //    if (estoque == null)
            //    {
            //        throw new KeyNotFoundException("Item não encontrado.");
            //    }

            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
        }

        //public async Task<bool> estoqueExiste(int id)
        //{
        //    return await _dbContext.Estoque.AnyAsync(sel => sel.id == id);
        //}

        public IQueryable<Estoque> get
        {
            get { return _dbContext.Estoque.AsNoTracking(); }
        }

        //public async Task<Estoque> getEstoqueId(int id)
        //{
        //    return await _dbContext.Estoque.AsNoTracking().FirstOrDefaultAsync(sel => sel.id == id);
        //}

        public void update(Estoque item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            //try
            //{

            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
        }
    }
}
