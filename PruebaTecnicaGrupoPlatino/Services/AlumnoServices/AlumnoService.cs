using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaGrupoPlatino.Dtos.AlumnoDtos;
using PruebaTecnicaGrupoPlatino.Error;
using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino.Services.AlumnoServices
{
    

    public class AlumnoService : ControllerBase, IAlumnoService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        private readonly CorrelativoAlm _correlativo;
        public AlumnoService(ApplicationDbContext context, CorrelativoAlm correlativo, IMapper mapper)
        {
            this._context = context;
            this._correlativo = correlativo;
            this._mapper = mapper;


        }


        public async Task<ActionResult<Alumno>> PostAlumno(AlumnoDto alumnoDTO)
        {
            try
            {


                var AlumnoMismoNombre = await _context.alumno.AnyAsync(x => x.PrimerNombre == alumnoDTO.PrimerNombre && x.PrimerApellido == alumnoDTO.PrimerApellido && x.SegundoNombre == alumnoDTO.SegundoNombre && x.SegundoApellido == alumnoDTO.SegundoApellido && x.Correo == alumnoDTO.Correo && x.Telefono == alumnoDTO.Telefono && x.Activo == true);

                if (AlumnoMismoNombre)
                {
                    return BadRequest(AlumnoErrorMessages.YEACEMN);
                }

                string Identificador = _correlativo.GenerarIdentificadorPersonalizado();

                alumnoDTO.IdSecuencia = Identificador;

                var alumnos = _mapper.Map<Alumno>(alumnoDTO);

                _context.Add(alumnos);

                await _context.SaveChangesAsync();

                return Ok(alumnos);
            }
            catch
            {
                return BadRequest(AlumnoErrorMessages.HOUE);
            }
        }

        public async Task<ActionResult<Alumno_Detalle>> PostMatricularAlumno(Alumno_DetalleDto alumno_detalleDTO)
        {
            try
            {

                var ContadorClases = _context.alumno_detalle
                .Where(x => x.AlumnosId == alumno_detalleDTO.AlumnosId)
                .Count();

                if (ContadorClases >= 5)
                {
                    return BadRequest(AlumnoErrorMessages.EAYTMDCC);
                }
                var alumnos = _mapper.Map<Alumno_Detalle>(alumno_detalleDTO);

                _context.Add(alumnos);
                await _context.SaveChangesAsync();
                return Ok(alumnos);
            }
            catch
            {
                return BadRequest(AlumnoErrorMessages.HOUE);
            }
        }
    }
}
