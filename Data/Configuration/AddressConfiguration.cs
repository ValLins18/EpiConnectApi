using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class AddressConfiguration : IEntityTypeConfiguration<Address> {
        public void Configure(EntityTypeBuilder<Address> builder) {
            
            builder.ToTable(nameof(Address));

            builder.HasKey(address => address.AddressId);
            builder.Property(address => address.AddressId).HasColumnName(nameof(Address.AddressId)).ValueGeneratedOnAdd().IsRequired();
            builder.Property(address => address.Street).HasColumnName(nameof(Address.Street)).IsRequired();
            builder.Property(address => address.Neighborhood).HasColumnName(nameof(Address.Neighborhood)).IsRequired();
            builder.Property(address => address.State).HasColumnName(nameof(Address.State)).HasMaxLength(2).IsRequired();
            builder.Property(address => address.Number).HasColumnName(nameof(Address.Number)).IsRequired();
            builder.Property(address => address.City).HasColumnName(nameof(Address.City)).HasMaxLength(50).IsRequired();
        }
    }
}
