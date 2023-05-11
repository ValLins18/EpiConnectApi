using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class WarningConfiguration : IEntityTypeConfiguration<Warning> {
        public void Configure(EntityTypeBuilder<Warning> builder) {
            builder.ToTable(nameof(Warning));

            builder.HasKey(x => x.WarningId);
            builder.Property(x => x.WarningId).HasColumnName(nameof(Warning.WarningId)).ValueGeneratedOnAdd();
            builder.Property(x => x.WarningDate).HasColumnName(nameof(Warning.WarningDate)).IsRequired();
            builder.Property(x => x.AlertId).HasColumnName(nameof(Warning.AlertId)).IsRequired();
            builder.Property(x => x.EmployeeId).HasColumnName(nameof(Warning.EmployeeId)).IsRequired();
        }
    }
}
