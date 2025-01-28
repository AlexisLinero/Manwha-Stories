
using Microsoft.EntityFrameworkCore;
using ManwhaStories.Models;

namespace ManwhaStories.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<ItemCarrito> ItemsCarrito { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DatoPago> Pago { get; set; }
        public DbSet<Inventario> Inventario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrito>()
                .HasKey(c => c.ID_Carrito);

            modelBuilder.Entity<ItemCarrito>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Producto>()
                .HasKey(p => p.Id_Producto);

            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.Id_Pedido);

            modelBuilder.Entity<Usuario>()
                .HasKey(p => p.ID_Usuario);

            modelBuilder.Entity<DatoPago>()
                .HasKey(p => p.ID_Pago);


            modelBuilder.Entity<ItemCarrito>()
                .HasOne(i => i.Carrito)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.ID_Carrito)
                .HasConstraintName("FK_ItemCarrito_Carrito");


            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Carrito)
                .WithMany()
                .HasForeignKey(p => p.Id_Carrito);


            modelBuilder.Entity<ItemCarrito>()
                .HasOne(i => i.Producto)
                .WithMany()
                .HasForeignKey(i => i.Id_Producto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ItemCarrito_Producto");

            modelBuilder.Entity<Pedido>()
            .HasMany(p => p.ItemsCarrito)
            .WithOne()
            .HasForeignKey(i => i.ID_Carrito);

            modelBuilder.Entity<Inventario>().HasKey(i => i.ID_Inventario);

            // Configuración de la relación con Producto
            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Producto)
                .WithMany() // Asume que `Producto` no tiene una lista de `Inventario`
                .HasForeignKey(i => i.Id_Producto);


        }
    }
}