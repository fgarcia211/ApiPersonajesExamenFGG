using ApiPersonajesExamenFGG.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesExamenFGG.Data
{
    public class PersonajesContext : DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options): base(options) { }

        public DbSet<Personaje> Personajes { get; set; }
    }
}
