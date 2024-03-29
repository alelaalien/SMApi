﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Core.Entities;

namespace SM.Infraestructure.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("int"); 
            builder.Property(e => e.Active).HasColumnName("active");

            builder.Property(e => e.Date)
                .HasColumnName("date")
                .HasColumnType("smalldatetime");

            builder.Property(e => e.IdSubjet).HasColumnName("idSubjet");

            builder.Property(e => e.IdUser)
                .HasColumnName("idUser");

            builder.Property(e => e.Notes)
                .IsRequired()
                .HasColumnName("notes")
                .HasColumnType("text");

            builder.Property(e => e.Priority).HasColumnName("priority");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasColumnType("text");

            builder.Property(e => e.TypeId)
                .HasColumnName("typeId");

            builder.HasOne(d => d.IdSubjetNavigation)
                .WithMany(p => p.Event)
                .HasForeignKey(d => d.IdSubjet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_Subjet");

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Event)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_User");

            builder.HasOne(d => d.IdTypeOfNavigation)
                .WithMany(p => p.Event)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_TypeOf");

        }
    }
}
