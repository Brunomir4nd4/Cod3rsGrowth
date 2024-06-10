using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interface;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioReceita : IRepositorio<Receita>
    {
        private MeuContextoDeDados _db;

        public RepositorioReceita(MeuContextoDeDados db)
        {
            _db = db;
        }

        public List<Receita> ObterTodos(Receita receita)
        {
            var query = Filtrar(receita);
            return query;
        }

        public Receita ObterPorId(int idProcurado)
        {
            return ObterPorId(idProcurado);
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
            receitaAtualizada.ListaDeIdIngredientes = receitaEditada.ListaDeIdIngredientes;

            _db.Update(receitaAtualizada);
            return receitaAtualizada;
        }

        public void Remover(int idReceita)
        {
        }

        public List<Receita> Filtrar(Receita receita)
        {
            IQueryable<Receita> query = _db.receita.AsQueryable();

            if (receita.Id != 0)
                query = query.Where(r => r.Id == receita.Id);

            if (!string.IsNullOrWhiteSpace(receita.Nome))
                query = query.Where(r => r.Nome == receita.Nome);

            if (!string.IsNullOrWhiteSpace(receita.Descricao))
                query = query.Where(r => r.Descricao == receita.Descricao);

            if (receita.Valor != 0)
                query = query.Where(r => r.Valor == receita.Valor);

            if (receita.ValidadeEmMeses != 0)
                query = query.Where(r => r.ValidadeEmMeses == receita.ValidadeEmMeses);

            return query.ToList();
        }
    }
}
