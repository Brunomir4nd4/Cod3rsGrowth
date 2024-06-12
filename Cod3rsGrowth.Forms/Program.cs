using FluentMigrator.Runner;

using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Cod3rsGrowth.Forms
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }
        private static ServiceProvider CreateServices()
        {
            // SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["contextoPadrao"]);
            string connectionString = ConfigurationManager.ConnectionStrings["contextoPadrao"].ToString();
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Migrador).Assembly).For.Migrations())
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