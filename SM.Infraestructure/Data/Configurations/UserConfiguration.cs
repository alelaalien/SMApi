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
                .HasColumnName("email");
 

            builder.Property(e => e.Nick)
                .IsRequired()
                .HasColumnName("nick");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .IsUnicode(false);

        }
    }
}
