using AutoMapper;
using PruebaTecnicaGrupoPlatino.Dtos.AlumnoDtos;
using PruebaTecnicaGrupoPlatino.Dtos.AulaDtos;
using PruebaTecnicaGrupoPlatino.Dtos.ClaseDtos;
using PruebaTecnicaGrupoPlatino.Dtos.MaestroDtos;
using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino.Utilities
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<AlumnoDto, Alumno>().ReverseMap();

            CreateMap<AulaDto, Aula>().ReverseMap();

            CreateMap<ClaseDto, Clase>().ReverseMap();

            CreateMap<MaestroDto, Maestro>().ReverseMap();

            CreateMap<Alumno_DetalleDto, Alumno_Detalle>().ReverseMap();

            CreateMap<Clase_DetalleDto, Alumno_Detalle>().ReverseMap();

            CreateMap<Maestro_DetalleDto, Maestro_Detalle>().ReverseMap();
        }
       
    }
}
