﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels;

namespace Business.Repositorios
{

    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {

    }
    public class RepositorioFuncionario :Repositorio<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario(AppDbContext dbContext) : base(dbContext) { }
    }
}
