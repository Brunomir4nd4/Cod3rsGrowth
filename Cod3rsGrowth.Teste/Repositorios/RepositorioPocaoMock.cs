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

        public Pocao ObterPorId(int idProcurado)
        {
            return listaPocao.Find(objeto => objeto.Id == idProcurado) 
                ?? throw new Exception($"O objeto com id {idProcurado} não foi encontrado");
        }

        public void Criar(Pocao pocao)
        {
            listaPocao.Add(pocao);
        }
    }
}