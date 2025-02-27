using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositorios;
using Microsoft.EntityFrameworkCore.Query;
using Models.ViewModels;

namespace Business.Services
{
    public interface IServicoFuncionario
    {
        Task<IQueryable<Funcionario>> getFuncionarios();
        Task<Funcionario> getFuncionarioId(int id);
        Task<Funcionario> addFuncionario(Funcionario funcionario);
        Task updateFuncionar(Funcionario funcionario);
        Task deleteFuncionario(int id);
    }

    public class ServicoFuncionario : IServicoFuncionario
    {
        private readonly IRepositorioFuncionario _repositorioFuncionario;
        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario ?? throw new ArgumentNullException(nameof(repositorioFuncionario));
        }
        public async Task<Funcionario> addFuncionario(Funcionario funcionario)
        {
            if (funcionario == null) throw new ArgumentNullException(nameof(funcionario));
            if (string.IsNullOrWhiteSpace(funcionario.nome)) throw new ArgumentException("Nome é obrigatório.", nameof(funcionario));
            await _repositorioFuncionario.saveChangesAsync();
            await _repositorioFuncionario.addFuncionario(funcionario);
            return funcionario;
            
        }

        public async Task deleteFuncionario(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            await _repositorioFuncionario.saveChangesAsync();
        }

        public async Task<IQueryable<Funcionario>> getFuncionarios()
        {
            return await _repositorioFuncionario.getFuncionarios();
        }

        public async Task<Funcionario> getFuncionarioId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.", nameof(id));
            var funcionario = await _repositorioFuncionario.getFuncionarioId(id);
            return funcionario ?? throw new KeyNotFoundException($"Funcionario com Id {id} não encontrado.");
            
        }

        public async Task updateFuncionar(Funcionario funcionario)
        {
            if (funcionario == null) throw new ArgumentNullException(nameof(funcionario));
            if (funcionario.id <= 0) throw new ArgumentException("Id inválido.", nameof(funcionario));
            await _repositorioFuncionario.updateFuncionario(funcionario);
            await _repositorioFuncionario.saveChangesAsync();
        }
    }
}
