using System.Data.Entity.ModelConfiguration;
using Day_IPG_Sample.Models;

namespace Day_IPG_Sample.DayContext.MappingConfigurations
{
    public class InstalmentsMappingConfiguration : EntityTypeConfiguration<Instalments>
    {
        public InstalmentsMappingConfiguration()
        {
            ToTable("Vie_Instalments", "Instalment");

            HasKey(x => x.Id);

            Property(x => x.NationalCode).IsRequired().IsUnicode(false).HasMaxLength(10);

            Property(x => x.Price).HasColumnType("DECIMAL");
        }
    }
}