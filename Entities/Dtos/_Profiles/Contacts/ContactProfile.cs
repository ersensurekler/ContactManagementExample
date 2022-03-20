using AutoMapper;
using Entities.Concrete.Contacts;
using Entities.Dtos.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos._Profiles.Contacts
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>();
        }
    }
}
