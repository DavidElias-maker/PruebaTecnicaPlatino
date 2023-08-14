using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino
{
    public class CorrelativoAu
    {
       
            private readonly ApplicationDbContext _context;
            public CorrelativoAu(ApplicationDbContext context)
            {
                this._context = context;
            }

            public string GenerarIdentificadorPersonalizado()
            {
                const string prefijo = "AU";
                const int Longitud = 0;

                int UltimoNumero = ObtenerUltimoNumeroBD();

                int SiguienteNombre = UltimoNumero + 1;

                string NumeroFormato = SiguienteNombre.ToString().PadLeft(Longitud, '0');

                string Identificador = prefijo + NumeroFormato;

                return Identificador;
            }

            public int ObtenerUltimoNumeroBD()
            {
                var UltimoRegistroAula = _context.aula
            .OrderByDescending(a => a.Id)
            .FirstOrDefault();

                if (UltimoRegistroAula == null)
                {

                    return 0;
                }

                return UltimoRegistroAula.Id;
            }


        }

    }

