using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static ListaSingleton _instance;

        public List<Pocao> listaPocao {  get; set; }
        public List<Ingrediente> listaIngrediente {  get; set; }
        private ListaSingleton()
        {
            listaPocao = new List<Pocao>();
            listaIngrediente = new List<Ingrediente>();
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
