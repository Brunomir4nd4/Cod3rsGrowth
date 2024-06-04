using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Teste.Repositorios
{
    internal class RepositorioReceitaMock : IRepositorioReceita
    {
        private List<Receita> _listaReceita = ListaSingleton.getInstance.listaReceita;
        private int _novoId = 0;
        public List<Receita> ObterTodos()
        {
            return _listaReceita;
        }

        public Receita ObterPorId(int idProcurado)
        {
            return _listaReceita.Find(objeto => objeto.Id == idProcurado)
                ?? throw new Exception($"O objeto com id {idProcurado} não foi encontrado");
        }

        public void Criar(Receita receita)
        {
            receita.Id = _novoId;
            _novoId++;
            _listaReceita.Add(receita);
        }
        public Receita Editar(Receita receitaEditada)
        {
            int flagIndexNaoEncontrado = -1;
            var indexReceitaEditada = ObterTodos().FindIndex(e => e.Id == receitaEditada.Id) != flagIndexNaoEncontrado
                ?
                ObterTodos().FindIndex(e => e.Id == receitaEditada.Id)
                :
                throw new Exception("Receita informada não encontrada!");

            _listaReceita[indexReceitaEditada] = receitaEditada;
            return _listaReceita[indexReceitaEditada];
        }
    }
}
