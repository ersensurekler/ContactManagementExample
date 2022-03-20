using AutoMapper;
using Business.Constants;
using Business.Interfaces.Contacts;
using Core.Utilities.Results;
using DataAccess.Interfaces.Contacts;
using DataAccess.Interfaces.Persons;
using Entities.Concrete.Persons;
using Entities.Dtos.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Contacts
{
    public class ContactManager : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IContactDal _contactDal;
        private readonly IPersonDal _personDal;

        public ContactManager(
            IMapper mapper,
            IPersonDal personDal,
            IContactDal contactDal)
        {
            _mapper = mapper;
            _personDal = personDal;
            _contactDal = contactDal;
        }

        public async Task<IDataResult<PersonDto>> GetById(int id)
        {
            var contact = await _personDal.GetByIdAsync(id);

            return new SuccessDataResult<PersonDto>(_mapper.Map<PersonDto>(contact));
        }

        public async Task<IResult> Save(Person person)
        {
            try
            {
                await _personDal.Add(person);

                return new SuccessResult(Messages.Success_Added);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }
    }
}
