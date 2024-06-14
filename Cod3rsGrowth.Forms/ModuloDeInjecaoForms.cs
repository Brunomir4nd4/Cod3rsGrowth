using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoBD;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validadores;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public class ModuloDeInjecaoForms
    {
        public static void BindServices(ServiceCollection servicos) 
        {
            servicos.AddScoped<FormListagemIngrediente>();
            servicos.AddScoped<ServicoIngrediente>();
            servicos.AddScoped<IngredienteValidator>();
            servicos.AddScoped<MeuContextoDeDados>();
            servicos.AddScoped<IRepositorioIngrediente, RepositorioIngrediente>();
        }
    }
}
