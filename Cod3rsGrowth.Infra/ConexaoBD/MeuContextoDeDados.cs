using Cod3rsGrowth.Dominio.Entidades;
using LinqToDB;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra.ConexaoBD
{
    public class MeuContextoDeDados : DataConnection
    {
        public MeuContextoDeDados(DataOptions<MeuContextoDeDados> options)
            : base(options.Options) { }

        public ITable<Pocao> pocao => this.GetTable<Pocao>();
        public ITable<Receita> receita => this.GetTable<Receita>();
        public ITable<Ingrediente> ingrediente => this.GetTable<Ingrediente>();
        public ITable<ReceitaIngrediente> receitaIngrediente => this.GetTable<ReceitaIngrediente>();
    }
}