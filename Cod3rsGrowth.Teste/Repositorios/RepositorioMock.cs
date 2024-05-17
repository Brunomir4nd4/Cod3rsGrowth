using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Teste.Repositorios
{
    public class RepositorioMock : IRepositorio
    {
        public readonly List<Pocao> pocoes;

        public RepositorioMock()
        {
            var pocao = new Pocao();
            pocao.Id = 0;
            pocoes.Add(pocao);
        }

        public List<Pocao> ObterTodos()
        {
            return pocoes;
        }
    }
}