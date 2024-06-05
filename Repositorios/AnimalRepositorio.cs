using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class AnimalRepositorio : IAnimalRepositorio
    {
        private readonly Contexto _dbContext;

        public AnimalRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AnimalModel>> GetAll()
        {
            return await _dbContext.Animal.ToListAsync();
        }

        public async Task<AnimalModel> GetById(int id)
        {
            return await _dbContext.Animal.FirstOrDefaultAsync(x => x.AnimalId == id);
        }

        public async Task<AnimalModel> InsertAnimal(AnimalModel animal)
        {
            await _dbContext.Animal.AddAsync(animal);
            await _dbContext.SaveChangesAsync();
            return animal;
        }

        public async Task<AnimalModel> UpdateAnimal(AnimalModel animal, int id)
        {
            AnimalModel animall = await GetById(id);
            if (animall == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                animall.AnimalNome = animal.AnimalNome;
                animall.AnimalRaca = animal.AnimalRaca;
                animall.AnimalTipo = animal.AnimalTipo;
                animall.AnimalCor = animal.AnimalCor;
                animall.AnimalSexo = animal.AnimalSexo;
                animall.AnimalObservacao = animal.AnimalObservacao;
                animall.AnimalFoto = animal.AnimalFoto;
                animall.AnimalDtDesaparecimento = animal.AnimalDtDesaparecimento;
                animall.AnimalDtEncontro = animal.AnimalDtEncontro;
                animall.AnimalStatus = animal.AnimalStatus;
                animall.UsuarioId = animal.UsuarioId;

                _dbContext.Animal.Update(animall);
                await _dbContext.SaveChangesAsync();
            }
            return animall;
        }

        public async Task<bool> DeleteAnimal(int id)
        {
            AnimalModel animall = await GetById(id);
            if (animall == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Animal.Remove(animall);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
