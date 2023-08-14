using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaGrupoPlatino.Dtos.MaestroDtos;
using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino.Services.MaestroServices
{
    public interface IMaestroService
    {
        public Task<ActionResult<Maestro>> PostMaestro(MaestroDto maestroDTO);

        public  Task<ActionResult<Maestro_Detalle>> PostMatricularAlumno(Maestro_DetalleDto maestro_detalleDTO);

    }
}
