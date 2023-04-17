using AllKeys.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTAS_ORM.DAL;

namespace AllKeys.DAL
{
    public class VideojuegosRepository : GenericRepository<Videojuego>
    {
        public VideojuegosRepository(VentasContext context) : base(context)
        {
           
        }
        public List<Videojuego> videojuegosCompletos()
        {
            // includeProperties  se está solicitando que las copias asociadas a ese videojuego también se carguen en la memoria.
            return Get(includeProperties: "Copias");
        }
        //filtro que devuelve una lista de videojuegos filtrando por que el nombre o la compañía contengan el criterio dado
        public List<Videojuego> FiltroVideojuegos(string criterio)
        {
            return Get(v => v.VideojuegoName.ToLower().Contains(criterio.ToLower()) || v.VideojuegoCompania.ToLower().Contains(criterio.ToLower()));
        }
    } 
}
