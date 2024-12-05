using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int TotalProducto { get; set; }

        public decimal MontoTotal { get; set; }

        public string Contacto { get; set; }
        public string IdDistrito { get; set; }
        public string Telefono { get; set; }

        public int Direccion { get; set; }

        public string IdTransaccion { get; set; }
        public string FechaTexto { get; set; }

        public List<Detalle_Venta> oDetalleVenta { get; set; }


    }
}
