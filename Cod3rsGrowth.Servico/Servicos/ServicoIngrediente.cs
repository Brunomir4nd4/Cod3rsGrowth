using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servico.Validadores;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoIngrediente
    {
        private IRepositorioIngrediente _repositorioIngrediente;
        private IngredienteValidator _validator;

        public ServicoIngrediente(IRepositorioIngrediente repositorioIngrediente, IngredienteValidator validator)
        {
            _repositorioIngrediente = repositorioIngrediente;
            _validator = validator;
        }

        public List<Ingrediente> ObterTodos(FiltroIngrediente ingrediente)
        {
            return _repositorioIngrediente.ObterTodos(ingrediente);
        }
        public Ingrediente ObterPorId(int id)
        {
            return _repositorioIngrediente.ObterPorId(id);
        }
        public void CriarIngrediente(Ingrediente ingrediente)
        {
            var validate = _validator.Validate(ingrediente);
            if (!validate.IsValid)
            {
                var erros = string.Join(Environment.NewLine, validate.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            _repositorioIngrediente.Criar(ingrediente);
        }
        public Ingrediente EditarIngrediente(Ingrediente ingredienteEditado)
        {
            var validate = _validator.Validate(ingredienteEditado);
            if (!validate.IsValid)
            {
                var erros = string.Join(Environment.NewLine, validate.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            return _repositorioIngrediente.Editar(ingredienteEditado);
        }
        public void RemoverIngredientes(int idIngredienteSelecionado)
        {
            _repositorioIngrediente.Remover(idIngredienteSelecionado);
        }
    }
}
