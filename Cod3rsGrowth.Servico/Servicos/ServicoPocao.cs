using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using Cod3rsGrowth.Servico.Validadores;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoPocao : IServicoPocao
    {
        private readonly IRepositorioPocao _repositorioPocao;
        private PocaoValidator _validator;

        public ServicoPocao(IRepositorioPocao repositorioPocao, PocaoValidator validator)
        {
            _repositorioPocao = repositorioPocao;
            _validator = validator;
        }
        public List<Pocao> ObterTodos()
        {
            return _repositorioPocao.ObterTodos();
        }
        public Pocao ObterPorId(int id)
        {
            return _repositorioPocao.ObterPorId(id);
        }
        public void CriarPocao(Pocao pocao)
        {
            _validator.ValidateAndThrow(pocao);
            _repositorioPocao.Criar(pocao);
        }
        public void RemoverPocao()
        {
        }
    }
}
