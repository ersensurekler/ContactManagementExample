using Core.Entities;
using Entities.Concrete.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Persons
{
    public class Person: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        //public virtual ICollection<Contact> Contacts { get; set; }

    }
}
