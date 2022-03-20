using Core.DbContexts;
using DataAccess.Concrete.EntityFramework.Mapping.Contacts;
using DataAccess.Concrete.EntityFramework.Mapping.Persons;
using Entities.Concrete.Contacts;
using Entities.Concrete.Persons;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public partial class ContactManagementContext : DbContext, IDbContext
    {
        public ContactManagementContext(DbContextOptions<ContactManagementContext> options)
            : base(options)
        { }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMapping());
            modelBuilder.ApplyConfiguration(new PersonMapping());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
