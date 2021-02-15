using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Core.Entities;

namespace SM.Infraestructure.Data.Configurations
{
    public class SubjetConfiguration : IEntityTypeConfiguration<Subjet>
    {
        public void Configure(EntityTypeBuilder<Subjet> builder)
        {
            builder.ToTable("Subjet");
            builder.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int");

            builder.Property(e => e.Active).HasColumnName("active");

            builder.Property(e => e.Class)
                .IsRequired()
                .HasColumnName("class")
                .HasColumnType("text");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text");

            builder.Property(e => e.IdUser).HasColumnName("idUser");

 

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Subjet)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subjet_User");
        }
    }
}
