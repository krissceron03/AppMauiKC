using AppMauiP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMauiP.Utils
{
    internal class Utils
    {
        static public List<Producto> ListaProductos = new List<Producto>()
        {
            new Producto
            {
            idProducto=1,
            nombre="Producto 1",
            descripcion="Descripcion 1",
            cantidad=1
            },

            new Producto
            {
            idProducto=2,
            nombre = "Producto 2",
            descripcion="Descripcion 2",
            cantidad=2
            }

        };
    }
}
