﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;

namespace Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<PratoVM> Prato { get; set; }

        public DbSet<EstoqueVM> Estoque { get; set; }

        public DbSet<FornecedorVM> Fornecedor { get; set; }

        public DbSet<FuncionarioVM> Funcionario { get; set; }


    }

}
