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

        public Pocao ObterPorId(int id)
        {
            int i;
            for (i = 0; i < listaPocao.Count; i++)
            {
                if (listaPocao[i].Id ==  id)
                {
                    break;
                }
            }
            return listaPocao[i];
        }

        public void Criar(Pocao pocao)
        {
            listaPocao.Add(pocao);
        }
    }
}