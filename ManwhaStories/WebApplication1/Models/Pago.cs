namespace ManwhaStories.Models

{
    public class Pago
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MedioPago { get; set; } = string.Empty;
        public int PedidoId { get; set; }
    }
}

