using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class IngredienteValidator : AbstractValidator<Ingrediente>
    {
        public IngredienteValidator()
        {
            RuleFor(p => p.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo Nome não preenchido!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$").WithMessage("Campo Nome deve conter apenas letras!");
            RuleFor(p => p.Naturalidade)
                .IsInEnum().WithMessage("Campo Naturalidade é invalido!");
            RuleFor(p => p.Quantidade)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo Quantidade não preenchido!")
                .GreaterThan(0).WithMessage("Campo Quantidade deve ser maior que 0");
        }
    }
}
