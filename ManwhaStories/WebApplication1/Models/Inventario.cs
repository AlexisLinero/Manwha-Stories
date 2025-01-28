using System.ComponentModel.DataAnnotations;

namespace ManwhaStories.Models

{
    public class Inventario
    {
        public int ID_Inventario { get; set; } // Clave primaria
        public int Id_Producto { get; set; } // Clave foránea
        public Producto Producto { get; set; } // Propiedad de navegación de tipo Producto
        public int Cantidad { get; set; }
    }
}

