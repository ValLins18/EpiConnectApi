using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId).HasColumnName(nameof(User.UserId));
            builder.Property(x => x.Email).HasColumnName(nameof(User.Email)).IsRequired();
            builder.Property(x => x.Password).HasColumnName(nameof(User.Password)).IsRequired();
        }
    }
}
