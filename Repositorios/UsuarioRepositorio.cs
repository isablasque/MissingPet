﻿using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _dbContext;

        public UsuarioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<UsuarioModel> Login( string email, string password )
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioEmail == email && x.UsuarioSenha == password);
        }

        public async Task<UsuarioModel> InsertUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> UpdateUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioo = await GetById(id);
            if (usuarioo == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                usuarioo.UsuarioNome = usuario.UsuarioNome;
                usuarioo.UsuarioTelefone = usuario.UsuarioTelefone;
                usuarioo.UsuarioEmail = usuario.UsuarioEmail;
                usuarioo.UsuarioSenha = usuario.UsuarioSenha;

                _dbContext.Usuario.Update(usuarioo);
                await _dbContext.SaveChangesAsync();
            }
            return usuarioo;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            UsuarioModel usuarioo = await GetById(id);
            if (usuarioo == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Usuario.Remove(usuarioo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
