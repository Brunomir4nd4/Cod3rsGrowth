using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoPocao
    {
        public List<Pocao> ObterTodos();
        public void CriarPocao(Pocao pocao);
        public void ObterPorldPocao();
        public void EditarPocao();
        public void RemoverPocao();
    }
}
