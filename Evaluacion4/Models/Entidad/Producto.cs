using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion4.Models.Entidad
{
    public class Producto
    {

        [Key]
        public int IdProducto { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar la nombre del articulo")]
        [MaxLength(150, ErrorMessage = "El campo no debe de tener más de 150 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Debe ingresar la descripcion del articulo")]
        [MaxLength(150, ErrorMessage = "El campo no debe de tener más de 150 caracteres")]
        public string Descripcion { get; set; }



        [Display(Name = "Codigo Producto")]
        [Required(ErrorMessage = "Debe de ingresar el codigo del articulo")]
        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 15 caracteres")]
        public string Codigo { get; set; }



        [Display(Name = "Stock")]
        [Required(ErrorMessage = "Debe de ingresar el stock del articulo")]
        public float Stock { get; set; }



        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Debe de ingresar el precio del articulo")]
        public float Precio { get; set; }


        public DateTime FechaRegistro { get; set; }


        public string Imagen { get; set; }

        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }
    }
}
