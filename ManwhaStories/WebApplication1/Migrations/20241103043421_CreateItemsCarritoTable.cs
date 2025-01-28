using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManwhaStories.Migrations
{
    /// <inheritdoc />
    public partial class CreateItemsCarritoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Carritos");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Productos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPedido",
                table: "Pedidos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ItemsCarrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCarrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsCarrito_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsCarrito_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CarritoId",
                table: "Pedidos",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_ProductoId",
                table: "ItemsCarrito",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Carritos_CarritoId",
                table: "Pedidos",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Carritos_CarritoId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "ItemsCarrito");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_CarritoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "FechaPedido",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Carritos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
