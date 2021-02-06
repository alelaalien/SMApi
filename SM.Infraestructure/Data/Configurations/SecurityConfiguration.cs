using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Core.Entities;
using SM.Core.Enumerations;
using System;

namespace SM.Infraestructure.Data.Configurations
{
   public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Security");
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("int"); ;

            builder.Property(e => e.User)
                .HasColumnName("users")
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(e => e.UserName)
                 .HasColumnName("userName")
                 .IsRequired()
                 .HasMaxLength(20)
                 .IsUnicode(false);

            builder.Property(e => e.Pass)
                .HasColumnName("pass")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Role)
                .HasColumnName("rol")
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasConversion(
                 x=> x.ToString(),
                 x=> (RoleType)Enum.Parse(typeof(RoleType), x)
                 );


        }
    }
}
