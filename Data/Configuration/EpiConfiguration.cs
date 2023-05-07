using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class EpiConfiguration : IEntityTypeConfiguration<Epi> {
        public void Configure(EntityTypeBuilder<Epi> builder) {
            builder.ToTable(nameof(Epi));

            builder.HasKey(x => x.EpiId);
            builder.Property(x => x.EpiId).HasColumnName(nameof(Epi.EpiId)).ValueGeneratedOnAdd();
            builder.Property(x => x.ProtectionType).HasColumnType(nameof(Epi.ProtectionType));
            builder.Property(x => x.ExpiryDate).HasColumnType(nameof(Epi.ExpiryDate));
            builder.Property(x => x.ManufacturingDate).HasColumnType(nameof(Epi.ManufacturingDate));
            builder.Property(x => x.Name).HasColumnType(nameof(Epi.Name));
            builder.Property(x => x.EmployeeId).HasColumnType(nameof(Epi.EmployeeId));
            builder.Property(x => x.MetricsId).HasColumnType(nameof(Epi.MetricsId));
        }
    }
}
