using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Smart_Garden.Model;

namespace Smart_Garden.DataLayer
{
    public class SmartGardenContext : DbContext
    {
        public DbSet<SensorAbove> sensorAbove { get; set; }
        public DbSet<SensorBelow> sensorBelow { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Crop> Crops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorAbove>().HasKey(c => c.Id);
            modelBuilder.Entity<SensorBelow>().HasKey(c => c.Id);
            modelBuilder.Entity<User>().HasKey(c => c.Id);
            modelBuilder.Entity<Crop>().HasKey(c => c.Id);
            modelBuilder.Entity<User>().Property(c => c.Password).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.Username).IsRequired();
            modelBuilder.Entity<SensorBelow>().Property(c => c.Time_Of_Record).IsOptional();
            modelBuilder.Entity<SensorAbove>().Property(c => c.Time_Of_Record).IsOptional();
            modelBuilder.Entity<User>().Property(c => c.Discriminator).IsRequired();

            modelBuilder.Entity<SensorBelow>().HasRequired(c => c.user)
                .WithMany().HasForeignKey(c => c.UserId);

            modelBuilder.Entity<SensorAbove>().HasRequired(c => c.user)
                .WithMany().HasForeignKey(c => c.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
