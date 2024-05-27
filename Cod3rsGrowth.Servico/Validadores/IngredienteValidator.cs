using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class IngredienteValidator : AbstractValidator<Ingrediente>
    {
        public IngredienteValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Campo Nome não Preenchido!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$").WithMessage("Campo Nome deve conter apenas letras!");
            RuleFor(p => p.Naturalidade)
                .NotEmpty().WithMessage("Campo não preenchido!")
                .IsInEnum().WithMessage("Campo Naturalidade é invalido!");
        }
    }
}
