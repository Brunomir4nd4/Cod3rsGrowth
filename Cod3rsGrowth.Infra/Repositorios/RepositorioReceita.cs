using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoBD;
using Cod3rsGrowth.Servico.Servicos;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioReceita : IRepositorioReceita
    {
        private MeuContextoDeDados _db;
        private ServicoReceitaIngrediente _servicoReceitaIngrediente;

        public RepositorioReceita(MeuContextoDeDados db, ServicoReceitaIngrediente servicoReceitaIngrediente)
        {
            _db = db;
            _servicoReceitaIngrediente = servicoReceitaIngrediente;
        }

        public List<Receita> ObterTodos(FiltroReceita receita)
        {
            var receitasFiltradas = Filtrar(receita);
            var listaReceitaIngrediente = _servicoReceitaIngrediente.ObterTodos();

            receitasFiltradas.ForEach(receita =>
            {
                receita.ListaIdIngrediente = listaReceitaIngrediente
                    .Where(ri => ri.IdReceita == receita.Id)
                    .Select(ri => ri.IdIngredinete)
                    .ToList();
            });
            return receitasFiltradas;
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
                query = query.Where(r => r.Nome.Contains(receita.Nome));

            if (receita.Valor != null)
                query = query.Where(r => r.Valor == receita.Valor);

            if (receita.ValidadeEmMeses != null)
                query = query.Where(r => r.ValidadeEmMeses == receita.ValidadeEmMeses);

            return query.ToList();
        }
    }
}
