using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Models.Entities;
using Models.ViewModels;
using ViewsModels.ViewsModels.Funcionario;

namespace Business.Services
{
    public interface IServicoFuncionario
    {
        Task<List<FuncionarioVM>> getFuncionarios();
        Task<FuncionarioVM> getFuncionarioId(int id);
        Task<FuncionarioIncluirVM> addFuncionario(FuncionarioIncluirVM funcionario);
        Task<FuncionarioUpdateVM> updateFuncionar(int id, FuncionarioUpdateVM funcionario);
        Task deleteFuncionario(int id);
    }

    public class ServicoFuncionario : IServicoFuncionario
    {
        private readonly IRepositorioFuncionario _repositorioFuncionario;
        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario ?? throw new ArgumentNullException(nameof(repositorioFuncionario));
        }
        public async Task<FuncionarioIncluirVM> addFuncionario(FuncionarioIncluirVM funcionario)
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

        public async Task deleteFuncionario(int id)
        {
            Funcionario funcionario = await _repositorioFuncionario.get.FirstOrDefaultAsync(obj => obj.id == id);
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            _repositorioFuncionario.delete(funcionario);
            await _repositorioFuncionario.saveChangesAsync();
        }

        public async Task<List<FuncionarioVM>> getFuncionarios()
        {
            IQueryable<Funcionario> funcionarios = _repositorioFuncionario.get;
            var lista = await funcionarios.Select(e => new FuncionarioVM
            {
                id = e.id,
                nome = e.nome,
                cargo = e.cargo,
                telefone = e.telefone,

            }).ToListAsync();
            return lista;
        }

        public async Task<FuncionarioVM> getFuncionarioId(int id)
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

        public async Task<FuncionarioUpdateVM> updateFuncionar(int id, FuncionarioUpdateVM funcionario)
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
