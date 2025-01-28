namespace ManwhaStories.Models
{
    public class Pedido
    {
        public int Id_Pedido { get; set; } // ID del pedido
        public int Id_Carrito { get; set; } // ID del carrito relacionado

        // Propiedad de navegación a Carrito
        public Carrito Carrito { get; set; }

        public decimal Total { get; set; } // Total calculado al finalizar el carrito
        public DateTime FechaPedido { get; set; } // Fecha y hora del pedido
        public string Estado { get; set; } = "Pendiente"; // Estado inicial del pedido

        public List<ItemCarrito> ItemsCarrito { get; set; } = new List<ItemCarrito>();
    }
}

