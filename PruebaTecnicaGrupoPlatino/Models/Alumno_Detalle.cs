namespace PruebaTecnicaGrupoPlatino.Models
{
    public class Alumno_Detalle
    {
        public int Id { get; set; }
        public int ClasesId { get; set; }
        public Boolean Activo { get; set; } = true;
        public int AlumnosId { get; set; }
    }
}
