using Evaluacion4.Models.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion4.Data.Interfaces
{
    public interface IADCategoria
    {
        IEnumerable<Categoria> GetMostrarCategoria();

    }
}
