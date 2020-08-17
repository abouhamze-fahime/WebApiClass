using System.Data.Entity;
using Day_IPG_Sample.DayContext.MappingConfigurations;
using Day_IPG_Sample.DayContext.Models.Account;
using Day_IPG_Sample.DayContext.Models.Instalment;
using Day_IPG_Sample.Models;

namespace Day_IPG_Sample.DayContext
{
    public class DayContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<OTPRequests> OTPRequests { get; set; }
        public DbSet<ActiveSessions> ActiveSessions { get; set; }

        public DbSet<Instalments> Instalments { get; set; }
        public DbSet<InstalmentPaymentLogs> InstalmentPaymentLogs { get; set; }

        public DayContext() : base("name=DayConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsersMappingConfiguration());
            modelBuilder.Configurations.Add(new OTPRequestsMappingConfiguration());
            modelBuilder.Configurations.Add(new ActiveSessionsMappingConfiguration());

            modelBuilder.Configurations.Add(new InstalmentsMappingConfiguration());
            modelBuilder.Configurations.Add(new InstalmentPaymentLogsMappingConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}