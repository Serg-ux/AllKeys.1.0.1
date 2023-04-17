using AllKeys.Modelo;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTAS_ORM.DAL;

namespace AllKeys.DAL
{
    public class UsuariosRepository : GenericRepository<Usuario>
    {
        public UsuariosRepository(VentasContext context) : base(context)
        {
        }
        public List<Usuario> UsuariosCompletos()
        {
            return Get(includeProperties: "Rol");
        }
        public  Usuario ValidarUsuario(string nombre, string contraseña)
        {
            return Get(u => u.UsuarioNombre == nombre && u.UsuarioContra == contraseña).FirstOrDefault();

        }
        public Usuario BuscarUsId(int id)
        {
            return Get(u => u.UsuarioId == id).FirstOrDefault();

        }
        public Usuario ValidarUsuario(string name, string telefono, string email)
        {
            return Get(u => u.UsuarioNombre.ToLower().Contains(name.ToLower()) || u.UsuarioTlf.ToLower().Contains(telefono.ToLower()) || u.UsuarioCorreo.ToLower().Contains(email.ToLower())).FirstOrDefault();

        }
    }
}
