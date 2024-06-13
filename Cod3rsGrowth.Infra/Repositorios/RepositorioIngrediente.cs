using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioIngrediente : IRepositorioIngrediente
    {
        private MeuContextoDeDados _db;

        public RepositorioIngrediente(MeuContextoDeDados db)
        {
            _db = db;
        }

        public List<Ingrediente> ObterTodos(FiltroIngrediente ingrediente)
        {
            var query = Filtrar(ingrediente);
            return query;
        }

        public Ingrediente ObterPorId(int idProcurado)
        {
            var query = from p in _db.ingrediente
                        where (p.Id == idProcurado)
                        select p;

            var resultado = query.FirstOrDefault()
                ?? throw new Exception($"Id: [{idProcurado}] não foi encontrado no banco de dados");

            return resultado;
        }

        public void Criar(Ingrediente ingrediente)
        {
            _db.Insert(ingrediente);
        }

        public Ingrediente Editar(Ingrediente ingredienteEditado)
        {
            var ingredienteAtualizado = ObterPorId(ingredienteEditado.Id);

            ingredienteAtualizado.Nome = ingredienteEditado.Nome;
            ingredienteAtualizado.Quantidade = ingredienteEditado.Quantidade;
            ingredienteAtualizado.Naturalidade = ingredienteEditado.Naturalidade;

            _db.Update(ingredienteAtualizado);
            return ingredienteAtualizado;
        }
        public void Remover(int idIngrediente)
        {
            _db.ingrediente
                .Where(p => p.Id == idIngrediente)
                .Delete();
        }

        public List<Ingrediente> Filtrar(FiltroIngrediente ingrediente)
        {
            IQueryable<Ingrediente> query = _db.ingrediente.AsQueryable();

            if (ingrediente.Id != 0)
                query = query.Where(r => r.Id == ingrediente.Id);

            if (!string.IsNullOrWhiteSpace(ingrediente.Nome))
                query = query.Where(r => r.Nome == ingrediente.Nome);

            if (ingrediente.Quantidade != 0)
                query = query.Where(r => r.Quantidade == ingrediente.Quantidade);

            if (ingrediente.Naturalidade != null)
                query = query.Where(r => r.Naturalidade == ingrediente.Naturalidade);

            return query.ToList();
        }
    }
}
