using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interface;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioReceita : IRepositorio<Receita>
    {
        public List<Receita> ObterTodos()
        {
            return ObterTodos();
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
