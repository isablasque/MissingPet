using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepositorio _animalRepositorio;

        public AnimalController(IAnimalRepositorio animalRepositorio)
        {
            _animalRepositorio = animalRepositorio;
        }

        [HttpGet("GetAllAnimal")]
        public async Task<ActionResult<List<AnimalModel>>> GetAllAnimal()
        {
            List<AnimalModel> animall = await _animalRepositorio.GetAll();
            return Ok(animall);
        }

        [HttpGet("GetAnimalId/{id}")]
        public async Task<ActionResult<AnimalModel>> GetAllAnimalId(int id)
        {
            AnimalModel animal = await _animalRepositorio.GetById(id);
            return Ok(animal);
        }

        [HttpPost("InsertAnimal")]
        public async Task<ActionResult<AnimalModel>> InsertAnimal([FromBody] AnimalModel animalModel)
        {
            AnimalModel animal = await _animalRepositorio.InsertAnimal(animalModel);
            return Ok(animal);
        }

        [HttpPut("UpdateAnimal/{id:int}")]
        public async Task<ActionResult<AnimalModel>> UpdateAnimal(int id, [FromBody] AnimalModel animalModel)
        {
            animalModel.AnimalId = id;
            AnimalModel animal = await _animalRepositorio.UpdateAnimal(animalModel, id);
            return Ok(animal);
        }

        [HttpDelete("DeleteAnimal/{id:int}")]
        public async Task<ActionResult<AnimalModel>> DeleteAnimal(int id)
        {
            bool deleted = await _animalRepositorio.DeleteAnimal(id);
            return Ok(deleted);
        }
    }
}