using Microsoft.EntityFrameworkCore;
using SM.Core.Entities;
using System.Reflection;

namespace SM.Infraestructure.Data
{
    public partial class SMContext : DbContext
    {
        public SMContext()
        {
        }

        public SMContext(DbContextOptions<SMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Subjet> Subjet { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<TypeOf> TypeOf { get; set; }
        public virtual DbSet<Dictates> Dictates { get; set; }
        public virtual DbSet<Security> Securities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
