using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class AlertConfiguration : IEntityTypeConfiguration<Alert> {
        public void Configure(EntityTypeBuilder<Alert> builder) {
            builder.ToTable(nameof(Alert));

            builder.HasKey(x => x.AlertId);
            builder.Property(x => x.AlertId).HasColumnName(nameof(Alert.AlertId)).ValueGeneratedOnAdd();
            builder.Property(x => x.DangerousLevel).HasColumnName(nameof(Alert.DangerousLevel)).IsRequired();
            builder.Property(x => x.MetricsId).HasColumnName(nameof(Alert.MetricsId)).IsRequired();
            builder.Property(x => x.EpiId).HasColumnName(nameof(Alert.EpiId)).IsRequired();
            builder.Property(x => x.AlertDate).HasColumnName(nameof(Alert.AlertDate)).IsRequired();
        }
    }
}
