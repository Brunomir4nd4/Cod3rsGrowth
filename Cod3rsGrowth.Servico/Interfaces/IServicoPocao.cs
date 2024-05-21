using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoPocao
    {
        List<Pocao> ObterTodos();
        void CriarPocao(Pocao pocao);
        void ObterPorldPocao();
        void EditarPocao();
        void RemoverPocao();
    }
}
