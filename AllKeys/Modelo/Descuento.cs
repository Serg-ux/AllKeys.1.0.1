using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllKeys.Modelo
{
    public class Descuento
    {
        public int DescuentoId { get; set; }
        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "Longitud maxima admitida 10 car")]
        public string DescuentoCod { get; set; }
        public virtual ICollection<ObtenerDescuento> ObtenerDescuentos { get; set; }
        public Descuento() {
            ObtenerDescuentos = new HashSet<ObtenerDescuento>();
        }
    }
}
