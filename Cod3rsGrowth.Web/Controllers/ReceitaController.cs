
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private ServicoReceita _servicoReceita;

        public ReceitaController()
        {
            CarragarDados();
        }

        private void CarragarDados()
        {
            _servicoReceita = _serviceProvider.GetService<ServicoReceita>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoReceita)}]");
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
           return  Ok(_servicoReceita.ObterTodos(null));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            return  Ok(_servicoReceita.ObterPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Receita receita)
        {
            _servicoReceita.Criar(receita);

            return CreatedAtAction(nameof(ObterPorId), new { Id = receita.Id}, receita);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(Receita receita)
        {
            return Ok(_servicoReceita.Editar(receita));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            _servicoReceita.Remover(id);

            return NoContent();
        }
    }
}
