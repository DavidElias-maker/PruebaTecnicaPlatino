using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaGrupoPlatino.Dtos.ClaseDtos;
using PruebaTecnicaGrupoPlatino.Error;
using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino.Services.ClaseServices
{


    public class ClaseService : ControllerBase, IClaseService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public ClaseService(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;


        }


        public async Task<ActionResult<Clase_Detalle>> PostAsignarClaseaAula(Clase_DetalleDto clase_detalleDTO)
        {
            try
            {

                TimeSpan HoraInicio = TimeSpan.FromHours(8);
                TimeSpan HoraFin = TimeSpan.FromHours(17);

                var AulaRangoFecha = await _context.clase_detalle
                    .AnyAsync(x => x.Activo &&
                                   (x.HoraInicio.TimeOfDay >= HoraInicio && x.HoraInicio.TimeOfDay <= HoraFin));

                if (AulaRangoFecha)
                {
                    return BadRequest(ClaseErrorMessages.RDHI);
                }

                var Clases = _mapper.Map<Clase_DetalleDto>(clase_detalleDTO);

                _context.Add(Clases);
                await _context.SaveChangesAsync();
                return Ok(Clases);
            }
            catch
            {
                return BadRequest(ClaseErrorMessages.HOUE);
            }
        }

        public async Task<ActionResult<Clase>> PostClase(ClaseDto claseDTO)
        {
            try
            {

                var ClaseMismoNombre = await _context.clase.AnyAsync(x => x.Materia == claseDTO.Materia && x.Activo == true);

                if (ClaseMismoNombre)
                {
                    return BadRequest(ClaseErrorMessages.YECCEMN);
                }

                var Clases = _mapper.Map<Clase>(claseDTO);

                _context.Add(Clases);
                await _context.SaveChangesAsync();
                return Ok(Clases);
            }
            catch
            {
                return BadRequest(ClaseErrorMessages.HOUE);
            }
        }
    }
}
