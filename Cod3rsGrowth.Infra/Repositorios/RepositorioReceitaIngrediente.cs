using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.ConexaoBD;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioReceitaIngrediente : IRepositorioReceitaIngrediente
    {
        private MeuContextoDeDados _db;
        public RepositorioReceitaIngrediente(MeuContextoDeDados db)
        {
            _db = db;
        }
        public List<ReceitaIngrediente> ObterTodos(FiltroReceitaIngrediente filtroReceitaIngrediente)
        {
            var query = from p in _db.receitaIngrediente
                        select p;
            return query.ToList();
        }

        public ReceitaIngrediente ObterPorId(int idProcurado)
        {
            var query = from p in _db.receitaIngrediente
                        where p.Id == idProcurado
                        select p;

            var resultado = query.FirstOrDefault()
                                ?? throw new Exception($"Id: [{idProcurado}] não foi encontrado no banco de dados");

            return resultado;
        }

        public void Criar(List<int> listaIdIngrediente, int idReceita) 
        {
            foreach (var idIngrediente in listaIdIngrediente)
            {
                var receitaIngrediente = new ReceitaIngrediente()
                {
                    IdReceia = idReceita,
                    IdIngredinete = idIngrediente
                };

                _db.Insert(receitaIngrediente);
            }
        }

        public void Remover(ReceitaIngrediente receitaIngrediente)
        {
            _db.receitaIngrediente
                .Where(r => r.Id == receitaIngrediente.Id)
                .Delete();
        }
    }
}
