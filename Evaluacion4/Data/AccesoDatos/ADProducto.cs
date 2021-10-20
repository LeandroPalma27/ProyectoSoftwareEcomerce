using Evaluacion4.Data.Interfaces;
using Evaluacion4.Models.Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Evaluacion4.Data.AccesoDatos
{
    public class ADProducto : IADProducto

    {

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
                db.Entry(Entidad).Property(item => item.FechaRegistro).IsModified = false;
                db.Entry(Entidad).Property(item => item.Imagen).IsModified = false;
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }


        public Boolean DeleteProducto(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new Producto { IdProducto = id };
                db.Producto.Attach(entidad);
                db.Producto.Remove(entidad);
                resultado = db.SaveChanges() != 0;
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

        public Boolean carrito(int id, string UserId)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                Compras compra = new Compras();
                compra.IdProducto = id;
                compra.Id = UserId;
                db.Add(compra);
                db.SaveChanges();
                resultado = true;
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

      


        //PAGAR PRODUCTO
        int IADProducto.PagarProducto(int id, string UserId)
        {
            var resultado = 0;
            var compras = new Compras();
            var producto = new Producto();
            var respStok = false;
            



            DateTime today = DateTime.Now;

            using (var db = new ApplicationDbContext())
            {
                compras = db.Compras.Where(item => item.IdCompras == id).FirstOrDefault();
                producto = db.Producto.Where(item => item.IdProducto == compras.IdProducto).FirstOrDefault();



                HistorialCompras historial = new HistorialCompras();
                historial.IdProducto = compras.IdProducto;
                historial.Id = compras.Id;
                historial.FechaHistorial = today;

                db.Add(historial);
                db.SaveChanges();

                producto.Stock = producto.Stock -1;

                db.Producto.Attach(producto);
                db.Entry(producto).State = EntityState.Modified;
                db.Entry(producto).Property(item => item.IdProducto).IsModified = false;
                db.Entry(producto).Property(item => item.Nombre).IsModified = false;
                db.Entry(producto).Property(item => item.Descripcion).IsModified = false;
                db.Entry(producto).Property(item => item.Codigo).IsModified = false;
                db.Entry(producto).Property(item => item.Precio).IsModified = false;
                db.Entry(producto).Property(item => item.FechaRegistro).IsModified = false;
                db.Entry(producto).Property(item => item.Imagen).IsModified = false;
                db.Entry(producto).Property(item => item.IdCategoria).IsModified = false;

                respStok = db.SaveChanges() != 0;



                DeleteCompra(compras.IdCompras);



                resultado = historial.IdProducto;

            }
            return resultado;
        }

        Boolean IADProducto.PagarProductos(string UserId)
        {

            var listado = new List<Compras>();
            DateTime today = DateTime.Now;
            Boolean resultado = false;
            using (var db = new ApplicationDbContext())
            {

                listado = db.Compras.Include(item => item.Producto).Where(item => item.Id == UserId).ToList();



                for (int i = 0; i < listado.Count; i++)
                {
                    HistorialCompras historial = new HistorialCompras();
                    historial.IdProducto = listado[i].IdProducto;
                    historial.Id = listado[i].Id;
                    historial.FechaHistorial = today;





                    db.HistorialCompras.Add(historial);
                    db.SaveChanges();
                    DeleteCompra(listado[i].IdCompras);


                }

                resultado = true;
            }
            return resultado;
        }

        //TOTAL A PAGAR
        int IADProducto.GetPrecioPagar(string UserId)
        {


            var listado = new List<Compras>();
            var productos = new List<Producto>();
            var pagar = 0;
            using (var db = new ApplicationDbContext())
            {
                listado = db.Compras.Include(item => item.Producto).Where(item => item.Id == UserId).ToList();


                listado.Select(item => item.IdProducto).ToList();

                foreach (var item in listado)
                {
                    pagar = (int)(pagar + item.Producto.Precio);
                }




                return pagar;
            }
        }
    }



}
