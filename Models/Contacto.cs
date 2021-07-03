namespace ffrs.mvc.Models
{
    public class Contacto
    {
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}