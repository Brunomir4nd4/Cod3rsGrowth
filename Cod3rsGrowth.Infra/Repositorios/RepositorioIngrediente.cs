using Cod3rsGrowth.Dominio.Interface;
using Cod3rsGrowth.Dominio.Entidades;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioIngrediente : IRepositorio<Ingrediente>
    {
        private MeuContextoDeDados _db;

        public RepositorioIngrediente(MeuContextoDeDados db)
        {
            _db = db;
        }

        public List<Ingrediente> ObterTodos()
        {
            var query = from p in _db.ingrediente
                        where p.Id > 0
                        select p;
            return query.ToList();
        }

        public Ingrediente ObterPorId(int idProcurado)
        {
            return ObterPorId(idProcurado);
        }

        public void Criar(Ingrediente ingrediente)
        {
            _db.Insert(ingrediente);
        }

        public Ingrediente Editar(Ingrediente ingredienteEditado)
        {
            return ingredienteEditado;
        }
        public void Remover(int idIngrediente)
        {

        }
    }
}
