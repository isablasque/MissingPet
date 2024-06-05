using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class ObservacaoRepositorio : IObservacaoRepositorio
    {
        private readonly Contexto _dbContext;

        public ObservacaoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ObservacaoModel>> GetAll()
        {
            return await _dbContext.Observacao.ToListAsync();
        }

        public async Task<ObservacaoModel> GetById(int id)
        {
            return await _dbContext.Observacao.FirstOrDefaultAsync(x => x.ObservacaoId == id);
        }

        public async Task<ObservacaoModel> InsertObservacao(ObservacaoModel observacao)
        {
            await _dbContext.Observacao.AddAsync(observacao);
            await _dbContext.SaveChangesAsync();
            return observacao;
        }

        public async Task<ObservacaoModel> UpdateObservacao(ObservacaoModel observacao, int id)
        {
            ObservacaoModel observacaoo = await GetById(id);
            if (observacaoo == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                observacaoo.ObservacaoDescricao = observacao.ObservacaoDescricao;
                observacaoo.ObservacaoLocal = observacao.ObservacaoLocal;
                observacaoo.ObservacaoData = observacao.ObservacaoData;
                observacaoo.AnimalId = observacao.AnimalId;
                observacaoo.UsuarioId = observacao.UsuarioId;

                _dbContext.Observacao.Update(observacaoo);
                await _dbContext.SaveChangesAsync();
            }
            return observacaoo;
        }

        public async Task<bool> DeleteObservacao(int id)
        {
            ObservacaoModel observacaoo = await GetById(id);
            if (observacaoo == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Observacao.Remove(observacaoo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
