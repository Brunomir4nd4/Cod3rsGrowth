using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interface;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioPocao
    {
        public List<Pocao> ObterTodos()
        {
            var db = new MeuContextoDeDados();
            var query = from p in db.pocao
                        where p.Id > 0
                        select p;
            return query.ToList();
        }

        public Pocao ObterPorId(int idProcurado)
        {
            return ObterPorId(idProcurado);
        }

        public void Criar(Receita novaReceita)
        {
        }

        public void Remover(int idPocao)
        {
        }
    }
}
