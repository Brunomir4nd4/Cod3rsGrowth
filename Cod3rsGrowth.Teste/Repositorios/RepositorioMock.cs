using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    public class RepositorioMock : IRepositorio
    {
        public ListaSingleton singleton = ListaSingleton.getInstance;

        public RepositorioMock()  
        {
            Ingrediente ingrediente = new Ingrediente()
            {
                Nome = "Fungus Nether"
            };

            Ingrediente ingrediente2 = new Ingrediente()
            {
                Nome = "Pote com Agua"
            };

            singleton.listaIngrediente.Add(ingrediente);
            singleton.listaIngrediente.Add(ingrediente2);
        }

        public ListaSingleton ObterTodos()
        {
            return singleton;
        }
    }
}