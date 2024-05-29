using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
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

        public List<Ingrediente> ObterTodos()
        {
            return _repositorioIngrediente.ObterTodos();
        }
        public Ingrediente ObterPorId(int id)
        {
            return _repositorioIngrediente.ObterPorId(id);
        }
        public void CriarIngrediente(Ingrediente ingrediente)
        {
            string erros = "";
            var validate = _validator.Validate(ingrediente);
            if (!validate.IsValid)
            {
                foreach (var erro in validate.Errors)
                {
                    erros += erro.ErrorMessage;
                }
                throw new ValidationException(erros);
            }
            _repositorioIngrediente.Criar(ingrediente);
        }
        public void EditarIngrediente()
        {
        }
        public void RemoverIngredientes()
        {
        }
    }
}
