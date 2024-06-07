using Cod3rsGrowth.Dominio.Interface;
using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Repositorios
{
    internal class RepositorioIngrediente : IRepositorio<Ingrediente>
    {
        public List<Ingrediente> ObterTodos()
        {
            var db = new MeuContextoDeDados();
            var query = from p in db.ingrediente
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
