using System.Data.Entity;
using Day_IPG_Sample.DayContext.MappingConfigurations;
using Day_IPG_Sample.DayContext.Models.Account;

namespace Day_IPG_Sample.DayContext
{
    public class DayContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<OTPRequests> OTPRequests{ get; set; }

        public DayContext() : base("name=DayConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsersMappingConfiguration());
            modelBuilder.Configurations.Add(new OTPRequestsMappingConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}