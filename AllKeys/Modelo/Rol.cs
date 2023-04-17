using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllKeys.Modelo
{
    public class Rol
    {
        public int RolId { get; set; }
        [Required]
        [StringLength(maximumLength: 15, ErrorMessage = "Longitud maxima admitida 15 car")]
        public string RolNombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public Rol() {
            Usuarios=new HashSet<Usuario>();
        }
    }
}
