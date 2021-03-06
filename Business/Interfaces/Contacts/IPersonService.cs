using Core.Utilities.Results;
using Entities.Dtos.Contacts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Contacts
{
    public interface IPersonService
    {
        Task<IDataResult<ICollection<PersonDto>>> Get();
        Task<IDataResult<PersonDto>> GetById(Guid id);
        Task<IResult> Delete(PersonDto person);
        Task<IResult> Save(PersonDto person);
    }
}
