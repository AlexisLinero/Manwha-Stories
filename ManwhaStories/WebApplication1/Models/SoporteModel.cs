namespace ManwhaStories.Models
{
    public class SoporteModel
    {
        public int ID_Soporte { get; set; }        // Identificador del soporte
        public int ID_Usuario { get; set; }        // Identificador del usuario que solicita soporte
        public string Especialidad { get; set; }   // Área o especialidad de soporte
    }
}

