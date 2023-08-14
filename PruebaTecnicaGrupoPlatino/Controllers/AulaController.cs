using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaGrupoPlatino.Dtos.AulaDtos;
using PruebaTecnicaGrupoPlatino.Models;
using PruebaTecnicaGrupoPlatino.Services.AulaServices;

namespace PruebaTecnicaGrupoPlatino.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AulaController : Controller
    {
        private readonly IAulaService _AulaService;

        public AulaController(IAulaService AlumnoService)
        {
            this._AulaService = AlumnoService;
        }


        [HttpPost]
        public async Task<ActionResult<Aula>> PostAlumno(AulaDto aulaDTO)
        {
            var PostAlumnos = await _AulaService.PostAlumno(aulaDTO);

            return PostAlumnos;

        }

    }
}
