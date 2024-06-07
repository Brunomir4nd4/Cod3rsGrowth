using Cod3rsGrowth.Dominio.Entidades;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioPocao
    {
        private MeuContextoDeDados _db;

        public RepositorioPocao(MeuContextoDeDados db)
        {
            _db = db;
        }

        public List<Pocao> ObterTodos()
        {
            var query = from p in _db.pocao
                        where p.Id > 0
                        select p;
            return query.ToList();
        }

        public Pocao ObterPorId(int idProcurado)
        {
            return ObterPorId(idProcurado);
        }

        public void Criar(Receita pocao)
        {
            _db.Insert(pocao);
        }

        public void Remover(int idPocao)
        {
        }
    }
}
