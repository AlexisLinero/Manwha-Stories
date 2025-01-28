namespace ManwhaStories.Models
{
    public class ResumenCompra
    {
        public string NombreCliente { get; set; }
        public string Ciudad { get; set; }
        public string DireccionEnvio { get; set; }
        public decimal TotalCarrito { get; set; }
        public decimal ValorEnvio { get; set; }
        public decimal ValorTotal { get; set; }

    }
}
