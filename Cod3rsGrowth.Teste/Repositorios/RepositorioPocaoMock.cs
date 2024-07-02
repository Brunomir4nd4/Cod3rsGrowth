using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    public class RepositorioPocaoMock : IRepositorioPocao
    {
        private List<FiltroPocao> _listaPocao = ListaSingleton.getInstance.listaPocao;
        private int _novoId = 0;
        public List<FiltroPocao> ObterTodos(FiltroPocao filtroPocao)
        {
            return _listaPocao;
        }

        public FiltroPocao ObterPorId(int? idProcurado)
        {
            return _listaPocao.Find(p => p.Id == idProcurado) 
                ?? throw new Exception($"O objeto com id [{idProcurado}] não foi encontrado");
        }

        public int Criar(Receita novaReceita)
        {
            FiltroPocao pocao = new FiltroPocao()
            {
                Id = _novoId,
                IdReceita = novaReceita.Id,
                Vencido = false,
                DataDeFabricacao = DateTime.Today
            };
            _novoId++;
            _listaPocao.Add(pocao);
            return (int)pocao.Id;
        }

        public void Remover(int? idPocao)
        {
            var pocaoRemovidaDoBanco = ObterPorId(idPocao);

            _listaPocao.Remove(pocaoRemovidaDoBanco);
        }
    }
}