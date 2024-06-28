using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validadores
{
    public class IngredienteValidator : AbstractValidator<Ingrediente>
    {
        public IngredienteValidator()
        {
            const int valorMinimoParaQuantidade = 1;
            RuleFor(p => p.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Campo Nome não preenchido!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$")
                .WithMessage("Campo Nome deve conter apenas letras!");

            RuleFor(p => p.Naturalidade)
                .IsInEnum()
                .WithMessage("Campo Naturalidade é invalido!");

            RuleSet("Criar", () =>
            {
                RuleFor(p => p.Quantidade)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Campo Quantidade não preenchido!")
                    .GreaterThanOrEqualTo(valorMinimoParaQuantidade)
                    .WithMessage("Campo Quantidade deve ser maior ou igual a 1");
            });

            RuleSet("Editar", () =>
            {
                const int valorBaseParaQuantidadeEditada = -1;
                RuleFor(p => p.Quantidade)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Campo Quantidade não preenchido!")
                .GreaterThan(valorBaseParaQuantidadeEditada)
                .WithMessage($"Campo Quantidade deve ser maior que {valorBaseParaQuantidadeEditada}");
            });
        }
    }
}
