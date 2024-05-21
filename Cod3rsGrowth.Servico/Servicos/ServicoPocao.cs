using Cod3rsGrowth.Servico.Interfaces;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoPocao : IServicoPocao
    {
        private readonly IRepositorioPocao _repositorioPocao;

        public ServicoPocao(IRepositorioPocao repositorioPocao)
        {
            _repositorioPocao = repositorioPocao;
        }
        public List<Pocao> ObterTodos()
        {
            return _repositorioPocao.ObterTodos();
        }
        public void ObterPorldPocao()
        {
        }
        public void CriarPocao(Pocao pocao)
        {
            _repositorioPocao.Criar(pocao);
        }
        public void EditarPocao()
        {
        }
        public void RemoverPocao()
        {
        }
    }
}
