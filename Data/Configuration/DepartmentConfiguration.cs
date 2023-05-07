using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department> {
        public void Configure(EntityTypeBuilder<Department> builder) {
            builder.ToTable(nameof(Department));
            
            builder.HasKey(department => department.DepartmentId);
            builder.Property(department => department.DepartmentId).HasColumnName(nameof(Department.DepartmentId)).ValueGeneratedOnAdd();
            builder.Property(department => department.Description).HasMaxLength(50).IsRequired();
        }
    }
}
