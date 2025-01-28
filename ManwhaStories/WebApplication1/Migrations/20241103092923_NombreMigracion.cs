using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManwhaStories.Migrations
{
    /// <inheritdoc />
    public partial class NombreMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Carritos_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Productos_ProductoId",
                table: "ItemsCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Carritos_CarritoId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_ItemsCarrito_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Productos",
                newName: "Id_Producto");

            migrationBuilder.RenameColumn(
                name: "CarritoId",
                table: "Pedidos",
                newName: "Id_Carrito");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pedidos",
                newName: "Id_Pedido");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_CarritoId",
                table: "Pedidos",
                newName: "IX_Pedidos_Id_Carrito");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "ItemsCarrito",
                newName: "ProductoId_Producto");

            migrationBuilder.RenameColumn(
                name: "CarritoId",
                table: "ItemsCarrito",
                newName: "ID_Producto");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsCarrito_ProductoId",
                table: "ItemsCarrito",
                newName: "IX_ItemsCarrito_ProductoId_Producto");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carritos",
                newName: "ID_Carrito");

            migrationBuilder.AddColumn<int>(
                name: "ID_Carrito",
                table: "ItemsCarrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_ID_Carrito",
                table: "ItemsCarrito",
                column: "ID_Carrito");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrito_Carrito",
                table: "ItemsCarrito",
                column: "ID_Carrito",
                principalTable: "Carritos",
                principalColumn: "ID_Carrito",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Productos_ProductoId_Producto",
                table: "ItemsCarrito",
                column: "ProductoId_Producto",
                principalTable: "Productos",
                principalColumn: "Id_Producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Carritos_Id_Carrito",
                table: "Pedidos",
                column: "Id_Carrito",
                principalTable: "Carritos",
                principalColumn: "ID_Carrito",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrito_Carrito",
                table: "ItemsCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Productos_ProductoId_Producto",
                table: "ItemsCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Carritos_Id_Carrito",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItemsCarrito_ID_Carrito",
                table: "ItemsCarrito");

            migrationBuilder.DropColumn(
                name: "ID_Carrito",
                table: "ItemsCarrito");

            migrationBuilder.RenameColumn(
                name: "Id_Producto",
                table: "Productos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id_Carrito",
                table: "Pedidos",
                newName: "CarritoId");

            migrationBuilder.RenameColumn(
                name: "Id_Pedido",
                table: "Pedidos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_Id_Carrito",
                table: "Pedidos",
                newName: "IX_Pedidos_CarritoId");

            migrationBuilder.RenameColumn(
                name: "ProductoId_Producto",
                table: "ItemsCarrito",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "ID_Producto",
                table: "ItemsCarrito",
                newName: "CarritoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsCarrito_ProductoId_Producto",
                table: "ItemsCarrito",
                newName: "IX_ItemsCarrito_ProductoId");

            migrationBuilder.RenameColumn(
                name: "ID_Carrito",
                table: "Carritos",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MedioPago = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Monto = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Clave = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioNombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Carritos_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Productos_ProductoId",
                table: "ItemsCarrito",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Carritos_CarritoId",
                table: "Pedidos",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
