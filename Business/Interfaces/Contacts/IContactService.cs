using Core.Utilities.Results;
using Entities.Concrete.Contacts;
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
        Task<IDataResult<ContactDto>> GetById(Guid id);
        Task<IResult> Save(ContactDto contact);
        Task<IDataResult<ICollection<ContactDto>>> GetByPersonId(Guid personId);
    }
}
