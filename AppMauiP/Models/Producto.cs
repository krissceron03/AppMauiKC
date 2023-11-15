using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMauiP.Models
{
    internal class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }

        public string descripcion { get; set; }

        public int cantidad { get; set; }
    }
}
