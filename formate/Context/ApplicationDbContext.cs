using formate.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace formate.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; }   

        public virtual DbSet<Comentario> Comentarios { get; set; } //Mov Tay

        public virtual DbSet<Categoria> Categorias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insert en la tabla Rol

            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRoles = 1,
                    Nombrerol = "admin"
                },
                new Rol
                {
                    PkRoles = 2,
                    Nombrerol = "cliente"
                });


            //Insert en la tabla usuario

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    NombreUsu = "Tay",
                    Contrasena = "1234",
                    FkRol = 1

                });
        }
    }
}
