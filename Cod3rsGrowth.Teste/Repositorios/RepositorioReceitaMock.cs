using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    internal class RepositorioReceitaMock : IRepositorioReceita
    {
        private List<Receita> _listaReceita = ListaSingleton.getInstance.listaReceita;
        private int _novoId = 0;
        public List<Receita> ObterTodos(FiltroReceita receita)
        {
            return _listaReceita;
        }
        public List<Receita> ObterTodos()
        {
            return _listaReceita;
        }

        public Receita ObterPorId(int idProcurado)
        {
            return _listaReceita.Find(r => r.Id == idProcurado)
                ?? throw new Exception($"O objeto com id [{idProcurado}] não foi encontrado");
        }

        public int Criar(Receita novaReceita)
        {
            novaReceita.Id = _novoId;
            _novoId++;
            _listaReceita.Add(novaReceita);
            return novaReceita.Id;
        }
        public Receita Editar(Receita receitaEditada)
        {
            var receitaDoBanco = ObterPorId(receitaEditada.Id);

            receitaDoBanco.Nome = receitaEditada.Nome;
            receitaDoBanco.Descricao = receitaEditada.Descricao;
            receitaDoBanco.ValidadeEmMeses = receitaEditada.ValidadeEmMeses;
            receitaDoBanco.Valor = receitaEditada.Valor;
            receitaDoBanco.Imagem = receitaEditada.Imagem;
            receitaDoBanco.ListaIdIngrediente = receitaEditada.ListaIdIngrediente;

            return receitaDoBanco;
        }

        public void Remover(int idReceita)
        {
            var receitaRemovidaDoBanco = ObterPorId(idReceita);

            _listaReceita.Remove(receitaRemovidaDoBanco);
        }
    }
}
