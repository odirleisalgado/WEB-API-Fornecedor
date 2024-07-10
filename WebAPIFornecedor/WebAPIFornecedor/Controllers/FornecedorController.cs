using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIFornecedor.Models;
using WebAPIFornecedor.Repositories.Interfaces;

namespace WebAPIFornecedor.Controllers
{
    [Authorize]
    [Route("api/Fornecedores")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fornecedor>>> BuscarTodosFornecedores()
        {
            try
            {
                List<Fornecedor> forncedores = await _fornecedorRepository.BuscarTodosAsync();
                return Ok(forncedores);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao buscar todos os fornecedores.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> BuscarPorId(int id)
        {
            try
            {
                return Ok(await _fornecedorRepository.BuscarPorIdAsync(id));
            }
            catch (Exception)
            {
                return NotFound("Id não encontrado.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> Cadastrar([FromBody] Fornecedor fornecedor)
        {
            try
            {
                Fornecedor forncedor = await _fornecedorRepository.AdicionarAsync(fornecedor);
                return Ok(forncedor);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao cadastrar fornecedor.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Fornecedor>> Atualizar([FromBody] Fornecedor fornecedor, int id)
        {
            try
            {
                fornecedor.Id = id;
                Fornecedor forncedor = await _fornecedorRepository.AtualizarAsync(fornecedor, id);
                return Ok(forncedor);
            }
            catch (Exception)
            {
                return NotFound("Erro ao atualizar fornecedor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Fornecedor>> Remover(int id)
        {
            try
            {
                bool apagado = await _fornecedorRepository.RemoverAsync(id);
                return Ok(apagado);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao remover fornecedor.");
            }
        }
    }
}
