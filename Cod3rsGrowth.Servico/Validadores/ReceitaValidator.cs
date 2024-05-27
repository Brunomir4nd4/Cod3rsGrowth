using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class ReceitaValidator : AbstractValidator<Receita>
    {
        public ReceitaValidator() 
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Campo Nome não preenchido!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$").WithMessage("Campo Nome Deve conter apenas letras!");
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("Campo Descrição não preenchido!")
                .MaximumLength(30).WithMessage("Campo Descrição deve ter no máximo 30 caracters!");
            RuleFor(p => p.Valor)
                .NotEmpty().WithMessage("Campo Valor não preenchido!")
                .PrecisionScale(5, 2, false).WithMessage("Campo Valor não pode execeder 3 digitos inteiros e 2 decimais!");
        }
    }
}
