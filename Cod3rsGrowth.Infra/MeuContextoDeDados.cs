using Cod3rsGrowth.Dominio.Entidades;
using LinqToDB;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra
{
    public class MeuContextoDeDados : DataConnection
    {
        public MeuContextoDeDados() : base("contextoPadrao") { }

        public ITable<Pocao> pocao => this.GetTable<Pocao>();
        public ITable<Receita> receita => this.GetTable<Receita>();
        public ITable<Ingrediente> ingrediente => this.GetTable<Ingrediente>();
    }
}
