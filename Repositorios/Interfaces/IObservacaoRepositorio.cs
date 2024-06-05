using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IObservacaoRepositorio
    {
        Task<List<ObservacaoModel>> GetAll();

        Task<ObservacaoModel> GetById(int id);

        Task<ObservacaoModel> InsertObservacao(ObservacaoModel observacao);

        Task<ObservacaoModel> UpdateObservacao(ObservacaoModel observacao, int id);

        Task<bool> DeleteObservacao(int id);
    }
}
