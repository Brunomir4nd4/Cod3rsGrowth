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
            var receita = ObterPorId(receitaEditada.Id);

            var idIngredientesAnteriores = receita.ListaIdIngrediente;
            var idIngredientesAtuais = receitaEditada.ListaIdIngrediente;

            List<int> idIngredientesParaRemover = idIngredientesAnteriores.Except(idIngredientesAtuais).ToList();
            List<int> idIngredientesParaAdicionar = idIngredientesAtuais.Except(idIngredientesAnteriores).ToList();

            receita.Nome = receitaEditada.Nome;
            receita.Descricao = receitaEditada.Descricao;
            receita.Valor = receitaEditada.Valor;
            receita.Imagem = receitaEditada.Imagem;
            receita.ValidadeEmMeses = receitaEditada.ValidadeEmMeses;
            receita.ListaIdIngrediente = receitaEditada.ListaIdIngrediente;

            RemoverIds(idIngredientesParaRemover);
            SalvarIds(idIngredientesParaAdicionar, receita.Id);
            
            _db.Update(receita);
            return receita;
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

        private void RemoverIds(List<int> idIngredientesParaRemover)
        {
            idIngredientesParaRemover.ForEach(id =>
            {
                _db.receitaIngrediente
                    .Where(ri => ri.IdIngredinete == id)
                    .Delete();
            });
        }
        private void SalvarIds(List<int> idIngredientesParaAdicionar, int idReceita)
        {
            _repositorioReceitaIngrediente.Criar(idIngredientesParaAdicionar, idReceita);
        }
    }
}
