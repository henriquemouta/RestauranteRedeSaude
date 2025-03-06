using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.ViewModels;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Prato> Prato { get; set; }

        public DbSet<Estoque> Estoque { get; set; }

        public DbSet<Fornecedor> Fornecedor { get; set; }

        public DbSet<Funcionario> Funcionario { get; set; }


    }

}
