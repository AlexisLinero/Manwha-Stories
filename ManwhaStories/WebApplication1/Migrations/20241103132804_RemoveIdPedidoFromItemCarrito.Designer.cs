﻿// <auto-generated />
using System;
using ManwhaStories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManwhaStories.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241103132804_RemoveIdPedidoFromItemCarrito")]
    partial class RemoveIdPedidoFromItemCarrito
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ManwhaStories.Models.Carrito", b =>
                {
                    b.Property<int>("ID_Carrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID_Carrito"));

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID_Carrito");

                    b.ToTable("Carritos");
                });

            modelBuilder.Entity("ManwhaStories.Models.ItemCarrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ID_Carrito")
                        .HasColumnType("int");

                    b.Property<int>("Id_Producto")
                        .HasColumnType("int");

                    b.Property<int?>("PedidoId_Pedido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ID_Carrito");

                    b.HasIndex("Id_Producto");

                    b.HasIndex("PedidoId_Pedido");

                    b.ToTable("ItemsCarrito");
                });

            modelBuilder.Entity("ManwhaStories.Models.Pedido", b =>
                {
                    b.Property<int>("Id_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_Pedido"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Id_Carrito")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id_Pedido");

                    b.HasIndex("Id_Carrito");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ManwhaStories.Models.Producto", b =>
                {
                    b.Property<int>("Id_Producto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id_Producto"));

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Descuento")
                        .HasColumnType("int");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_Producto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ManwhaStories.Models.ItemCarrito", b =>
                {
                    b.HasOne("ManwhaStories.Models.Carrito", "Carrito")
                        .WithMany("Items")
                        .HasForeignKey("ID_Carrito")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ItemCarrito_Carrito");

                    b.HasOne("ManwhaStories.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("Id_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ItemCarrito_Producto");

                    b.HasOne("ManwhaStories.Models.Pedido", null)
                        .WithMany("ItemsCarrito")
                        .HasForeignKey("PedidoId_Pedido");

                    b.Navigation("Carrito");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ManwhaStories.Models.Pedido", b =>
                {
                    b.HasOne("ManwhaStories.Models.Carrito", "Carrito")
                        .WithMany()
                        .HasForeignKey("Id_Carrito")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");
                });

            modelBuilder.Entity("ManwhaStories.Models.Carrito", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ManwhaStories.Models.Pedido", b =>
                {
                    b.Navigation("ItemsCarrito");
                });
#pragma warning restore 612, 618
        }
    }
}
