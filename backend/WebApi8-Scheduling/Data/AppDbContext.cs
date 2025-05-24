using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<ServicoModel> Servico { get; set; }
        public DbSet<AgendamentoModel> Agendamento { get; set; }
        public DbSet<ProfissionalModel> Profissional { get; set; }
        public DbSet<EmpresaModel> Empresa { get; set; }
        
        public DbSet<WorkShiftModel> WorkShift { get; set; }
        public DbSet<AgendaIndisponivelModel> AgendaIndisponivel { get; set; }
        public DbSet<ProfissionalServico> ProfissionalServico { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfissionalServico>()
                .HasKey(ps => new { ps.ProfissionalId, ps.ServicoId });
        }
        

    }
}
