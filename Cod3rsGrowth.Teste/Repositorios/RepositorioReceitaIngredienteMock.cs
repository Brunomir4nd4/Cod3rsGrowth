using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    public class RepositorioReceitaIngredienteMock : IRepositorioReceitaIngrediente
    {
        private List<ReceitaIngrediente> _listaReceitaIngrediente = ListaSingleton.getInstance.listaReceitaIngrediente;
        private int _novoId = 0;
        public List<ReceitaIngrediente> ObterTodos()
        {
            return _listaReceitaIngrediente;
        }

        public ReceitaIngrediente ObterPorId(int idProcurado)
        {
            return _listaReceitaIngrediente.Find(i => i.Id == idProcurado)
                    ?? throw new Exception($"O objeto com id [{idProcurado}] não foi encontrado");
        }

        public void Criar(List<int> listaIdIngrediente, int idReceita)
        {
            foreach (var idIngrediente in listaIdIngrediente)
            {
                var receitaIngrediente = new ReceitaIngrediente()
                {
                    Id = _novoId,
                    IdReceita = idReceita,
                    IdIngredinete = idIngrediente
                };
                _novoId++;
                _listaReceitaIngrediente.Add(receitaIngrediente);
            }
        }

        public void Remover(ReceitaIngrediente receitaIngrediente)
        {
            var receitaIngredienteRemovidaDoBanco = ObterPorId(receitaIngrediente.Id);

            _listaReceitaIngrediente.Remove(receitaIngredienteRemovidaDoBanco);
        }
    }
}
