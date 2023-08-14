using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaGrupoPlatino.Dtos.AulaDtos;
using PruebaTecnicaGrupoPlatino.Models;

namespace PruebaTecnicaGrupoPlatino.Services.AulaServices
{
    public interface IAulaService
    {
        public Task<ActionResult<Aula>> PostAlumno(AulaDto aulaDTO);

    }
}
