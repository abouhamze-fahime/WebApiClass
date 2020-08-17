using System.Data.Entity.ModelConfiguration;
using Day_IPG_Sample.DayContext.Models.Instalment;
using Day_IPG_Sample.Models;

namespace Day_IPG_Sample.DayContext.MappingConfigurations
{
    public class InstalmentPaymentLogsMappingConfiguration : EntityTypeConfiguration<InstalmentPaymentLogs>
    {
        public InstalmentPaymentLogsMappingConfiguration()
        {
            ToTable("tblInstalmentPaymentsLog", "Instalment");

            HasKey(x => x.Id);
        }
    }
}