using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    internal class RepositorioReceitaMock : IRepositorioReceita
    {
        public List<Receita> listaReceita = ListaSingleton.getInstance.listaReceita;

        public List<Receita> ObterTodos()
        {
            return listaReceita;
        }

        public Receita ObterPorId(int idProcurado)
        {
            return listaReceita.Find(objeto => objeto.Id == idProcurado)
                ?? throw new Exception($"O objeto com id {idProcurado} não foi encontrado");
        }

        public void Criar(Receita receita)
        {
            listaReceita.Add(receita);
        }
    }
}
