using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaGrupoPlatino.Dtos.AulaDtos;
using PruebaTecnicaGrupoPlatino.Error;
using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino.Services.AulaServices
{
    public class AulaService : ControllerBase, IAulaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        private readonly CorrelativoAu _correlativo;
        public AulaService(ApplicationDbContext context, CorrelativoAu correlativo, IMapper mapper)
        {
            this._context = context;
            this._correlativo = correlativo;
            this._mapper = mapper;

        }

        public async Task<ActionResult<Aula>> PostAlumno(AulaDto aulaDTO)
        {
            try
            {

                var AlumnoMismoNombre = await _context.aula.AnyAsync(x => x.IdSecuencia == aulaDTO.IdSecuencia && x.Activo == true);

                if (AlumnoMismoNombre)
                {
                    return BadRequest(AulaErrorMessages.YEUACEMC);
                }

                string Identificador = _correlativo.GenerarIdentificadorPersonalizado();

                aulaDTO.IdSecuencia = Identificador;

                var Aulas = _mapper.Map<Aula>(aulaDTO);

                _context.Add(Aulas);

                await _context.SaveChangesAsync();

                return Ok(Aulas);
            }
            catch
            {
                return BadRequest(AulaErrorMessages.HOUE);
            }
        }
    }
}
