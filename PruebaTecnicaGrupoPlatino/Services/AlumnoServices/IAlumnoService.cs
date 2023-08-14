using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaGrupoPlatino.Dtos.AlumnoDtos;
using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino.Services.AlumnoServices
{
    public interface IAlumnoService
    {
        public Task<ActionResult<Alumno>> PostAlumno(AlumnoDto alumnoDTO);

        public Task<ActionResult<Alumno_Detalle>> PostMatricularAlumno(Alumno_DetalleDto alumno_detalleDTO);

    }
}
