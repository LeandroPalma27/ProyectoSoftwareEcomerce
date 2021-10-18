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
    public class ADProducto:IADProducto

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

            DateTime today = DateTime.Today;

            using (var db = new ApplicationDbContext())
            {
                HistorialCompras historial = new HistorialCompras();
                historial.IdProducto = id;
                historial.Id = UserId;
                historial.FechaHistorial = today;

                db.Add(historial);
                db.SaveChanges();
                resultado = historial.IdProducto;

            }
            return resultado;
        }

        Boolean IADProducto.PagarProductos(string UserId)
        {
            var listado = new List<Compras>();
            Boolean resultado = false;
            using (var db = new ApplicationDbContext())
            {
                HistorialCompras historial = new HistorialCompras();
             
                listado = db.Compras.Include(item => item.Producto).Where(item => item.Id == UserId).ToList();

                for (int i = 0; i < listado.Count; i++)
                {

                    historial.IdProducto = listado[i].IdProducto;
                    historial.Id = listado[i].Id;
                    historial.FechaHistorial = new DateTime();


                    db.Add(historial);
                    db.SaveChanges();
                    resultado = true;
                }
            }
            return resultado;
        }
    }

        
    
}
