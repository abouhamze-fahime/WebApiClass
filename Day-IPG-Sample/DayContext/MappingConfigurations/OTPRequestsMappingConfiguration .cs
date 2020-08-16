using System.Data.Entity.ModelConfiguration;
using Day_IPG_Sample.DayContext.Models.Account;

namespace Day_IPG_Sample.DayContext.MappingConfigurations
{
    public class OTPRequestsMappingConfiguration : EntityTypeConfiguration<OTPRequests>
    {
        public OTPRequestsMappingConfiguration()
        {
            ToTable("tblOTPRequests", "Account");

            HasKey(x => new
            {
                x.NationalCode, x.Code
            });
            Property(x => x.NationalCode).IsUnicode(false).HasMaxLength(10);
        }
    }
}