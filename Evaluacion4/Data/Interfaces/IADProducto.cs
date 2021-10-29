using Evaluacion4.Data.AccesoDatos;
using Evaluacion4.Models.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion4.Data.Interfaces
{
    public interface IADProducto
    {
        IEnumerable<Producto> GetProducto();
        Producto GetIdProducto(int id);
        int InsertProducto(Producto Entity);
        Boolean UpdateProducto(Producto Entidad);
        Boolean DeleteProducto(int id);
        IEnumerable<Producto> GetBuscarProducto(int Proveedor);
        public Boolean carrito(int id, string UserId, int cantidad);
        IEnumerable<Compras> GetCompras(string UserId);

        IEnumerable<CompraFactura> GetFactura(string UserId);


        float GetPrecioPagar(string UserId);
        Boolean PagarProducto(int id, string UserId);
        Boolean PagarProductos(string UserId);

        Boolean DeleteCompra(int id);
    }
}
