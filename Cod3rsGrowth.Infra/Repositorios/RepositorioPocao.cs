using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoBD;
using LinqToDB;
using Microsoft.IdentityModel.Tokens;

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
            List<Pocao> listaPocao = _db.pocao.ToList();
            List<Receita> listaReceita = _db.receita.ToList();
            List<FiltroPocao> listaFiltroPocao = new List<FiltroPocao>();

            for (int i = 0; i < listaPocao.Count(); i++)
            {
                FiltroPocao filtroPocao = new FiltroPocao();

                filtroPocao.Id = listaPocao[i].Id;
                filtroPocao.Vencido = listaPocao[i].Vencido;
                filtroPocao.DataDeFabricacao = listaPocao[i].DataDeFabricacao;

                foreach (var receita in listaReceita)
                {
                    if (receita.Id == listaPocao[i].IdReceita)
                    {
                        filtroPocao.Nome = receita.Nome;
                    }
                }
                listaFiltroPocao.Add(filtroPocao);
            }
            IQueryable<FiltroPocao> query = listaFiltroPocao.AsQueryable();

            if (pocao.Id != null)
                query = query.Where(r => r.Id == pocao.Id);

            if (!string.IsNullOrWhiteSpace(pocao.Nome))
                query = query.Where(p => p.Nome.Contains(pocao.Nome));

            if (pocao.DataDeFabricacao != null)
                query = query.Where(r => r.DataDeFabricacao == pocao.DataDeFabricacao);

            if (pocao.Vencido != null)
                query = query.Where(r => r.Vencido == pocao.Vencido);

            return listaPocao;
        }
    }
}
