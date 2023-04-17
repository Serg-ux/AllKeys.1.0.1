using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllKeys.Modelo
{
    public class ObtenerDescuento
    {
        public int ObtenerDescuentoId { get; set; }
        public virtual Descuento Descuento { get; set; }
        public int DescuentoId { get; set; }
        public virtual UsuarioRegistrado UsuarioRegistrado { get; set; }
        public int UsuarioRegistradoId { get; set; }
        public ObtenerDescuento() { }
    }
}
