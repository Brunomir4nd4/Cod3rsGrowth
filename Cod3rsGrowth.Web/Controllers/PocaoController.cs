using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PocaoController : ControllerBase
    {
        private ServicoPocao _servicoPocao;
        public PocaoController() 
        {
            CarregarServico();
        }
        private void CarregarServico()
        {
            _servicoPocao = _serviceProvider.GetService<ServicoPocao>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoPocao)}]");
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_servicoPocao.ObterTodos(null));
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            return Ok(_servicoPocao.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult Criar(List<Ingrediente> ingredientes)
        {
            var idPocao = _servicoPocao.Criar(ingredientes);

            return Ok(CreatedAtAction(nameof(ObterPorId), new { id = idPocao }, _servicoPocao.ObterPorId(idPocao)));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            _servicoPocao.Remover(id);

            return NoContent();
        }
    }
}
