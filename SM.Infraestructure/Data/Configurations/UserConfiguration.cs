using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Core.Entities;

namespace SM.Infraestructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("int"); ;

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("text");

            builder.Property(e => e.Img)
                .IsRequired()
                .HasColumnName("img")
                .HasColumnType("text");

            builder.Property(e => e.Nick)
                .IsRequired()
                .HasColumnName("nick")
                .HasColumnType("text");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasMaxLength(15)
                .IsUnicode(false);

        }
    }
}
