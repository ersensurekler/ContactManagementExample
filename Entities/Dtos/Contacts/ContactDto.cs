using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.Contacts
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public int InfoType { get; set; }
        public string Info { get; set; }
    }
}
