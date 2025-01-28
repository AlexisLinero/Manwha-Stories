namespace ManwhaStories.Models
{
    public class Carrito
    {
        public int ID_Carrito { get; set; }     // Usando "ID_Carrito" para coincidir con el nombre en la base de datos
        public DateTime FechaCreacion { get; set; }

        // Relación uno a muchos: un carrito tiene muchos items
        public ICollection<ItemCarrito> Items { get; set; } = new List<ItemCarrito>();
    }
}
