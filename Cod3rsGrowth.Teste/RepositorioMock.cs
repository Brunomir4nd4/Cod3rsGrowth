using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Teste
{
    public class RepositorioMock : IRepositorioMock
    {
        public readonly List<Pocao> pocoes;

        public RepositorioMock()
        {

        }

        List<Pocao> IRepositorioMock.ObterTodos()
        {
            return pocoes;
        }
    }
}