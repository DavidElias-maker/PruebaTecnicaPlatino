using PruebaTecnicaGrupoPlatino.Validations;

namespace PruebaTecnicaGrupoPlatino.Dtos.AlumnoDtos
{
    public class AlumnoDto
    {
       
        public string IdSecuencia { get; set; }
        [PrimeraLetraMayuscula]
        public string PrimerNombre { get; set; }
        [PrimeraLetraMayuscula]
        public string PrimerApellido { get; set; }
        [PrimeraLetraMayuscula]
        public string SegundoNombre { get; set; }
        [PrimeraLetraMayuscula]
        public string SegundoApellido { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
