using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.Contacts
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public virtual ICollection<ContactDto> Contacts { get; set; }
    }
}
