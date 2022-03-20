using Core.Utilities.Results;
using Entities.Concrete.Persons;
using Entities.Dtos.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Contacts
{
    public interface IContactService
    {
        Task<IDataResult<PersonDto>> GetById(int id);
        Task<IResult> Save(Person person);
    }
}
