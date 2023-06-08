using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone> {
        public void Configure(EntityTypeBuilder<Phone> builder) {
            builder.ToTable(nameof(Phone));

            builder.HasKey(Phone => Phone.PhoneId);
            builder.Property(Phone => Phone.PhoneId).HasColumnName(nameof(Phone.PhoneId)).ValueGeneratedOnAdd().IsRequired();
            builder.Property(Phone => Phone.DDD).HasColumnName(nameof(Phone.DDD)).IsRequired();
            builder.Property(Phone => Phone.PhoneNumber).HasColumnName(nameof(Phone.PhoneNumber)).IsRequired();
        }
    }
}
