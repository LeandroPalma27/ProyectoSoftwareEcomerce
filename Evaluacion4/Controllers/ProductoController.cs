using Evaluacion4.Data.Interfaces;
using Evaluacion4.Models.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace Evaluacion4.Controllers
{
    // [Authorize]
    // Autorize es un atributo que le indica a un metodo de accion si puede actuar o no
    // en funcion a si un usuario cumple con el requisito de autorizacion. Puede modificarse
    // para que es condicion sea acompañada de roles de usuario, no solo que el usuario este
    // validado, sino que un sin fin de posibilidades mas.
    public class ProductoController : Controller
    {
        private readonly IADProducto ADProducto;
        private readonly IADCategoria ADCategoria;
        private readonly IWebHostEnvironment _IWebHostEnvironment;

        public ProductoController(IADProducto ADProducto, IADCategoria ADCategoria, IWebHostEnvironment webHostEnvironment)
        {
            this.ADProducto = ADProducto;
            this.ADCategoria = ADCategoria;
            _IWebHostEnvironment = webHostEnvironment;
        }

        // Cada metodo de accion se ejecuta al asignar el atributo asp-action a un elemento de cshtml.

        [Authorize] //Sirve para accionar un controlador solo si el usuario esta autenticado//

        [HttpGet] //Indica el protocolo HTTP a usar para la peticion al servidor.
        public IActionResult Index(int Categoria, int page = 1)
        {
            var pagenumber = page;
            var modelo = ADProducto.GetBuscarProducto(Categoria);
            var datos = modelo.OrderByDescending(x => x.IdProducto).ToList().ToPagedList(pagenumber, 6);

            var listaCompras = ADProducto.GetProducto();
            var cantidad = listaCompras.Count();
            ViewBag.cantidad = cantidad;
            TempData["Categoria"] = ADCategoria.GetMostrarCategoria();
            return View(datos);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewBag.ADCategoria = ADCategoria.GetMostrarCategoria();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile picture, Producto Entidad)
        {
            Entidad.IdProducto = 0;
            Entidad.FechaRegistro = DateTime.Now;

            if (picture != null)
            {
                string rutaImagen = Path.Combine(_IWebHostEnvironment.WebRootPath, "imagen/producto");
                string archivoUnico = $"{Guid.NewGuid().ToString()}-{Path.GetExtension(picture.FileName)}";
                string rutaFinal = Path.Combine(rutaImagen, archivoUnico);

                using (var file = new FileStream(rutaFinal, FileMode.Create))
                {
                    await picture.CopyToAsync(file);
                }
                Entidad.Imagen = $"imagen/producto/{archivoUnico}";
            }
            else
            {
                Entidad.Imagen = null;
            }

            var resultado = ADProducto.InsertProducto(Entidad);
            if (resultado > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(Entidad);
            }
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            ViewBag.ADCategoria = ADCategoria.GetMostrarCategoria();
            var model = ADProducto.GetIdProducto(id);
            return View(model);
        }
        //comprar
        [HttpPost]
        public IActionResult Edit(Producto Entidad)
        {
            var resultado = ADProducto.UpdateProducto(Entidad);
            if (resultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(Entidad);
            }
        }

        public IActionResult Detail(int id)
        {
            var modelo = ADProducto.GetIdProducto(id);
            return View(modelo);
        }

        public IActionResult Delete(int id)
        {
            var resultado = ADProducto.DeleteProducto(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Carrito(int id)
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cantidad = 2;

            ADProducto.carrito(id, UserId, cantidad);

            // Metodo para hacer jatear al programa por 2.25 segundos
            Thread.Sleep(1800);

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult ListaCarrito()
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var listaCompras = ADProducto.GetCompras(UserId);
            float precioPagar = ADProducto.GetPrecioPagar(UserId);
            var cantidad = listaCompras.Count();
            ViewBag.costo = precioPagar;
            ViewBag.cantidad = cantidad;
            return View(listaCompras);
        }

        public IActionResult DeleteCompra(int id)
        {
            var resultado = ADProducto.DeleteCompra(id);
            return RedirectToAction("ListaCarrito");
        }

        // metodo para guardar las compras en el historial
        [Authorize]
        public IActionResult PagarxProducto(int id)
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pagado = ADProducto.PagarProducto(id, UserId);

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult PagarxProductos()
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pagado = ADProducto.PagarProductos(UserId);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Prueba()
        {
            return View(null);
        }


        public IActionResult CompraFactura()
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var listaFactura = ADProducto.GetFactura(UserId);
            

            return View(listaFactura);
        }
    }
}