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

        public List<FiltroPocao> ObterTodos(FiltroPocao? pocao)
        {
            return Filtrar(pocao);
        }
        public List<FiltroPocao> ObterTodos()
        {
            return ObterPocaoComNome();
        }

        public FiltroPocao ObterPorId(int? idProcurado)
        {
            var query = from p in ObterTodos(null)
                        where (p.Id == idProcurado)
                        select p;

            var resultado = query.FirstOrDefault()
                ?? throw new Exception($"Id: [{idProcurado}] não foi encontrado no banco de dados");

            return resultado;
        }

        public int Criar(Receita receita)
        {
            Pocao pocao = new Pocao()
            {
                IdReceita = receita.Id,
                Vencido = false,
                DataDeFabricacao = DateTime.Today
            };
            return _db.InsertWithInt32Identity(pocao);
        }

        public void Remover(int? idPocao)
        {
            _db.pocao
                .Where(p => p.Id == idPocao)
                .Delete();
        }

        public List<FiltroPocao> Filtrar(FiltroPocao? filtroPocao)
        {
            IQueryable<FiltroPocao> query = ObterPocaoComNome().AsQueryable();

            if (filtroPocao is null) return query.ToList();
             
            if (filtroPocao.Id is not null)
                query = query.Where(r => r.Id == filtroPocao.Id);

            if (!string.IsNullOrWhiteSpace(filtroPocao.Nome))
                query = query.Where(p => p.Nome.Contains(filtroPocao.Nome));
                
            if (filtroPocao.DataIncial is not null & filtroPocao.DataFinal is not null)
                query = query
                    .Where(r => r.DataDeFabricacao >= filtroPocao.DataIncial & r.DataDeFabricacao <= filtroPocao.DataFinal);
                
            else if (filtroPocao.DataIncial is not null)
                query = query.Where(r => r.DataDeFabricacao >= filtroPocao.DataIncial);

            if (filtroPocao.Vencido is not null)
                query = query.Where(r => r.Vencido == filtroPocao.Vencido);

            return query.ToList();
        }

        public List<FiltroPocao> ObterPocaoComNome()
        {
            var query = from pocao in _db.pocao
                        join receita in _db.receita on pocao.IdReceita equals receita.Id
                        select new FiltroPocao { 
                            Id = pocao.Id, 
                            IdReceita = pocao.IdReceita, 
                            Nome = receita.Nome,
                            DataDeFabricacao = pocao.DataDeFabricacao, 
                            Vencido = pocao.Vencido 
                        };
            
            return query.ToList();
        }
    }
}
