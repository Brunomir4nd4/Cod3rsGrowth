using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class ReceitaValidator : AbstractValidator<Receita>
    {
        public ReceitaValidator() 
        {
            int validadeMinimaEmMeses = 1;
            RuleFor(p => p.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo Nome não preenchido!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$").WithMessage("Campo Nome deve conter apenas letras!");
            RuleFor(p => p.Descricao)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo Descrição não preenchido!")
                .MaximumLength(500).WithMessage("Campo Descrição deve ter no máximo 500 caracters!");
            RuleFor(p => p.Valor)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo Valor não preenchido!")
                .GreaterThan(0).WithMessage("Campo Valor deve ser maior que 0");
            RuleFor(p => p.ValidadeEmMeses)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo Validade Em Meses não preenchido!")
                .GreaterThanOrEqualTo(validadeMinimaEmMeses).WithMessage("Campo Validade em meses deve ser maior ou igual a 1"); 
        }
    }
}
