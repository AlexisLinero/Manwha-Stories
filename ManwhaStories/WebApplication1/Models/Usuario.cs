namespace ManwhaStories.Models
{
    public class Usuario
    {
        public int ID_Usuario { get; set; } // Autoincremental
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string TipoUsuario { get; set; }
        public string Direccion { get; set; }
        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
    }

}

