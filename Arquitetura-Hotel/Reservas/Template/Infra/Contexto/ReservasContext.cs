using Microsoft.EntityFrameworkCore;

namespace MicroserviceReservas.Infra.Contexto
{
    public class ReservasContext : DbContext
    {
        public ReservasContext(DbContextOptions<ReservasContext> options) : base(options) { }

        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reserva>().HasKey(r => r.Id);
        }
    }
}
