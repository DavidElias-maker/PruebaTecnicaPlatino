using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaGrupoPlatino.Dtos.MaestroDtos;
using PruebaTecnicaGrupoPlatino.Error;
using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino.Services.MaestroServices
{
    public class MaestroService : ControllerBase, IMaestroService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        private readonly CorrelativoMae _correlativo;
        public MaestroService(ApplicationDbContext context, CorrelativoMae correlativo, IMapper mapper)
        {
            this._context = context;
            this._correlativo = correlativo;
            this._mapper = mapper;

        }
        public async Task<ActionResult<Maestro>> PostMaestro(MaestroDto maestroDTO)
        {

            try
            {

                var MaestroMismoNombre = await _context.maestro.AnyAsync(x => x.PrimerNombre == maestroDTO.PrimerNombre && x.PrimerApellido == maestroDTO.PrimerApellido && x.SegundoNombre == maestroDTO.SegundoNombre && x.SegundoApellido == maestroDTO.SegundoApellido && x.Correo == maestroDTO.Correo && x.Telefono == maestroDTO.Telefono && x.Activo == true);

                if (MaestroMismoNombre)
                {
                    return BadRequest(MaestroErrorMessages.YEMCEMN);
                }

                string Identificador = _correlativo.GenerarIdentificadorPersonalizado();

                maestroDTO.IdSecuencia = Identificador;

                var Maestros = _mapper.Map<Maestro>(maestroDTO);

                _context.Add(Maestros);

                await _context.SaveChangesAsync();

                return Ok(Maestros);
            }
            catch
            {
                return BadRequest(MaestroErrorMessages.HOUE);
            }
        }

        public async Task<ActionResult<Maestro_Detalle>> PostMatricularAlumno(Maestro_DetalleDto maestro_detalleDTO)
        {
            try
            {

                var maestroDetalles = _context.maestro_detalle
                .Where(x => x.MaestrosId == maestro_detalleDTO.MaestrosId)
                .ToList();
                List<int> claseIds = new List<int>();

                var ClaseHora2 = (from f in _context.clase_detalle
                                  where f.ClasesId == maestro_detalleDTO.ClasesId
                                  orderby f.Id
                                  select f.HoraInicio.TimeOfDay).FirstOrDefault();


                foreach (var detalle in maestroDetalles)
                {
                    int claseId = detalle.ClasesId;
                    claseIds.Add(claseId);
                }

                foreach (int claseId in claseIds)
                {
                    var ClaseHora1 = (from f in _context.clase_detalle
                                      where f.ClasesId == claseId
                                      orderby f.Id
                                      select f.HoraInicio.TimeOfDay).FirstOrDefault();


                    if (ClaseHora1 == ClaseHora2)
                    {
                        return BadRequest(MaestroErrorMessages.EMYTAEH);

                    }
                }

                var Maestros = _mapper.Map<Maestro_Detalle>(maestro_detalleDTO);

                _context.Add(Maestros);
                await _context.SaveChangesAsync();
                return Ok(Maestros);
            }
            catch
            {
                return BadRequest(MaestroErrorMessages.HOUE);
            }
        }
    }
}
