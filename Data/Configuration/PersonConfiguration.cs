using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class PersonConfiguration : IEntityTypeConfiguration<Person> {
        public void Configure(EntityTypeBuilder<Person> builder) {
            builder.ToTable(nameof(Person));

            builder.HasKey(x => x.PersonId);
            builder.Property(x => x.PersonId).HasColumnName(nameof(Person.PersonId)).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName(nameof(Person.Name)).HasMaxLength(70);
            builder.Property(x => x.Email).HasColumnName(nameof(Person.Email)).HasMaxLength(30);
            builder.Property(x => x.BirthDate).HasColumnName(nameof(Person.BirthDate));
            builder.Property(x => x.AddressId).HasColumnName(nameof(Person.AddressId));
            builder.Property(x => x.Document).HasColumnName(nameof(Person.Document)).HasMaxLength(15);
            builder.Property(x => x.Gender).HasColumnName(nameof(Person.Gender)).HasColumnType("nvarchar(1)");
            builder.Property(x => x.ImgPath).HasColumnName(nameof(Person.ImgPath)).IsRequired(false);
            builder.Property(x => x.PhoneId).HasColumnName(nameof(Person.PhoneId));
        }
    }
}
