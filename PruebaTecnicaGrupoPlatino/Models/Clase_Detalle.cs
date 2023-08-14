namespace PruebaTecnicaGrupoPlatino.Models
{
    public class Clase_Detalle
    {
        public int Id { get; set; }
        public int AulasId { get; set; }
        public Boolean Activo { get; set; } = true;
        public int ClasesId { get; set; }
        public DateTime HoraInicio { get; set; }
    }
}
