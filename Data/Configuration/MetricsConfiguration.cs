using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class MetricsConfiguration : IEntityTypeConfiguration<Metrics> {
        public void Configure(EntityTypeBuilder<Metrics> builder) {
            builder.ToTable(nameof(Metrics));

            builder.HasKey(x => x.MetricsId);
            builder.Property(x => x.MetricsId).HasColumnName(nameof(Metrics.MetricsId)).ValueGeneratedOnAdd();
            builder.Property(x => x.BatteryLevel).HasColumnName(nameof(Metrics.BatteryLevel));
            builder.Property(x => x.IsProtected).HasColumnName(nameof(Metrics.IsProtected));
            builder.Property(x => x.Noise).HasColumnName(nameof(Metrics.Noise)).IsRequired(false);
            builder.Property(x => x.IsContingency).HasColumnName(nameof(Metrics.IsContingency));
        }
    }
}
