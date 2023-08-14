using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaGrupoPlatino.Dtos.MaestroDtos;
using PruebaTecnicaGrupoPlatino.Models;
using PruebaTecnicaGrupoPlatino.Services.MaestroServices;

namespace PruebaTecnicaGrupoPlatino.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MaestroController : Controller
    {
        private readonly IMaestroService _MaestroService;

        public MaestroController(IMaestroService MaestroService)
        {
            this._MaestroService = MaestroService;
        }

        [HttpPost]
        public async Task<ActionResult<Maestro>> PostMaestro(MaestroDto maestroDTO)
        {
            var IngresarMaestro = await _MaestroService.PostMaestro(maestroDTO);

            return IngresarMaestro;

        }

        [HttpPost("PostAsignarClaseMaestro")]
        public async Task<ActionResult<Maestro_Detalle>> PostMatricularAlumno(Maestro_DetalleDto maestro_detalleDTO)
        {

            var AsignarMaestro = await _MaestroService.PostMatricularAlumno(maestro_detalleDTO);

            return AsignarMaestro;

        }


    }
}
