using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaGrupoPlatino.Dtos.AlumnoDtos;
using PruebaTecnicaGrupoPlatino.Models;
using PruebaTecnicaGrupoPlatino.Services.AlumnoServices;

namespace PruebaTecnicaGrupoPlatino.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AlumnoController : Controller
    {
        private readonly IAlumnoService _AlumnoService;

        public AlumnoController(IAlumnoService AlumnoService)
        {
            this._AlumnoService = AlumnoService;
        }

        [HttpPost]
        public async Task<ActionResult<Alumno>> PostAlumno (AlumnoDto alumnoDTO)
        {

            var AlumnoPost = await _AlumnoService.PostAlumno(alumnoDTO);

            return AlumnoPost;

        }

        [HttpPost("PostMatricularAlumno")]
        public async Task<ActionResult<Alumno_Detalle>> PostMatricularAlumno(Alumno_DetalleDto alumno_detalleDTO)
        {
            var AlumnoPostMatricular = await _AlumnoService.PostMatricularAlumno(alumno_detalleDTO);

            return AlumnoPostMatricular;

        }




    }
}
