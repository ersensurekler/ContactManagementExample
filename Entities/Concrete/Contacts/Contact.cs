using Core.Entities;
using Entities.Concrete.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Contacts
{
    public class Contact : IEntity
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public int InfoType { get; set; }
        public string Info { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
