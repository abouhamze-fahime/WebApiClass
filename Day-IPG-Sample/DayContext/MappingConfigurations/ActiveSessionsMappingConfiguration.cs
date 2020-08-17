using System.Data.Entity.ModelConfiguration;
using Day_IPG_Sample.DayContext.Models.Account;

namespace Day_IPG_Sample.DayContext.MappingConfigurations
{
    public class ActiveSessionsMappingConfiguration : EntityTypeConfiguration<ActiveSessions>
    {
        public ActiveSessionsMappingConfiguration()
        {
            ToTable("tblActiveSessions", "Account");

            HasKey(x => x.Id);
            Property(x => x.NationalCode).IsUnicode(false).HasMaxLength(10);
            Property(x => x.IP).IsUnicode(false).HasMaxLength(15);
        }
    }
}