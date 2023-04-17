using AllKeys.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTAS_ORM.DAL;

namespace AllKeys.DAL
{
    public class CopiasRepository : GenericRepository<Copia>
    {
        public CopiasRepository(VentasContext context) : base(context)
        {
        }
        public List<Copia> CopiasFiltro(int idVideojuego)
        {
            return Get(c =>c.VideojuegoId==idVideojuego);
        }
    }
}
