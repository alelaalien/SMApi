using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Core.Entities;

namespace SM.Infraestructure.Data.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher");

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(e => e.Celphone)
                .IsRequired()
                .HasColumnName("celphone")
                .HasColumnType("int");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("text");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("text");

            builder.Property(e => e.Nick)
                .IsRequired()
                .HasColumnName("nick")
                .HasColumnType("text");
 

            builder.Property(e => e.Subjet)
                .IsRequired()
                .HasColumnName("subjet")
                .HasColumnType("int");

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasColumnName("surname")
                .HasColumnType("text");

            builder.Property(e => e.IdUser).HasColumnName("idUser")
                .HasColumnType("int"); ;

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Teacher)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_User");




        }
    }
}
