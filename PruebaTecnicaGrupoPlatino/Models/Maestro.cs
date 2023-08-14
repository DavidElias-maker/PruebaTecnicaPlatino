namespace PruebaTecnicaGrupoPlatino.Models
{
    public class Maestro
    {
        public int Id { get; set; }
        public string IdSecuencia { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoNombre { get; set; }
        public string SegundoApellido { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public Boolean Activo { get; set; } = true;
    }
}
