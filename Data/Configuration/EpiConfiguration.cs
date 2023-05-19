using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class EpiConfiguration : IEntityTypeConfiguration<Epi> {
        public void Configure(EntityTypeBuilder<Epi> builder) {
            builder.ToTable(nameof(Epi), "dbo");

            builder.HasKey(x => x.EpiId);
            builder.Property(x => x.EpiId).HasColumnName(nameof(Epi.EpiId)).ValueGeneratedOnAdd();
            builder.Property(x => x.ProtectionType).HasColumnName("ProtectionType");
            builder.Property(x => x.ExpiryDate).HasColumnName(nameof(Epi.ExpiryDate));
            builder.Property(x => x.ManufacturingDate).HasColumnName(nameof(Epi.ManufacturingDate));
            builder.Property(x => x.Name).HasColumnName(nameof(Epi.Name));
            builder.Property(x => x.EmployeeId).HasColumnName(nameof(Epi.EmployeeId));
            builder.Property(x => x.MetricsId).HasColumnName(nameof(Epi.MetricsId));
        }
    }
}
