﻿using Business.Repositorios;
using Data.Data;
using Data.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Logging;
using Models.Entities;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ViewsModels.Estoques;

namespace Business.Services
{
    public interface IServicoEstoque
    {
        Task<List<EstoquesVM>> get();

        Task<EstoquesIncluirVM> add(EstoquesIncluirVM item);
        Task<EstoquesUpdateVM> update(int id, EstoquesUpdateVM item);
        Task<bool> existe(int id);
        Task delete(int id);
        Task<EstoquesVM> getId(int id);
    }

    public class ServicoEstoque : IServicoEstoque
    {
        private readonly IRepositorioEstoque repositorioEstoque;

        public ServicoEstoque(IRepositorioEstoque repositorioEstoque)
        {
            this.repositorioEstoque = repositorioEstoque ?? throw new ArgumentNullException(nameof(repositorioEstoque));
        }
        public async Task<EstoquesIncluirVM> add(EstoquesIncluirVM item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.nome)) throw new ArgumentException("Nome é obrigatorio.", nameof(item));//fazer validacao pelo data annotation

            Estoque estoque = new Estoque();
            estoque.nome = item.nome;
            estoque.id = item.id;
            estoque.quantidade = item.quantidade;
            estoque.categoria = item.categoria;
            estoque.precoUnitario = item.precoUnitario;
            estoque.dataCriacao = DateTime.Now;
            repositorioEstoque.add(estoque);
            await repositorioEstoque.saveChangesAsync();
            return item;
        }

        public async Task delete(int id)
        {
            Estoque estoque = await repositorioEstoque.get.FirstOrDefaultAsync(obj => obj.id == id);
            if (estoque is null) throw new ArgumentException("Id inválido.", nameof(id));
            repositorioEstoque.delete(estoque);
            await repositorioEstoque.saveChangesAsync();
        }

        public async Task<bool> existe(int id)
        {
            return await repositorioEstoque.get.AnyAsync(obj => obj.id == id);
        }

        public async Task<List<EstoquesVM>> get()
        {
            IQueryable<Estoque> estoques = repositorioEstoque.get;

            var lista = await estoques.Select(e => new EstoquesVM
            {
                id = e.id,
                nome = e.nome,
                quantidade = e.quantidade,
                precoUnitario = e.precoUnitario,
                categoria = e.categoria,
            }).ToListAsync();
            return lista;
        }


        public async Task<EstoquesVM> getId(int id)
        {
            Estoque estoque = await repositorioEstoque.get.FirstOrDefaultAsync(obj => obj.id == id);
            if (estoque is null) throw new ArgumentException("Id inválido.", nameof(id));
            EstoquesVM item = new EstoquesVM();
            item.id = id;
            item.nome = estoque.nome;
            item.quantidade = estoque.quantidade;
            item.categoria = estoque.categoria;
            item.precoUnitario = estoque.precoUnitario;

            return item;
        }

        public async Task<EstoquesUpdateVM> update(int id, EstoquesUpdateVM item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            Estoque estoque = await repositorioEstoque.get.FirstOrDefaultAsync(obj => obj.id == id);
            if (estoque is null) throw new ArgumentException("Id inválido.", nameof(id));

            estoque.nome = item.nome;
            estoque.categoria = item.categoria;
            estoque.precoUnitario = item.precoUnitario;


            repositorioEstoque.update(estoque);
            await repositorioEstoque.saveChangesAsync();
            return item;
        }


    }
}
