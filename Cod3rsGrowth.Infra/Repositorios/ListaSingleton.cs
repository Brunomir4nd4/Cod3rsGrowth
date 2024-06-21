using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static readonly Lazy<ListaSingleton> _instance = 
            new Lazy<ListaSingleton>(() => new ListaSingleton());

        public static ListaSingleton getInstance => _instance.Value;

        public List<FiltroPocao> listaPocao { get; private set; } = new List<FiltroPocao>();
        public List<Ingrediente> listaIngrediente { get; private set; } = new List<Ingrediente>();
        public List<Receita> listaReceita { get; private set; } = new List<Receita>();
    }
}