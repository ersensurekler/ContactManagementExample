using AutoMapper;
using Entities.Concrete.Contacts;
using Entities.Dtos.Contacts;

namespace Entities.Dtos._Profiles.Contacts
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
