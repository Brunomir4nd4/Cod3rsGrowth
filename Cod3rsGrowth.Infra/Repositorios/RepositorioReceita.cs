using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interface;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioReceita : IRepositorio<Receita>
    {
        public List<Receita> ObterTodos()
        {
            var db = new MeuContextoDeDados();
            var query = from p in db.receita
                        where p.Id > 0
                        select p;
            return query.ToList();
        }

        public Receita ObterPorId(int idProcurado)
        {
            return ObterPorId(idProcurado);
        }

        public void Criar(Receita novaReceita)
        {
        }
        public Receita Editar(Receita receitaEditada)
        {
            return receitaEditada;
        }

        public void Remover(int idReceita)
        {
        }
    }
}
