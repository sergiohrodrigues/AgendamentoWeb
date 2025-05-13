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

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<SchedulingModel> Scheduling { get; set; }
        public DbSet<ProfessionalModel> Professional { get; set; }
        public DbSet<EnterpriseModel> Enterprise { get; set; }
        public DbSet<AgendaBaseModel> AgendaBase { get; set; }
        public DbSet<WorkShiftModel> WorkShift { get; set; }
        public DbSet<UserModel> User { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<SchedulingModel>()
        //        .HasOne(a => a.Service)
        //        .WithMany(s => s.Schedulings)
        //        .HasForeignKey(a => a.ServiceId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<ProfessionalModel>()
        //    .HasOne(p => p.Enterprise)
        //    .WithMany(e => e.Professionals)
        //    .HasForeignKey(p => p.EnterpriseId)
        //    .OnDelete(DeleteBehavior.Restrict);


        //    modelBuilder.Entity<EnterpriseModel>(entity =>
        //    {
        //        entity.Property(e => e.Nome)
        //            .IsRequired()
        //            .HasMaxLength(100);

        //        entity.Property(e => e.Cnpj)
        //            .HasMaxLength(18);

        //        entity.Property(e => e.Email)
        //            .HasMaxLength(100);

        //        entity.Property(e => e.Telefone)
        //            .HasMaxLength(20);

        //        entity.Property(e => e.Endereco)
        //            .HasMaxLength(200);

        //        entity.Property(e => e.Ativo)
        //            .HasDefaultValue(true);
        //    });

        //    modelBuilder.Entity<ServiceModel>()
        //        .Property(s => s.Price)
        //        .HasPrecision(18, 2);

        //    modelBuilder.Entity<ClientModel>()
        //        .HasOne(c => c.Enterprise)
        //        .WithMany(e => e.Clients)
        //        .HasForeignKey(c => c.EnterpriseId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<ServiceModel>()
        //        .HasOne(s => s.Enterprise)
        //        .WithMany(e => e.Services)
        //        .HasForeignKey(s => s.EnterpriseId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<ServiceModel>()
        //        .HasOne(s => s.Professional)
        //        .WithMany(p => p.Services)
        //        .HasForeignKey(s => s.ProfessionalId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<AgendaBaseModel>()
        //        .HasKey(a => a.Id);

        //    modelBuilder.Entity<AgendaBaseModel>()
        //        .HasOne(a => a.Professional)
        //        .WithMany(p => p.AgendasBase)
        //        .HasForeignKey(a => a.ProfessionalId)
        //        .OnDelete(DeleteBehavior.Restrict);
            
        //    modelBuilder.Entity<AgendaBaseModel>()
        //        .HasOne(a => a.WorkShift)
        //        .WithMany(p => p.Times)
        //        .HasForeignKey(a => a.WorkShiftId)
        //        .OnDelete(DeleteBehavior.Restrict);


        //    //modelBuilder.Entity<ServiceModel>().HasData(
        //    //    new ServiceModel
        //    //    {
        //    //        Id = 1,
        //    //        Name = "Penteado Pétala",
        //    //        Description = "Penteado pétala, contendo taltal",
        //    //        Price = 1099.99m
        //    //    },
        //    //    new ServiceModel
        //    //    {
        //    //        Id = 2,
        //    //        Name = "Penteado Rosa",
        //    //        Description = "Penteado rosa, contendo taltal",
        //    //        Price = 1199.99m
        //    //    },
        //    //    new ServiceModel
        //    //    {
        //    //        Id = 3,
        //    //        Name = "Penteado Bouquet",
        //    //        Description = "Penteado bouquet, contendo taltal",
        //    //        Price = 1299.99m
        //    //    },
        //    //    new ServiceModel
        //    //    {
        //    //        Id = 4,
        //    //        Name = "Penteado Premium",
        //    //        Description = "Penteado premium, contendo taltal",
        //    //        Price = 1399.99m
        //    //    }
        //    //);
        //}

    }
}
