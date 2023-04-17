using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllKeys.Modelo
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        
        [Required]
        [StringLength(maximumLength:30 , ErrorMessage = "Longitud maxima admitida 30 car")]
        public string UsuarioNombre { get; set; }
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Longitud maxima admitida 20 car")]
        public string UsuarioContra { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Formato de correo no valido")]
        public string UsuarioCorreo { get; set; }
        [Required]
        [Phone(ErrorMessage = "Formato de telefono no valido")]
        public string UsuarioTlf { get; set; }
        [Required]
        [StringLength(maximumLength: 20, ErrorMessage = "Longitud maxima admitida 20 car")]
        public string UsuarioColor_Fav { get; set; }
        
        public virtual UsuarioRegistrado UsuarioRegistrado { get; set; }
        public virtual Rol Rol { get; set; }
        public int RolId { get; set; }
        public Usuario() { }
    }
}
