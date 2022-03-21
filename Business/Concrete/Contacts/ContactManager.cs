using AutoMapper;
using Business.Constants;
using Business.Interfaces.Contacts;
using Core.Utilities.Results;
using DataAccess.Interfaces.Contacts;
using DataAccess.Interfaces.Persons;
using Entities.Concrete.Contacts;
using Entities.Concrete.Persons;
using Entities.Dtos.Contacts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IDataResult<ContactDto>> GetById(Guid id)
        {
            var contact = await _contactDal.Queryable()
                .Where(t => t.Id == id)
                .ToListAsync();

            return new SuccessDataResult<ContactDto>(_mapper.Map<ContactDto>(contact));
        }

        public async  Task<IDataResult<ICollection<ContactDto>>> GetByPersonId(Guid personId)
        {
            var contacts = await _contactDal.Queryable()
                .Where(t => t.PersonId == personId)
                .ToListAsync();

            return new SuccessDataResult<ICollection<ContactDto>>(_mapper.Map<ICollection<ContactDto>>(contacts));
        }

        public async Task<IResult> Save(ContactDto contact)
        {
            try
            {
                var mappedContact = _mapper.Map<Contact>(contact);
                await _contactDal.Add(mappedContact);

                return new SuccessResult(Messages.Success_Added);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
