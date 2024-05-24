using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servico.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoIngrediente : IServicoIngrediente
    {
        private IRepositorioIngrediente _repositorioIngrediente;

        public ServicoIngrediente(IRepositorioIngrediente repositorioIngrediente)
        {
            _repositorioIngrediente = repositorioIngrediente;
        }

        public List<Ingrediente> ObterTodos()
        {
            return _repositorioIngrediente.ObterTodos();
        }
        public Ingrediente ObterPorId(int id)
        {
            return _repositorioIngrediente.ObterPorId(id);
        }
        public void CriarIngrediente(Ingrediente ingrediente)
        {
            _repositorioIngrediente.Criar(ingrediente);
        }
        public void EditarIngrediente()
        {
        }
        public void RemoverIngredientes()
        {
        }
    }
}
