using AllKeys.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTAS_ORM.DAL;

namespace AllKeys.DAL
{
    public class RolesRepository : GenericRepository<Rol>
    {
        public RolesRepository(VentasContext context) : base(context)
        {
        }
        public List<Rol> RolCompleto()
        {
            return Get(includeProperties: "Usuario");
        }
        public List<Rol> RolesUsuarios()
        {
            return Get(r => r.RolId != 1);
        }
    }
}
