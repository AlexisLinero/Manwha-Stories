using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManwhaStories.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdPedidoFromItemCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Productos_ProductoId_Producto",
                table: "ItemsCarrito");

            migrationBuilder.DropIndex(
                name: "IX_ItemsCarrito_ProductoId_Producto",
                table: "ItemsCarrito");

            migrationBuilder.DropColumn(
                name: "ProductoId_Producto",
                table: "ItemsCarrito");

            migrationBuilder.RenameColumn(
                name: "ID_Producto",
                table: "ItemsCarrito",
                newName: "Id_Producto");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId_Pedido",
                table: "ItemsCarrito",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_Id_Producto",
                table: "ItemsCarrito",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_PedidoId_Pedido",
                table: "ItemsCarrito",
                column: "PedidoId_Pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrito_Producto",
                table: "ItemsCarrito",
                column: "Id_Producto",
                principalTable: "Productos",
                principalColumn: "Id_Producto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Pedidos_PedidoId_Pedido",
                table: "ItemsCarrito",
                column: "PedidoId_Pedido",
                principalTable: "Pedidos",
                principalColumn: "Id_Pedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrito_Producto",
                table: "ItemsCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Pedidos_PedidoId_Pedido",
                table: "ItemsCarrito");

            migrationBuilder.DropIndex(
                name: "IX_ItemsCarrito_Id_Producto",
                table: "ItemsCarrito");

            migrationBuilder.DropIndex(
                name: "IX_ItemsCarrito_PedidoId_Pedido",
                table: "ItemsCarrito");

            migrationBuilder.DropColumn(
                name: "PedidoId_Pedido",
                table: "ItemsCarrito");

            migrationBuilder.RenameColumn(
                name: "Id_Producto",
                table: "ItemsCarrito",
                newName: "ID_Producto");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId_Producto",
                table: "ItemsCarrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_ProductoId_Producto",
                table: "ItemsCarrito",
                column: "ProductoId_Producto");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Productos_ProductoId_Producto",
                table: "ItemsCarrito",
                column: "ProductoId_Producto",
                principalTable: "Productos",
                principalColumn: "Id_Producto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
