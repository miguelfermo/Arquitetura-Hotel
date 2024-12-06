using Microsoft.EntityFrameworkCore;

namespace MicroserviceQuartos.Infra.Contexto
{
    public class QuartosContext : DbContext
    {
        public QuartosContext(DbContextOptions<QuartosContext> options) : base(options) { }

        public DbSet<Quarto> Quartos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quarto>().HasKey(e => e.Id);
        }
    }
}
