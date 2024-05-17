using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Teste.Repositorios
{
    public class RepositorioMock : IRepositorio
    {
        public readonly List<Pocao> pocoes;

        public RepositorioMock()
        {

        }

        public List<Pocao> ObterTodos()
        {
            return pocoes;
        }
    }
}