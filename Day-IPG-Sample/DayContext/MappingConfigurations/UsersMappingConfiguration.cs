using System.Data.Entity.ModelConfiguration;
using Day_IPG_Sample.DayContext.Models.Account;

namespace Day_IPG_Sample.DayContext.MappingConfigurations
{
    public class UsersMappingConfiguration : EntityTypeConfiguration<Users>
    {
        public UsersMappingConfiguration()
        {
            ToTable("Vie_Users", "Account");

            HasKey(x => x.NationalCode);

            Property(x => x.NationalCode).IsRequired().IsUnicode(false).HasMaxLength(10);

            Property(x => x.MobileNumber).IsRequired().IsUnicode(false).HasMaxLength(11);

            HasIndex(x => x.NationalCode).IsUnique(true);
            HasIndex(x => x.MobileNumber).IsUnique(true);
        }
    }
}