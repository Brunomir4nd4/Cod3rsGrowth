using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoReceitaIngrediente
    {
        private IRepositorioReceitaIngrediente _receitaIngrediente;

        public ServicoReceitaIngrediente(IRepositorioReceitaIngrediente receitaIngrediente)
        {
            _receitaIngrediente = receitaIngrediente;
        }

        public List<ReceitaIngrediente> ObterTodos()
        {
            return _receitaIngrediente.ObterTodos();
        }
        public ReceitaIngrediente ObterPorId(int idProcurado)
        {
            return _receitaIngrediente.ObterPorId(idProcurado);
        }

        public void Criar(List<int> listaIdIngrediente, int idReceita)
        {
            _receitaIngrediente.Criar(listaIdIngrediente, idReceita);
        }

        public void Remover(ReceitaIngrediente receitaIngrediente)
        {
            _receitaIngrediente.Remover(receitaIngrediente);
        }
    }
}
