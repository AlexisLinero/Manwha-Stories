namespace ManwhaStories.Models
{
    public class Producto
    {
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Descuento { get; set; }
        public int IdCategoria { get; set; }
        public string URL { get; set; }



    }
}
