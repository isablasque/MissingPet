using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacaoController : ControllerBase
    {
        private readonly IObservacaoRepositorio _observacaoRepositorio;

        public ObservacaoController(IObservacaoRepositorio observacaoRepositorio)
        {
            _observacaoRepositorio = observacaoRepositorio;
        }

        [HttpGet("GetAllObservacao")]
        public async Task<ActionResult<List<ObservacaoModel>>> GetAllObservacao()
        {
            List<ObservacaoModel> observacaoo = await _observacaoRepositorio.GetAll();
            return Ok(observacaoo);
        }

        [HttpGet("GetObservacaoId/{id}")]
        public async Task<ActionResult<ObservacaoModel>> GetAllObservacaoId(int id)
        {
            ObservacaoModel observacao = await _observacaoRepositorio.GetById(id);
            return Ok(observacao);
        }

        [HttpPost("InsertObservacao")]
        public async Task<ActionResult<ObservacaoModel>> InsertObservacao([FromBody] ObservacaoModel observacaoModel)
        {
            ObservacaoModel observacao = await _observacaoRepositorio.InsertObservacao(observacaoModel);
            return Ok(observacao);
        }

        [HttpPut("UpdateObservacao/{id:int}")]
        public async Task<ActionResult<ObservacaoModel>> UpdateObservacao(int id, [FromBody] ObservacaoModel observacaoModel)
        {
            observacaoModel.ObservacaoId = id;
            ObservacaoModel observacao = await _observacaoRepositorio.UpdateObservacao(observacaoModel, id);
            return Ok(observacao);
        }

        [HttpDelete("DeleteObservacao/{id:int}")]
        public async Task<ActionResult<ObservacaoModel>> DeleteObservacao(int id)
        {
            bool deleted = await _observacaoRepositorio.DeleteObservacao(id);
            return Ok(deleted);
        }
    }
}
