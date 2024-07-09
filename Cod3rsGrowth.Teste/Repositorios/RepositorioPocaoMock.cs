using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    public class RepositorioPocaoMock : IRepositorioPocao
    {
        private List<Pocao> _listaPocao = ListaSingleton.getInstance.listaPocao;
        private int _novoId = 0;
        public List<Pocao> ObterTodos(FiltroPocao filtroPocao)
        {
            return _listaPocao;
        }
        public List<Pocao> ObterTodos()
        {
            return _listaPocao;
        }

        public Pocao ObterPorId(int? idProcurado)
        {
            return _listaPocao.Find(p => p.Id == idProcurado) 
                ?? throw new Exception($"O objeto com id [{idProcurado}] não foi encontrado");
        }

        public int Criar(Receita novaReceita)
        {
            Pocao pocao = new Pocao()
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