using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IAnimalRepositorio
    {
        Task<List<AnimalModel>> GetAll();

        Task<AnimalModel> GetById(int id);

        Task<AnimalModel> InsertAnimal(AnimalModel animal);

        Task<AnimalModel> UpdateAnimal(AnimalModel animal, int id);

        Task<bool> DeleteAnimal(int id);
    }
}
