using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositorios;
using Microsoft.EntityFrameworkCore.Query;
using Models.ViewModels;
using ViewsModels.ViewsModels.Funcionario;

namespace Business.Services
{
    public interface IServicoFuncionario
    {
        Task<IQueryable<FuncionarioVM>> getFuncionarios();
        Task<FuncionarioVM> getFuncionarioId(int id);
        Task<FuncionarioIncluirVM> addFuncionario(FuncionarioIncluirVM funcionario);
        Task<FuncionarioUpdateVM> updateFuncionar(FuncionarioUpdateVM funcionario);
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
            await _repositorioFuncionario.addFuncionario(item);
            await _repositorioFuncionario.saveChangesAsync();
            return funcionario;
            
        }

        public async Task deleteFuncionario(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            await _repositorioFuncionario.saveChangesAsync();
        }

        public async Task<IQueryable<FuncionarioVM>> getFuncionarios()
        {
            var funcionarios = await _repositorioFuncionario.getFuncionarios();
            return funcionarios.Select(e => new FuncionarioVM
            {
                id = e.id,
                nome = e.nome,
                cargo = e.cargo,
                telefone = e.telefone,

            });
        }

        public async Task<FuncionarioVM> getFuncionarioId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            var funcionario = await _repositorioFuncionario.getFuncionarioId(id);
            FuncionarioVM item = new FuncionarioVM();
            item.id = funcionario.id;
            item.telefone = funcionario.telefone;
            item.nome = funcionario.nome;
            item.cargo = funcionario.cargo;
            return item ?? throw new KeyNotFoundException($"Funcionario com Id {id} não encontrado.");
            
        }

        public async Task<FuncionarioUpdateVM> updateFuncionar(FuncionarioUpdateVM funcionario)
        {
            if (funcionario == null) throw new ArgumentNullException(nameof(funcionario));
            if (funcionario.id <= 0) throw new ArgumentException("Id inválido.", nameof(funcionario));
            Funcionario item = new Funcionario();
            item.id = funcionario.id;
            item.telefone = funcionario.telefone;
            item.nome = funcionario.nome;
            item.cargo = funcionario.cargo;
            await _repositorioFuncionario.updateFuncionario(item);
            await _repositorioFuncionario.saveChangesAsync();
            return funcionario;
        }
    }
}
