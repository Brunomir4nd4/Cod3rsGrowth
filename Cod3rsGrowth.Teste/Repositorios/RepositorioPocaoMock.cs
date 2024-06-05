using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    public class RepositorioPocaoMock : IRepositorioPocao
    {
        private List<Pocao> _listaPocao = ListaSingleton.getInstance.listaPocao;
        private int _novoId = 0;
        public List<Pocao> ObterTodos()
        {
            return _listaPocao;
        }

        public Pocao ObterPorId(int idProcurado)
        {
            return _listaPocao.Find(objeto => objeto.Id == idProcurado) 
                ?? throw new Exception($"O objeto com id [{idProcurado}] não foi encontrado");
        }

        public void Criar(Receita novaReceita)
        {
            Pocao pocao = new Pocao()
            {
                Id = _novoId,
                IdReceita = novaReceita.Id,
                Vencido = false,
                DataDeFabricação = DateTime.Today
            };
            _novoId++;
            _listaPocao.Add(pocao);
        }

        public void Remover(Pocao pocaoSelecionadaParaRemocao)
        {
            var pocaoRemovidaDoBanco = ObterPorId(pocaoSelecionadaParaRemocao.Id);

            _listaPocao.Remove(pocaoRemovidaDoBanco);
        }
    }
}