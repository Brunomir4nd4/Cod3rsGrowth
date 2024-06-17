using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoBD;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioPocao : IRepositorioPocao
    {
        private MeuContextoDeDados _db;

        public RepositorioPocao(MeuContextoDeDados db)
        {
            _db = db;
        }

        public List<Pocao> ObterTodos(FiltroPocao pocao)
        {
            var query = Filtrar(pocao);
            return query.ToList();
        }

        public Pocao ObterPorId(int idProcurado)
        {
            var query = from p in _db.pocao
                        where (p.Id == idProcurado)
                        select p;

            var resultado = query.FirstOrDefault()
                ?? throw new Exception($"Id: [{idProcurado}] não foi encontrado no banco de dados");

            return resultado;
        }

        public void Criar(Receita pocao)
        {
            _db.Insert(pocao);
        }

        public void Remover(int idPocao)
        {
            _db.pocao
                .Where(p => p.Id == idPocao)
                .Delete();
        }

        public List<Pocao> Filtrar(FiltroPocao pocao)
        {
            IQueryable<Pocao> query = _db.pocao.AsQueryable();

            if (pocao.Id != null)
                query = query.Where(r => r.Id == pocao.Id);

            if (pocao.IdReceita != null)
                query = query.Where(r => r.IdReceita == pocao.IdReceita);

            if (pocao.DataDeFabricação != null)
                query = query.Where(r => r.DataDeFabricacao == pocao.DataDeFabricação);

            if (pocao.Vencido != null)
                query = query.Where(r => r.Vencido == pocao.Vencido);

            return query.ToList();
        }
    }
}
