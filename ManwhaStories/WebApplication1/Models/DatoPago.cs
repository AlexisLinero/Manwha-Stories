using System.ComponentModel.DataAnnotations;

namespace ManwhaStories.Models
{
    public class DatoPago
    {
        [Key]
        public int ID_Pago { get; set; }
        public int ID_Usuario { get; set; }
        public int Id_Pedido { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Monto { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaPago { get; set; }

    }
}
