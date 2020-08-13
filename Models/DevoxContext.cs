using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DevoxAPI.Models
{
    public partial class DevoxContext : DbContext
    {
        public DevoxContext()
        {
        }

        public DevoxContext(DbContextOptions<DevoxContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder().
                    SetBasePath(AppDomain.CurrentDomain.BaseDirectory).
                    AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("DevoxDB"));
            }
        }
        
        
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
