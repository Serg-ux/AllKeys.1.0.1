using AllKeys.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENTAS_ORM.DAL;

namespace ExamenVentas.DAL
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork() {
            context.Database.EnsureCreated();
        
        }
        private VentasContext context = new VentasContext();
        private bool disposed = false;


        private CopiasRepository copiasRepository;
        private DescuentosRepository descuentosRepository;
        private RolesRepository rolesRepository;
        private UsuariosRegistradosRepository usuariosRegistradosRepository;
        private UsuariosRepository usuariosRepository;
        private VideojuegosRepository videojuegosRepository;
       

        public CopiasRepository CopiasRepository
        {
            get
            {
                if (copiasRepository == null)
                {
                    copiasRepository = new CopiasRepository(context);
                }

                return copiasRepository;
            }
        }

        public DescuentosRepository DescuentosRepository
        {
            get
            {
                if (descuentosRepository == null)
                {
                    descuentosRepository = new DescuentosRepository(context);
                }

                return descuentosRepository;
            }
        }

        public RolesRepository RolesRepository
        {
            get
            {
                if (rolesRepository == null)
                {
                    rolesRepository = new RolesRepository(context);
                }

                return rolesRepository;
            }
        }

        public UsuariosRegistradosRepository UsuariosRegistradosRepository
        {
            get
            {
                if (usuariosRegistradosRepository == null)
                {
                    usuariosRegistradosRepository = new UsuariosRegistradosRepository(context);
                }

                return usuariosRegistradosRepository;
            }
        }

        public UsuariosRepository UsuariosRepository
        {
            get
            {
                if (usuariosRepository == null)
                {
                    usuariosRepository = new UsuariosRepository(context);
                }

                return usuariosRepository;
            }
        }

        public VideojuegosRepository VideojuegosRepository
        {
            get
            {
                if (videojuegosRepository == null)
                {
                    videojuegosRepository = new VideojuegosRepository(context);
                }

                return videojuegosRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
