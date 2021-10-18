using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion4.Models.Entidad
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "Debe ingresar la categoría")]
        [MaxLength(100, ErrorMessage = "El campo no debe de tener mas de 100 caracteres")]
        public string NombreCategoria { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
