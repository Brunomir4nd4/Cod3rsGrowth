using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    public class RepositorioPocaoMock : IRepositorioPocao
    {
        public List<Pocao> listaPocao = ListaSingleton.getInstance.listaPocao;

        public List<Pocao> ObterTodos()
        {
            return listaPocao;
        }

        public void Criar(Pocao pocao)
        {
            listaPocao.Add(pocao);
        }
    }
}