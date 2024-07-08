using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoBD;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioReceita : IRepositorioReceita
    {
        private MeuContextoDeDados _db;
        private IRepositorioReceitaIngrediente _repositorioReceitaIngrediente;

        public RepositorioReceita(MeuContextoDeDados db, IRepositorioReceitaIngrediente repositorioReceitaIngrediente)
        {
            _db = db;
            _repositorioReceitaIngrediente = repositorioReceitaIngrediente;
        }

        public List<Receita> ObterTodos(FiltroReceita? receita)
        {
            var receitasFiltradas = Filtrar(receita);
            var listaReceitaIngrediente = _repositorioReceitaIngrediente.ObterTodos();

            receitasFiltradas.ForEach(receita =>
            {
                receita.ListaIdIngrediente = listaReceitaIngrediente
                    .Where(ri => ri.IdReceita == receita.Id)
                    .Select(ri => ri.IdIngredinete)
                    .ToList();
            });
            return receitasFiltradas;
        }
        public List<Receita> ObterTodos()
        {
            var listaReceitas = _db.receita.ToList();
            var listaReceitaIngrediente = _repositorioReceitaIngrediente.ObterTodos();

            listaReceitas.ForEach(receita =>
            {
                receita.ListaIdIngrediente = listaReceitaIngrediente
                    .Where(ri => ri.IdReceita == receita.Id)
                    .Select(ri => ri.IdIngredinete)
                    .ToList();
            });
            return listaReceitas;
        }

        public Receita ObterPorId(int idProcurado)
        {
            var query = from p in _db.receita
                        where (p.Id == idProcurado)
                        select p;

            var resultado = query.FirstOrDefault()
                ?? throw new Exception($"Id: [{idProcurado}] não foi encontrado no banco de dados");
            
            var listaReceitaIngrediente = _repositorioReceitaIngrediente.ObterTodos();

            resultado.ListaIdIngrediente = listaReceitaIngrediente
                .Where(ri => ri.IdReceita == resultado.Id)
                .Select(ri => ri.IdIngredinete)
                .ToList();

            return resultado;
        }

        public int Criar(Receita receita)
        {
            return _db.InsertWithInt32Identity(receita);
        }

        public Receita Editar(Receita receitaEditada)
        {
            var receitaAtualizada = ObterPorId(receitaEditada.Id);

            receitaAtualizada.Nome = receitaEditada.Nome;
            receitaAtualizada.Descricao = receitaEditada.Descricao;
            receitaAtualizada.Valor = receitaEditada.Valor;
            receitaAtualizada.Imagem = receitaEditada.Imagem;
            receitaAtualizada.ValidadeEmMeses = receitaEditada.ValidadeEmMeses;
            receitaAtualizada.ListaIdIngrediente = receitaEditada.ListaIdIngrediente;

            _db.receitaIngrediente
                .Where(ri => ri.IdReceita == receitaEditada.Id)
                .Delete();

            _repositorioReceitaIngrediente.Criar(receitaAtualizada.ListaIdIngrediente, receitaEditada.Id);
            
            _db.Update(receitaAtualizada);
            return receitaAtualizada;
        }

        public void Remover(int idReceita)
        {
            _db.receita
                .Where(p => p.Id == idReceita)
                .Delete();
        }

        public List<Receita> Filtrar(FiltroReceita? receita)
        {
            IQueryable<Receita> query = _db.receita.AsQueryable();

            if (receita is null) return query.ToList();
             
            if (receita.Id is not null)
                query = query.Where(r => r.Id == receita.Id);

            if (!string.IsNullOrWhiteSpace(receita.Nome))
                query = query.Where(r => r.Nome.Contains(receita.Nome));

            if (receita.Valor is not null)
                query = query.Where(r => r.Valor == receita.Valor);

            if (receita.ValidadeEmMeses is not null)
                query = query.Where(r => r.ValidadeEmMeses == receita.ValidadeEmMeses);

            return query.ToList();
        }
    }
}
