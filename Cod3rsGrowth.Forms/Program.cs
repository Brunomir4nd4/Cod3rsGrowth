using FluentMigrator.Runner;

using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.Extensions.Hosting;

using Cod3rsGrowth.Dominio.Migradores;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoBD;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validadores;
using LinqToDB.AspNet;
using LinqToDB;
using LinqToDB.AspNet.Logging;

namespace Cod3rsGrowth.Forms
{
    public static class Program
    {
        private static string _chaveDeConexao = "contextoPadrao";
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var ServiceProvider = CreateServices())

            using (var scope = ServiceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
                Application.Run(ServiceProvider.GetRequiredService<FormListagemIngrediente>());
            }
        }
        private static ServiceProvider CreateServices()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[_chaveDeConexao].ToString();
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Migrador).Assembly).For.Migrations())
                    .AddScoped<FormListagemIngrediente>()
                    .AddScoped<ServicoIngrediente>()
                    .AddScoped<IngredienteValidator>()
                    .AddScoped<IRepositorioIngrediente, RepositorioIngrediente>()
                    .AddLinqToDBContext<MeuContextoDeDados>((provider, options)
                        => options
                            .UseSqlServer(ConfigurationManager.ConnectionStrings[_chaveDeConexao].ConnectionString)
                            .UseDefaultLogging(provider))
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
 
    }
}