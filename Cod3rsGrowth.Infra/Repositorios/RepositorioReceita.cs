using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interface;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioReceita : IRepositorio<Receita>
    {
        private MeuContextoDeDados _db;

        public RepositorioReceita(MeuContextoDeDados db)
        {
            _db = db;
        }

        public List<Receita> ObterTodos()
        {
            var query = from p in _db.receita
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
            _db.Insert(novaReceita);
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
