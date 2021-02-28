using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Core.Entities;

namespace SM.Infraestructure.Data.Configurations
{
    public class TypeOfConfiguration : IEntityTypeConfiguration<TypeOf>
    {
        public void Configure(EntityTypeBuilder<TypeOf> builder)
        {
            builder.ToTable("TypeOf");
            builder.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int");
             

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description")
                .HasColumnType("varchar(max)");

            
            builder.Property(e => e.IdUser).HasColumnName("idUser");



            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.TypeOf)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Type_User");
        }
    }
}
