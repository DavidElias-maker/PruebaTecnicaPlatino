using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaGrupoPlatino.Dtos.ClaseDtos;
using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino.Services.ClaseServices
{
    public interface IClaseService
    {
        public Task<ActionResult<Clase>> PostClase(ClaseDto claseDTO);

        public Task<ActionResult<Clase_Detalle>> PostAsignarClaseaAula(Clase_DetalleDto clase_detalleDTO);
    }
}
