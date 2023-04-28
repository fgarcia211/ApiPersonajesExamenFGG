using ApiPersonajesExamenFGG.Models;
using ApiPersonajesExamenFGG.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesExamenFGG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpGet]
        [Route("[action]/{idserie}")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajesSerie(int idserie)
        {
            return await this.repo.GetPersonajesSerieAsync(idserie);
        }

        [HttpPost]
        public async Task<ActionResult> InsertPersonaje(Personaje personaje)
        {
            await this.repo.InsertPersonajeAsync(personaje);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            Personaje p = await this.repo.FindPersonajeAsync(personaje.IdPersonaje);
            if (p != null)
            {
                await this.repo.UpdatePersonajeAsyncs(personaje);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{idpersonaje}")]
        public async Task<ActionResult> DeletePersonaje(int idpersonaje)
        {
            Personaje p = await this.repo.FindPersonajeAsync(idpersonaje);
            if (p != null)
            {
                await this.repo.DeletePersonajeAsync(idpersonaje);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
