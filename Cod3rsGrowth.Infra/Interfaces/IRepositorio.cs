using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorio
    {
        ListaSingleton ObterTodos();
    }
}
