using Entities.Concrete.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mapping.Contacts
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(b=>b.Id);
            builder.Property(b => b.PersonId);
            builder.Property(b => b.InfoType);
            builder.Property(b => b.Info);
        }
    }
}
