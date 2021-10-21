using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Evaluacion4.Data.ApplicationDbContext;

namespace Evaluacion4.Models.Entidad
{
    public class CompraFactura
    {
        [Key]
        public int IdFactura { get; set; }

        public DateTime FechaFactura { get; set; }

        public double PrecioTotal { get; set; }

        public string JsonCompras { get; set; }

        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual Usuario Usuario { get; set; }
    }
}
