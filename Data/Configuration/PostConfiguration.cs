using EpiConnectAPI.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EpiConnectAPI.Data.Configuration {
    public class PostConfiguration : IEntityTypeConfiguration<Post> {
        public void Configure(EntityTypeBuilder<Post> builder) {
            builder.ToTable(nameof(Post));

            builder.HasKey(x => x.PostId);
            builder.Property(x => x.PostId).HasColumnName(nameof(Post.PostId)).ValueGeneratedOnAdd();
            builder.Property(x => x.Salary).HasColumnName(nameof(Post.Salary)).HasPrecision(10,2);
            builder.Property(x => x.DepartmentId).HasColumnName(nameof(Post.DepartmentId));

        }
    }
}
