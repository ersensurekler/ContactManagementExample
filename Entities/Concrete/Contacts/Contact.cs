using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Contacts
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int InfoType { get; set; }
        public string Info { get; set; }
    }
}
