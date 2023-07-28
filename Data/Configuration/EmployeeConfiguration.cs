using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee> {
        public void Configure(EntityTypeBuilder<Employee> builder) {
            builder.ToTable(nameof(Employee));

            builder.HasBaseType<Person>();
            builder.Property(e => e.PersonId).HasColumnName(nameof(Person.PersonId));
            builder.Property(e => e.Name).HasColumnName(nameof(Employee.Name)).HasMaxLength(50).IsRequired();
            builder.Property(e => e.AddressId).HasColumnName(nameof(Employee.AddressId));
            builder.Property(e => e.PhoneId).HasColumnName(nameof(Employee.PhoneId));
            builder.Property(e => e.PostId).HasColumnName(nameof(Employee.PostId));
            builder.Property(e => e.BirthDate).HasColumnName(nameof(Employee.BirthDate));
            builder.Property(e => e.EntryDate).HasColumnName(nameof(Employee.EntryDate));
            builder.Property(e => e.Document).HasColumnName(nameof(Employee.Document)).HasMaxLength(15);
            builder.Property(e => e.UserId).HasColumnName(nameof(Employee.UserId)).IsRequired(false);
            builder.Property(e => e.Workshift).HasColumnName(nameof(Employee.Workshift)).HasMaxLength(10).IsRequired(false);

        }
    }
}
