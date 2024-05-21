using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static ListaSingleton _instance;

        public List<Pocao> listaPocao { get; set; } = new List<Pocao>();
        public List<Ingrediente> listaIngrediente { get; set; } = new List<Ingrediente>();
        private ListaSingleton()
        {
        }

        public static ListaSingleton getInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ListaSingleton();
                }
                return _instance;
            }
        }

    } 
}
