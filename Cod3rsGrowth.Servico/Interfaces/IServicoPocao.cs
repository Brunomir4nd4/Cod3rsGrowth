using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoPocao
    {
        List<Pocao> ObterTodos();
        Pocao ObterPorId(int id);
        void CriarPocao(Pocao pocao);
        void EditarPocao();
        void RemoverPocao();
    }
}
