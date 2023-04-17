using AllKeys.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTAS_ORM.DAL;

namespace AllKeys.DAL
{
    public class DescuentosRepository : GenericRepository<Descuento>
    {
        public DescuentosRepository(VentasContext context) : base(context)
        {
        }
    }
}
