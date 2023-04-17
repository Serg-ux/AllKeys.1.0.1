using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllKeys.Modelo
{
    public class Copia
    {
        public int CopiaId { get; set; }
        //se dice required para que el campo no pueda ser nulo
        [Required]
        //se le pone que la longitud maxima sea de 20 caracteres,
        //de lo contrario saltará un mensaje de erro
        [StringLength(maximumLength: 20, ErrorMessage = "Longitud maxima admitida 20 car")]
        public string CopiaCod { get; set; }
        public virtual Videojuego Videojuego { get; set; }
        public int VideojuegoId { get; set; }
        public virtual UsuarioRegistrado UsuarioRegistrado { get; set; }
        public int? UsuarioRegistradoId { get; set; }
        public Copia() { }
    }
}
