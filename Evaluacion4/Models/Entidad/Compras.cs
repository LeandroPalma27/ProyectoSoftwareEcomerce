using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Evaluacion4.Data.ApplicationDbContext;

namespace Evaluacion4.Models.Entidad
{
    public class Compras
    {

        [Key]
        public int IdCompras { get; set; }

        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }

        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual Usuario Usuario { get; set; }
    }
}
