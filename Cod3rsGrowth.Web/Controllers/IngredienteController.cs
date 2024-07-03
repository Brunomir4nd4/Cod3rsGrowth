using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private ServicoIngrediente _servicoIngrediente;
        private ILoggerFactory _logger;
        public IngredienteController(ILoggerFactory logger)
        {
            CarregarServico();
            _logger = logger;
        }

        private void CarregarServico()
        {
            _servicoIngrediente = _serviceProvider.GetService<ServicoIngrediente>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoIngrediente)}]");
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(_servicoIngrediente.ObterTodos(null));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            return Ok(_servicoIngrediente.ObterPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Ingrediente ingrediente)
        {
            _servicoIngrediente.Criar(ingrediente);

            return CreatedAtAction(nameof(ObterPorId), new {id = ingrediente.Id }, ingrediente);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(Ingrediente ingrediente)
        {
            return Ok(_servicoIngrediente.Editar(ingrediente));
        }

        [HttpDelete]
        public async Task<IActionResult> Remover(int id)
        {
             _servicoIngrediente.Remover(id);

            return NoContent();
        }
    }
}
