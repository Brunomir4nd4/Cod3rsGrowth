using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servico.Validadores;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoReceita
    {
        private readonly IRepositorioReceita _repositorioReceita;
        private ReceitaValidator _validator;
        public ServicoReceita(IRepositorioReceita repositorioReceita, ReceitaValidator validator)
        {
            _repositorioReceita = repositorioReceita;
            _validator = validator;
        }
        public List<Receita> ObterTodos()
        {
            return _repositorioReceita.ObterTodos();
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

            _repositorioReceita.Criar(receita);
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
        public void RemoverReceita()
        {
        }

    }
}
