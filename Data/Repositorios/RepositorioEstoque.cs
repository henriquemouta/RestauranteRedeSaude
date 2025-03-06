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
      
        }

      

        public IQueryable<Estoque> get
        {
            get { return _dbContext.Estoque.AsNoTracking(); }
        }

     

        public void update(Estoque item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
     
        }
    }
}
