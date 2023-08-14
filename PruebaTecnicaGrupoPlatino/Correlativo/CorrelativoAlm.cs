using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino
{
    public class CorrelativoAlm
    {
        private readonly ApplicationDbContext _context;
        public CorrelativoAlm(ApplicationDbContext context)
        {
            this._context = context;
        }

        public string GenerarIdentificadorPersonalizado()
        {
            const string prefijo = "AULM";
            const int Longitud = 3;

            int UltimoNumero = ObtenerUltimoNumeroBD();

            int SiguienteNombre = UltimoNumero + 1;

            string NumeroFormato = SiguienteNombre.ToString().PadLeft(Longitud, '0');

            string Identificador = prefijo + NumeroFormato;

            return Identificador;
        }

        public int ObtenerUltimoNumeroBD()
        {
            var UltimoRegistroEstudiante = _context.alumno
        .OrderByDescending(a => a.Id)
        .FirstOrDefault();

            if (UltimoRegistroEstudiante == null)
            {

                return 0;
            }

            return UltimoRegistroEstudiante.Id;
        }


    }
}
