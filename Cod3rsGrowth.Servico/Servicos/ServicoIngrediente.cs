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
        private ServicoReceita _servicoReceita;
        private ServicoReceitaIngrediente _servicoReceitaIngrediente;

        public ServicoIngrediente(
            IRepositorioIngrediente repositorioIngrediente, 
            IngredienteValidator validator, 
            ServicoReceita servicoReceita,
            ServicoReceitaIngrediente servicoReceitaIngrediente
            )
        {
            _validator = validator;
            _repositorioIngrediente = repositorioIngrediente;
            _servicoReceita = servicoReceita;
            _servicoReceitaIngrediente = servicoReceitaIngrediente;
        }

        public List<Ingrediente> ObterTodos(FiltroIngrediente ingrediente)
        {
            return _repositorioIngrediente.ObterTodos(ingrediente);
        }
        public Ingrediente ObterPorId(int id)
        {
            return _repositorioIngrediente.ObterPorId(id);
        }
        public int CriarIngrediente(Ingrediente ingrediente)
        {
            var validate = _validator.Validate(ingrediente);
            if (!validate.IsValid)
            {
                var erros = string.Join(Environment.NewLine, validate.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            return _repositorioIngrediente.Criar(ingrediente);
        }
        public Ingrediente EditarIngrediente(Ingrediente ingredienteEditado)
        {
            var validate = _validator.Validate(ingredienteEditado, options => options.IncludeRuleSets("Editar"));
            if (!validate.IsValid)
            {
                var erros = string.Join(Environment.NewLine, validate.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            return _repositorioIngrediente.Editar(ingredienteEditado);
        }
        public void RemoverIngredientes(int idIngredienteSelecionado)
        {
            var idReceita = _servicoReceitaIngrediente
                .ObterTodos()
                .Where(p => p.IdIngrediente == idIngredienteSelecionado)
                .Select(p => p.IdReceita)
                .First();

            _servicoReceita.RemoverReceita(idReceita);

            _repositorioIngrediente.Remover(idIngredienteSelecionado);
        }
    }
}
