using Entities.Concrete.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mapping.Persons
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()").IsRequired();
            builder.Property(b => b.Name);
            builder.Property(b => b.Surname);
            builder.Property(b => b.Company);
        }
    }
}
