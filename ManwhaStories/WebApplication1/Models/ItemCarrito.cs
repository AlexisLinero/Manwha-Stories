using ManwhaStories.Models;

public class ItemCarrito
{
    public int Id { get; set; }
    public int Id_Producto { get; set; }
    public int Cantidad { get; set; }
    public int ID_Carrito { get; set; }

    // Propiedades de navegación
    public Carrito Carrito { get; set; }
    public Producto Producto { get; set; }
}
