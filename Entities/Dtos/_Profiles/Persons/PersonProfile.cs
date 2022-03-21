using AutoMapper;
using Entities.Concrete.Persons;
using Entities.Dtos.Contacts;

namespace Entities.Dtos._Profiles.Persons
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}
