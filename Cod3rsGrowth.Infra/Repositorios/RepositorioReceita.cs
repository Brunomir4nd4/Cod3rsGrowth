using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoBD;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioReceita : IRepositorioReceita
    {
        private MeuContextoDeDados _db;

        public RepositorioReceita(MeuContextoDeDados db)
        {
            _db = db;
        }

        public List<Receita> ObterTodos(FiltroReceita receita)
        {
            var query = Filtrar(receita);
            return query;
        }

        public Receita ObterPorId(int idProcurado)
        {
            var query = from p in _db.receita
                        where (p.Id == idProcurado)
                        select p;

            var resultado = query.FirstOrDefault()
                ?? throw new Exception($"Id: [{idProcurado}] não foi encontrado no banco de dados");

            return resultado;
        }

        public void Criar(Receita novaReceita)
        {
            _db.Insert(novaReceita);
        }
        public Receita Editar(Receita receitaEditada)
        {
            var receitaAtualizada = ObterPorId(receitaEditada.Id);

            receitaAtualizada.Nome = receitaEditada.Nome;
            receitaAtualizada.Descricao = receitaEditada.Descricao;
            receitaAtualizada.Valor = receitaEditada.Valor;
            receitaAtualizada.Imagem = receitaEditada.Imagem;
            receitaAtualizada.ValidadeEmMeses = receitaEditada.ValidadeEmMeses;
            receitaAtualizada.ListaDeIngredientes = receitaEditada.ListaDeIngredientes;

            _db.Update(receitaAtualizada);
            return receitaAtualizada;
        }

        public void Remover(int idReceita)
        {
            _db.receita
                .Where(p => p.Id == idReceita)
                .Delete();
        }

        public List<Receita> Filtrar(FiltroReceita receita)
        {
            IQueryable<Receita> query = _db.receita.AsQueryable();

            if (receita.Id != null)
                query = query.Where(r => r.Id == receita.Id);

            if (!string.IsNullOrWhiteSpace(receita.Nome))
                query = query.Where(r => r.Nome == receita.Nome);

            if (!string.IsNullOrWhiteSpace(receita.Descricao))
                query = query.Where(r => r.Descricao == receita.Descricao);

            if (receita.Valor != null)
                query = query.Where(r => r.Valor == receita.Valor);

            if (receita.ValidadeEmMeses != null)
                query = query.Where(r => r.ValidadeEmMeses == receita.ValidadeEmMeses);

            return query.ToList();
        }
    }
}
