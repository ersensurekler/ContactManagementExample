using Core.DbContexts;
using DataAccess.Concrete.EntityFramework.Mapping.Contacts;
using Entities.Concrete.Contacts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public partial class ContactManagementContext : DbContext, IDbContext
    {
        public ContactManagementContext(DbContextOptions<ContactManagementContext> options)
            : base(options)
        { }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMapping());
        }
    }
}
