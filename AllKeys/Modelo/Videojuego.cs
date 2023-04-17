using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllKeys.Modelo
{
    public class Videojuego
    {
        public int VideojuegoId { get; set; }
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Longitud maxima admitida 20 car")]
        public string VideojuegoName { get; set; }
        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Longitud maxima admitida 30 car")]
        public string VideojuegoCompania { get; set; }
        public string Descripccion { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Longitud maxima admitida 20 car")]
        public string Tipo { get; set; }
        public int Disponible { get; set; }
        


        public virtual ICollection<Copia> Copias { get; set; }
        public Videojuego() {
            Copias = new HashSet<Copia>();
        }
    }
}
