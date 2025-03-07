using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Models.Entities;
using Models;
using ViewsModels.Funcionario;

namespace Business.Services
{
    public interface IServicoFuncionario
    {
        Task<List<FuncionarioVM>> get(FuncionarioFiltro filtro);
        Task<FuncionarioVM> getId(int id);
        Task<FuncionarioIncluirVM> add(FuncionarioIncluirVM funcionario);
        Task<FuncionarioUpdateVM> update(int id, FuncionarioUpdateVM funcionario);
        Task delete(int id);
    }

    public class ServicoFuncionario : IServicoFuncionario
    {
        private readonly IRepositorioFuncionario _repositorioFuncionario;
        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario ?? throw new ArgumentNullException(nameof(repositorioFuncionario));
        }
        public async Task<FuncionarioIncluirVM> add(FuncionarioIncluirVM funcionario)
        {
            if (funcionario == null) throw new ArgumentNullException(nameof(funcionario));
            if (string.IsNullOrWhiteSpace(funcionario.nome)) throw new ArgumentException("Nome é obrigatório.", nameof(funcionario));
            Funcionario item = new Funcionario();
            item.id = funcionario.id;
            item.telefone = funcionario.telefone;
            item.nome = funcionario.nome;
            item.cargo = funcionario.cargo;
            item.dataCriacao = DateTime.Now;
            _repositorioFuncionario.add(item);
            await _repositorioFuncionario.saveChangesAsync();
            return funcionario;
            
        }

        public async Task delete(int id)
        {
            Funcionario funcionario = await _repositorioFuncionario.get.FirstOrDefaultAsync(obj => obj.id == id);
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            _repositorioFuncionario.delete(funcionario);
            await _repositorioFuncionario.saveChangesAsync();
        }

        public async Task<List<FuncionarioVM>> get(FuncionarioFiltro filtro)
        {
            IQueryable<Funcionario> funcionarios = _repositorioFuncionario.get;

            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                funcionarios = funcionarios.Where(e => e.nome.Contains(filtro.Nome));
            }

            if (!string.IsNullOrEmpty(filtro.Cargo))
            {
                funcionarios = funcionarios.Where(e => e.cargo.Contains(filtro.Cargo));
            }

            if (!string.IsNullOrEmpty(filtro.Telefone))
            {
                funcionarios = funcionarios.Where(e => e.telefone.Contains(filtro.Telefone));
            }

            var lista = await funcionarios.Select(e => new FuncionarioVM
            {
                id = e.id,
                nome = e.nome,
                cargo = e.cargo,
                telefone = e.telefone,
            }).ToListAsync();

            return lista;
        }


        public async Task<FuncionarioVM> getId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            var funcionario = await _repositorioFuncionario.get.FirstOrDefaultAsync(obj => obj.id == id); ;
            FuncionarioVM item = new FuncionarioVM();
            item.id = funcionario.id;
            item.telefone = funcionario.telefone;
            item.nome = funcionario.nome;
            item.cargo = funcionario.cargo;
            return item ?? throw new KeyNotFoundException($"Funcionario com Id {id} não encontrado.");
            
        }

        public async Task<FuncionarioUpdateVM> update(int id, FuncionarioUpdateVM funcionario)
        {
            if (funcionario == null) throw new ArgumentNullException(nameof(funcionario));
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(funcionario));
            Funcionario item = await _repositorioFuncionario.get.FirstOrDefaultAsync(obj => obj.id == id);
            item.telefone = funcionario.telefone;
            item.nome = funcionario.nome;
            item.cargo = funcionario.cargo;
            _repositorioFuncionario.update(item);
            await _repositorioFuncionario.saveChangesAsync();
            return funcionario;
        }
    }
}
