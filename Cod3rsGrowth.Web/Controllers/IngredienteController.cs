using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly ServicoIngrediente _servicoIngrediente;
        private ServiceProvider _serviceProvider;

        public IngredienteController()
        {
            _serviceProvider = ObterServiceCollection().BuildServiceProvider();
            _servicoIngrediente = _serviceProvider.GetRequiredService<ServicoIngrediente>();
        }

        private IServiceCollection ObterServiceCollection()
        {
            var colecaoDeServicos = new ServiceCollection();
            ModuloInjetorServico.BindServices(colecaoDeServicos);
            ModuloInjetorInfra.BindServices(colecaoDeServicos);
            return colecaoDeServicos;
        }


        [HttpGet]
        public async Task<ActionResult<List<Ingrediente>>> GetIngrediente()
        {
            if(_servicoIngrediente.ObterTodos(null) == null)
            {
                return NotFound();
            }
            return _servicoIngrediente.ObterTodos(null);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> GetIngrediente(int id)
        {
            if(_servicoIngrediente.ObterTodos(null) == null)
            {
                return NotFound();
            }
            return _servicoIngrediente.ObterPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Ingrediente>> PostIngrediente(Ingrediente ingrediente)
        {
            _servicoIngrediente.Criar(ingrediente);

            return CreatedAtAction(nameof(GetIngrediente), new {id = ingrediente.Id }, ingrediente);
        }
    }
}
