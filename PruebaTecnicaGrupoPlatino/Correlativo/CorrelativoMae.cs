using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino
{
    public class CorrelativoMae
    {

        private readonly ApplicationDbContext _context;
        public CorrelativoMae(ApplicationDbContext context)
        {
            this._context = context;
        }

        public string GenerarIdentificadorPersonalizado()
        {
            const string prefijo = "MAE";
            const int Longitud = 3;

            int UltimoNumero = ObtenerUltimoNumeroBD();

            int SiguienteNombre = UltimoNumero + 1;

            string NumeroFormato = SiguienteNombre.ToString().PadLeft(Longitud, '0');

            string Identificador = prefijo + NumeroFormato;

            return Identificador;
        }

        public int ObtenerUltimoNumeroBD()
        {
            var UltimoRegistroMaestro = _context.maestro
        .OrderByDescending(a => a.Id)
        .FirstOrDefault();

            if (UltimoRegistroMaestro == null)
            {

                return 0;
            }

            return UltimoRegistroMaestro.Id;
        }
    }
}
