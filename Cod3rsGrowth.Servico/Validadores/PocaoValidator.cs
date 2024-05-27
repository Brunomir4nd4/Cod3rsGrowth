using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class PocaoValidator : AbstractValidator<Pocao>
    {
        public PocaoValidator() 
        {
        }

        private bool VatificaSeExisteIngredientesSuficientes(List<Ingrediente> listaIngrediente)
        {
            return true;
        }
    }

}
