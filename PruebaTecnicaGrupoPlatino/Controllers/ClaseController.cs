using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaGrupoPlatino.Dtos.ClaseDtos;
using PruebaTecnicaGrupoPlatino.Models;
using PruebaTecnicaGrupoPlatino.Services.ClaseServices;

namespace PruebaTecnicaGrupoPlatino.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ClaseController : Controller
    {

        private readonly IClaseService _ClaseService;

        public ClaseController(IClaseService ClaseService)
        {
            this._ClaseService = ClaseService;
        }

        [HttpPost]
        public async Task<ActionResult<Clase>> PostClase (ClaseDto claseDTO)
        {

            var IngresarClase = await _ClaseService.PostClase(claseDTO);

            return IngresarClase;
            
           
        }

        [HttpPost("PostAsignarClaseaAula")]
        public async Task<ActionResult<Clase_Detalle>> PostAsignarClaseaAula (Clase_DetalleDto clase_detalleDTO)
        {

            var IngresarAsignarClase = await _ClaseService.PostAsignarClaseaAula(clase_detalleDTO);

            return IngresarAsignarClase;

        }

    }
}
