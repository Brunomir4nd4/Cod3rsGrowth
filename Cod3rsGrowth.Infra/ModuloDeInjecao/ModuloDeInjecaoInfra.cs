using Cod3rsGrowth.Infra.ConexaoBD;
using Microsoft.Extensions.DependencyInjection;
using LinqToDB.AspNet;
using LinqToDB;
using System.Configuration;
using LinqToDB.AspNet.Logging;

namespace Cod3rsGrowth.Infra.ModuloDeInjecao
{
    public class ModuloDeInjecaoInfra
    {
        public static void BindServices(ServiceCollection servicos)
        {
            servicos.AddLinqToDBContext<MeuContextoDeDados>((provider, options)
                => options
                    .UseSqlServer(ConfigurationManager.ConnectionStrings["contextoPadrao"].ConnectionString)
                    .UseDefaultLogging(provider)
                    );
        }
    }
}