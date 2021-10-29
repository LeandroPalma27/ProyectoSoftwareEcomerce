using Evaluacion4.Data.Interfaces;
using Evaluacion4.Models.Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Evaluacion4.Data.AccesoDatos
{
    public class ADProducto : IADProducto
    {
        DateTime today = DateTime.Now;

        // Metodos de acceso a datos:
        // -Estos metodos son de ayuda a los metodos de accion para poder comunicarse con la base de datos usando la clase "ApplicationDbContext".
        public IEnumerable<Producto> GetProducto()
        {
            var listado = new List<Producto>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Producto.ToList();
            }
            return listado;
        }


        public int InsertProducto(Producto Entity)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                var fecha = Entity.FechaRegistro;
                db.Add(Entity);
                db.SaveChanges();
                resultado = Entity.IdProducto;
            }
            return resultado;
        }


        public Boolean UpdateProducto(Producto Entidad)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Producto.Attach(Entidad);
                db.Entry(Entidad).State = EntityState.Modified;
                db.Entry(Entidad).Property(item => item.FechaRegistro).IsModified   = false;
                db.Entry(Entidad).Property(item => item.Imagen).IsModified          = false;
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }


        public Boolean DeleteProducto(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var producto = new Producto { IdProducto = id };
                //db.Producto.Attach(entidad);
                //db.Producto.Remove(entidad);
                //resultado = db.SaveChanges() != 0;
                producto.Stock = 1;
                resultado = RestarProducto(producto);
                
            }
            return resultado;
        }


        public IEnumerable<Producto> GetBuscarProducto(int Proveedor)
        {
            var listado = new List<Producto>();
            using (var db = new ApplicationDbContext())
            {
                if (Proveedor == 0)
                {
                    listado = db.Producto.Include(item => item.Categoria).ToList();
                }
                if (Proveedor > 0)
                {
                    listado = db.Producto.Include(item => item.Categoria).Where(item => item.IdCategoria == Proveedor).ToList();
                }
            }
            return listado;
        }

        public Producto GetIdProducto(int id)
        {
            var resultado = new Producto();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.Producto.Where(item => item.IdProducto == id).FirstOrDefault();
            }
            return resultado;
        }

        public Boolean carrito(int id, string UserId, int cantidad)
        {
            var listado   = new List<Compras>();
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                Compras compra = new Compras();

                listado = db.Compras.Where(item => item.IdProducto == id).ToList();


                if (listado.Count() == 0)
                {
                    compra.IdProducto = id;
                    compra.Id = UserId;
                    db.Add(compra);
                    db.SaveChanges();
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }

                
            }
            return resultado;
        }

        public IEnumerable<Compras> GetCompras(string UserId)
        {
            var listado = new List<Compras>();
            var Productos = new List<Producto>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Compras.Include(item => item.Producto).Where(item => item.Id == UserId).ToList();
                return listado;
            }
        }


        public IEnumerable<CompraFactura> GetFactura(string UserId)
        {
            var listado = new List<CompraFactura>();
            
            using (var db = new ApplicationDbContext())
            {
                listado = db.CompraFactura.Where(item => item.Id == UserId).ToList();
                
            }
            return listado;
        }



        public Boolean DeleteCompra(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new Compras { IdCompras = id };
                db.Compras.Attach(entidad);
                db.Compras.Remove(entidad);
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }

        //PAGAR SOLO UN PRODUCTO DE LA LISTA DE COMPRAS ( CARRITO )
        Boolean IADProducto.PagarProducto(int id, string UserId)
        {
            var listado     = new List<Compras>();                              
            var compras     = new Compras();
            var resultado   = false;

            using (var db = new ApplicationDbContext())
            {
                compras = db.Compras.Include(item => item.Producto).Where(item => item.IdCompras == id).FirstOrDefault();
                listado = db.Compras.Where(item => item.IdCompras == compras.IdCompras).ToList();

                HistorialCompras historial  = new HistorialCompras();
                     
                historial.PrecioProducto    = compras.Producto.Precio;
                historial.IdProducto        = compras.IdProducto;
                historial.FechaHistorial    = today;
                historial.Id                = compras.Id;

                db.Add(historial);
                db.SaveChanges();

                CrearFactura(listado);
                RestarProducto(compras.Producto);
                DeleteCompra(compras.IdCompras);

                resultado = true;
            }
            return resultado;
        }

        
        //Metodo para pagar toda la lista del carrito, almacenarlo en un historial y crear la factura
        Boolean IADProducto.PagarProductos(string UserId)
        {
            var listado = new List<Compras>();
            var factura = new CompraFactura();           
            Boolean resultado   = false;

            using (var db = new ApplicationDbContext())
            {
                listado = db.Compras.Include(item => item.Producto).Where(item => item.Id == UserId).ToList();              

                for (int i = 0; i < listado.Count; i++)
                {
                    var producto = new Producto();
                    //Creando el historial de compras
                    HistorialCompras historial  = new HistorialCompras();
                    
                    historial.PrecioProducto    = listado[i].Producto.Precio;
                    historial.IdProducto        = listado[i].IdProducto;                    
                    historial.Id                = listado[i].Id;
                    historial.FechaHistorial    = today;                   

                    db.HistorialCompras.Add(historial);
                    db.SaveChanges();

                    //Eliminamos el articulo comprado de la lista del carrito y luego Obtenemos el Id del producto comprado para restar el stock
                    DeleteCompra(listado[i].IdCompras);
                    producto = listado[i].Producto;
                    RestarProducto(producto);                    
                }
                CrearFactura(listado);
                resultado = true;
            }
            return resultado;
        }      

        //CALCULAMOS EL MONTO TOTAL A PAGAR DE NUESTRA LISTA DE COMOPRAS ( CARRITO )
        float IADProducto.GetPrecioPagar(string UserId)
        {
            var listado     = new List<Compras>();
            var productos   = new List<Producto>();
            float pagar     = 0;

            using (var db = new ApplicationDbContext())
            {
                listado = db.Compras.Include(item => item.Producto).Where(item => item.Id == UserId).ToList();
                listado.Select(item => item.IdProducto).ToList();
                foreach (var item in listado)
                {
                    pagar = (pagar + item.Producto.Precio);
                }
                return pagar;
            }
        }

        //RESTA EL STOCK DEL PRODUCTO COMPRADO
        Boolean RestarProducto(Producto producto)
        {
            var resp = false;
            using (var db = new ApplicationDbContext())
            {
                producto.Stock = producto.Stock - 1;
                db.Producto.Attach(producto);
                db.Entry(producto).State = EntityState.Modified;
                db.Entry(producto).Property(item => item.FechaRegistro).IsModified  = false;
                db.Entry(producto).Property(item => item.Descripcion).IsModified    = false;
                db.Entry(producto).Property(item => item.IdCategoria).IsModified    = false;
                db.Entry(producto).Property(item => item.IdProducto).IsModified     = false;
                db.Entry(producto).Property(item => item.Nombre).IsModified         = false;                
                db.Entry(producto).Property(item => item.Codigo).IsModified         = false;
                db.Entry(producto).Property(item => item.Precio).IsModified         = false;                
                db.Entry(producto).Property(item => item.Imagen).IsModified         = false;                
                resp = db.SaveChanges() != 0;
            }
            return resp;
        }
        //Metodo para crear una factura de las compras
        Boolean CrearFactura(List<Compras> compras)
        {
            List<ADFactura> listFactura = new List<ADFactura>();
            var factura         = new CompraFactura();
            float totalPrecio   = 0;
            Boolean respuesta   = false;
            
            using (var db = new ApplicationDbContext())
            {
                for (int i = 0; i < compras.Count; i++)
                {
                    listFactura.Add(new ADFactura()
                    {                        
                        Nombre          = compras[i].Producto.Nombre,
                        Precio          = compras[i].Producto.Precio,
                        Codigo          = compras[i].Producto.Codigo        
                    });
                }

                foreach (var item in compras)
                {
                    totalPrecio = totalPrecio + item.Producto.Precio;
                }

                factura.PrecioTotal     = totalPrecio;
                factura.FechaFactura    = today;
                factura.Id              = compras[0].Id;
                factura.JsonCompras     = JsonSerializer.Serialize(listFactura);

                //Agregamos y guardamos los datos de la Factura
                db.CompraFactura.Add(factura);
                db.SaveChanges();
                respuesta = true;
            }
            return respuesta;
        }

        
    }
}