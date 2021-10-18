using Evaluacion4.Data.Interfaces;
using Evaluacion4.Models.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion4.Data.AccesoDatos
{
    public class ADCategoria: IADCategoria
    {
        public IEnumerable<Categoria> GetMostrarCategoria()
        {
            var listaCategoria = new List<Categoria>();
            using (var db = new ApplicationDbContext())
            {
                listaCategoria = db.Categoria.ToList();
            }
            return listaCategoria;
        }

    }
}
