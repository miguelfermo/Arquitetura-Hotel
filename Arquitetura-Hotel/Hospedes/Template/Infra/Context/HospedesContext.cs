using Microsoft.EntityFrameworkCore;

namespace MicroserviceHospedes.Infra.Contexto
{
    public class HospedesContext : DbContext
    {
        public HospedesContext(DbContextOptions<HospedesContext> options) : base(options) { }

        public DbSet<Hospede> Hospedes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hospede>().HasKey(h => h.Id);
        }
    }
}
