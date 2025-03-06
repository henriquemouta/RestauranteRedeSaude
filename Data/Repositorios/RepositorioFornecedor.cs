using Data.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;



namespace Business.Repositorios
{

    public interface IRepositorioFornecedor : IRepositorio<Fornecedor>
    {

    }
    public class RepositorioFornecedor : Repositorio<Fornecedor>, IRepositorioFornecedor
    {
        public RepositorioFornecedor(AppDbContext dbContext) : base(dbContext) { }
    }
}
