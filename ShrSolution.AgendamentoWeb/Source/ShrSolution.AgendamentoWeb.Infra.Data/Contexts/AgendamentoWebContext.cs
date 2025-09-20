using Microsoft.EntityFrameworkCore;
using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Contexts
{
    public class AgendamentoWebContext : DbContext
    {
        public AgendamentoWebContext()
        {
        }

        public AgendamentoWebContext(DbContextOptions<AgendamentoWebContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        // public DbSet<Servico> Servico { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        // public DbSet<AgendaIndisponivel> AgendaIndisponivel { get; set; }
        // public DbSet<ProfissionalServico> ProfissionalServico { get; set; }
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<ProfissionalServico>()
        //         .HasKey(ps => new { ps.ProfissionalId, ps.ServicoId });
        // }
    }
}
