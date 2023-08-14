namespace PruebaTecnicaGrupoPlatino.Models
{
    public class Aula
    {
        public int Id { get; set; }
        public string IdSecuencia { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }
        public Boolean Activo { get; set; } = true;
    }
}
