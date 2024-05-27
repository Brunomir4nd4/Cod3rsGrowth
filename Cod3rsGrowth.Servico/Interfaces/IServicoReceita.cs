using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servico.Interfaces
{
    public interface IServicoReceita
    {
        List<Receita> ObterTodos();
        Receita ObterPorId(int id);
        void CriarReceita(Receita receita);
        void EditarReceita();
        void RemoverReceita();
    }
}
