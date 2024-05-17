namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static readonly Lazy<ListaSingleton>
            lazy = new Lazy<ListaSingleton>(() => new ListaSingleton());

        public static ListaSingleton Instance { get { return lazy.Value; } }

        private ListaSingleton()
        {
        }
    } 
}
