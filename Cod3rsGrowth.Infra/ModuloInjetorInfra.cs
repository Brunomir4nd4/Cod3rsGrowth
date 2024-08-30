using Cod3rsGrowth.Infra.ConexaoBD;
using Microsoft.Extensions.DependencyInjection;
using LinqToDB.AspNet;
using LinqToDB;
using LinqToDB.AspNet.Logging;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Dominio.Migradores;
using FluentMigrator.Runner;
using System.Configuration;

namespace Cod3rsGrowth.Infra
{
    public class ModuloInjetorInfra
    {
        private static string _chaveDeConexaoContextoPadrao = "contextoPadrao";
        public static string stringDeConexao = ConfigurationManager.ConnectionStrings[_chaveDeConexaoContextoPadrao].ConnectionString;
        public static void BindServices(IServiceCollection servicos)
        {
            servicos.AddScoped<IRepositorioIngrediente, RepositorioIngrediente>();
            servicos.AddScoped<IRepositorioReceita, RepositorioReceita>();
            servicos.AddScoped<IRepositorioPocao, RepositorioPocao>();
            servicos.AddScoped<IRepositorioReceitaIngrediente, RepositorioReceitaIngrediente>();

            servicos.AddLinqToDBContext<MeuContextoDeDados>((provider, options)
                => options
                    .UseSqlServer(stringDeConexao)
                    .UseDefaultLogging(provider)
                );

            servicos.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(stringDeConexao)
                    .ScanIn(typeof(_20240701115000_MigradorIngrediente).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        }

        public static void AtualizarTabelas(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}