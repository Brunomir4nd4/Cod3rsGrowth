using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servico.Validadores;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoReceita
    {
        private readonly IRepositorioReceita _repositorioReceita;
        private ServicoReceitaIngrediente _servicoReceitaIngrediente;
        private ReceitaValidator _validator;
        public ServicoReceita(
            IRepositorioReceita repositorioReceita, 
            ReceitaValidator validator,
            ServicoReceitaIngrediente servicoReceitaIngrediente
            )
        {
            _repositorioReceita = repositorioReceita;
            _validator = validator;
            _servicoReceitaIngrediente = servicoReceitaIngrediente;
        }
        public List<Receita> ObterTodos(FiltroReceita receita)
        {
            return _repositorioReceita.ObterTodos(receita);
        }
        public Receita ObterPorId(int id)
        {
            return _repositorioReceita.ObterPorId(id);
        }
        public void CriarReceita(Receita receita)
        {
            var validate = _validator.Validate(receita);
            if (!validate.IsValid)
            {
                var erros = string.Join(Environment.NewLine, validate.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }

            var idReceita = _repositorioReceita.Criar(receita);

            _servicoReceitaIngrediente.Criar(receita.ListaIdIngrediente, idReceita);

        }
        public Receita EditarReceita(Receita receitaEditada)
        {
            var validate = _validator.Validate(receitaEditada);
            if (!validate.IsValid)
            {
                var erros = string.Join(Environment.NewLine, validate.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(erros);
            }
            return _repositorioReceita.Editar(receitaEditada);
        }
        public void RemoverReceita(int idReceitaSelecionada)
        {
            _repositorioReceita.Remover(idReceitaSelecionada);
        }

    }
}
