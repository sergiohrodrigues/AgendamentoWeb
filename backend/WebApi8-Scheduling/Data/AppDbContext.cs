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

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<SchedulingModel> Scheduling { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais, se necessário
            modelBuilder.Entity<SchedulingModel>()
                .HasOne(a => a.Client)
                .WithMany(c => c.Schedulings)
                .HasForeignKey(a => a.ClientId);

            modelBuilder.Entity<SchedulingModel>()
                .HasOne(a => a.Service)
                .WithMany(s => s.Schedulings)
                .HasForeignKey(a => a.ServiceId);

            modelBuilder.Entity<UserModel>()
                .HasMany(a => a.Clients)
                .WithOne(c => c.User)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<ServiceModel>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ServiceModel>().HasData(
                new ServiceModel
                {
                    Id = 1,
                    Name = "Penteado Pétala",
                    Description = "Penteado pétala, contendo taltal",
                    Price = 1099.99m
                },
                new ServiceModel
                {
                    Id = 2,
                    Name = "Penteado Rosa",
                    Description = "Penteado rosa, contendo taltal",
                    Price = 1199.99m
                },
                new ServiceModel
                {
                    Id = 3,
                    Name = "Penteado Bouquet",
                    Description = "Penteado bouquet, contendo taltal",
                    Price = 1299.99m
                },
                new ServiceModel
                {
                    Id = 4,
                    Name = "Penteado Premium",
                    Description = "Penteado premium, contendo taltal",
                    Price = 1399.99m
                }
            );
        }

    }
}
