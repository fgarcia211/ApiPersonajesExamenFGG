using ApiPersonajesExamenFGG.Data;
using ApiPersonajesExamenFGG.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesExamenFGG.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int idpersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idpersonaje);
        }

        public async Task<List<Personaje>> GetPersonajesSerieAsync(int idserie)
        {
            return await this.context.Personajes.Where(x => x.IdSerie == idserie).ToListAsync();
        }

        private int GetMaxIDPersonajes()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Personajes.Max(z => z.IdPersonaje) + 1;
            }
        }

        public async Task InsertPersonajeAsync(Personaje personaje)
        {
            Personaje p = new Personaje
            {
                IdPersonaje = this.GetMaxIDPersonajes(),
                Nombre = personaje.Nombre,
                Imagen = personaje.Imagen,
                IdSerie = personaje.IdSerie
            };

            this.context.Personajes.Add(p);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeAsync(int idpersonaje)
        {
            this.context.Personajes.Remove(await this.FindPersonajeAsync(idpersonaje));
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsyncs(Personaje personaje)
        {
            Personaje p = await this.FindPersonajeAsync(personaje.IdPersonaje);

            p.Nombre = personaje.Nombre;
            p.IdSerie = personaje.IdSerie;
            p.Imagen = personaje.Imagen;

            await this.context.SaveChangesAsync();
        }
    }
}
