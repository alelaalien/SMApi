using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Core.Entities;
using System;

namespace SM.Infraestructure.Data.Configurations
{
    class DicatetesConfiguration : IEntityTypeConfiguration<Dictates>
    {
        public void Configure(EntityTypeBuilder<Dictates> builder)
        {
            
            builder.ToTable("Dictates");
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("int");
            builder.Property(e => e.SubjetId)
                .HasColumnName("subjetId")
                .HasColumnType("int");
            builder.Property(e => e.TeacherId)
                .HasColumnName("teacherId")
                .HasColumnType("int");
        }
    }
}
