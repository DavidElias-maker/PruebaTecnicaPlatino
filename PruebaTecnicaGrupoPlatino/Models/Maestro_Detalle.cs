namespace PruebaTecnicaGrupoPlatino.Models
{
    public class Maestro_Detalle
    {
        public int Id { get; set; }
        public int MaestrosId { get; set; }
        public int ClasesId { get; set; }
        public Boolean Activo { get; set; } = true;
    }
}
