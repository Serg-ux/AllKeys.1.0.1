using AllKeys.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllKeys.DAL
{
    public class VentasContext:DbContext
    {
        public DbSet<Copia> Copias { get; set; }
        public DbSet<Descuento> Descuentos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRegistrado> UsuarioRegistrados { get; set; }
        public DbSet<Videojuego> Videojuegos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AllKeys;User Id=sa; password=abc123.");
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AllKeys;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Copia>()
                .HasOne<Videojuego>(v => v.Videojuego)
                .WithMany(c => c.Copias)
                .HasForeignKey(v => v.VideojuegoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Copia>()
                .HasOne<UsuarioRegistrado>(usr => usr.UsuarioRegistrado)
                .WithMany(c => c.Copias)
                .HasForeignKey(usr => usr.UsuarioRegistradoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsuarioRegistrado>()
                .HasMany<ObtenerDescuento>(obd => obd.ObtenerDescuentos)
                .WithOne(usr => usr.UsuarioRegistrado)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UsuarioRegistrado>()
                .HasOne<Usuario>(us=>us.Usuario)
                .WithOne(usr=>usr.UsuarioRegistrado)
                //cambio realizado Usuario->UsuarioRegistrado
                .HasForeignKey<UsuarioRegistrado>(usr=>usr.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UsuarioRegistrado>()
                .HasMany<Copia>(c=>c.Copias)
                .WithOne(usr=>usr.UsuarioRegistrado)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<ObtenerDescuento>()
                .HasOne<UsuarioRegistrado>(usr=>usr.UsuarioRegistrado)
                .WithMany(od=>od.ObtenerDescuentos)
                .HasForeignKey(usr=>usr.UsuarioRegistradoId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ObtenerDescuento>()
                .HasOne<Descuento>(d=>d.Descuento)
                .WithMany(od=>od.ObtenerDescuentos)
                .HasForeignKey(d=>d.DescuentoId) 
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Descuento>()
                .HasMany<ObtenerDescuento>(od => od.ObtenerDescuentos)
                .WithOne(d => d.Descuento)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Usuario>()
                .HasOne<UsuarioRegistrado>(u => u.UsuarioRegistrado)
                .WithOne(ur => ur.Usuario)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Usuario>()
                .HasOne<Rol>(r => r.Rol)
                .WithMany(us => us.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Cascade);  

            
            modelBuilder.Entity<Rol>()
                .HasMany<Usuario>(u => u.Usuarios)
                .WithOne(r => r.Rol)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Rol>().HasData(
               new Rol
               {
                   RolId= 1,
                   RolNombre = "Admin"
               }
           );
            modelBuilder.Entity<Rol>().HasData(
              new Rol
              {
                  RolId= 2,
                  RolNombre = "Usuario"
              }
          );
            modelBuilder.Entity<Rol>().HasData(
              new Rol
              {
                  RolId= 3,
                  RolNombre = "Premium"
              }
          );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    UsuarioId= 1,
                    UsuarioNombre="Admin",
                    UsuarioTlf="616756340",
                    UsuarioColor_Fav="amarillo",
                    UsuarioContra="abc123.",
                    UsuarioCorreo="admin@gmail.com",
                    RolId=1,
                    
                }
            );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    UsuarioId= 2,
                    UsuarioNombre = "User1",
                    UsuarioTlf = "694234651",
                    UsuarioColor_Fav = "amarillo",
                    UsuarioContra = "abc123.",
                    UsuarioCorreo = "user1@gmail.com",
                    RolId= 2
                }
            );
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    UsuarioId= 3,
                    UsuarioNombre = "User2",
                    UsuarioTlf = "194244554",
                    UsuarioColor_Fav = "azul",
                    UsuarioContra = "abc123.",
                    UsuarioCorreo = "user2@gmail.com",
                    RolId = 3
                }
            );
            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {

                    UsuarioId= 4,
                   UsuarioNombre = "Carlos",
                   UsuarioTlf = "616736340",
                   UsuarioColor_Fav = "azul",
                   UsuarioContra = "abc123.",
                   UsuarioCorreo = "carlos@gmail.com",
                   RolId = 2

               }
           );
            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {

                   UsuarioId= 5,
                   UsuarioNombre = "Martin",
                   UsuarioTlf = "611236340",
                   UsuarioColor_Fav = "verde",
                   UsuarioContra = "abc123.",
                   UsuarioCorreo = "martin@gmail.com",
                   RolId = 2

               }
           );
            modelBuilder.Entity<Videojuego>().HasData(
                new Videojuego
                {
                    VideojuegoId=1,
                    Descripccion="Juego competitivo basado en plantar bombas y cubrir",
                    Disponible=1,
                    Precio=12.5,
                    Tipo="Shooter",
                    VideojuegoCompania="Valve",
                    VideojuegoName="Csgo"
                }
            );
            modelBuilder.Entity<Videojuego>().HasData(
               new Videojuego
               {
                   VideojuegoId = 2,
                   Descripccion = "Juego competitivo basado en plantar bombas y cubrir",
                   Disponible = 1,
                   Precio = 14,
                   Tipo = "Shooter",
                   VideojuegoCompania = "Riot Games",
                   VideojuegoName = "Valorant"
               }
           );
            modelBuilder.Entity<Videojuego>().HasData(
               new Videojuego
               {
                   VideojuegoId = 3,
                   Descripccion = "Shooter",
                   Disponible = 1,
                   Precio = 30,
                   Tipo = "Shooter",
                   VideojuegoCompania = "Activision",
                   VideojuegoName = "Call of Duty"
               }
           );
            modelBuilder.Entity<Videojuego>().HasData(
               new Videojuego
               {
                   VideojuegoId = 4,
                   Descripccion = "Juego creativo",
                   Disponible = 1,
                   Precio = 16,
                   Tipo = "Survival",
                   VideojuegoCompania = "Mojang",
                   VideojuegoName = "Minecraft"
               }
           );
            modelBuilder.Entity<Videojuego>().HasData(
               new Videojuego
               {
                   VideojuegoId = 5,
                   Descripccion = "Perdida de tiempo",
                   Disponible = 1,
                   Precio = 0,
                   Tipo = "MMO",
                   VideojuegoCompania = "Riot Games",
                   VideojuegoName = "League of Legends"
               }
           );
            
        }
    }
}
