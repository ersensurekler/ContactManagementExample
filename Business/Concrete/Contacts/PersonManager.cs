using AutoMapper;
using Business.Constants;
using Business.Interfaces.Contacts;
using Core.Utilities.Results;
using DataAccess.Interfaces.Contacts;
using DataAccess.Interfaces.Persons;
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
    public class PersonManager : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;
        private readonly IPersonDal _personDal;
        public PersonManager(
            IMapper mapper,
            IPersonDal personDal,
            IContactService contactService)
        {
            _mapper = mapper;
            _personDal = personDal;
            _contactService = contactService;
        }

        public async Task<IResult> Delete(PersonDto person)
        {
            try
            {
                await _personDal.CurrentContext.Database.BeginTransactionAsync();

                var mappedPerson = _mapper.Map<Person>(person);
                await _personDal.Delete(mappedPerson);

                foreach (var contact in person.Contacts)
                {
                    var result = await _contactService.Delete(contact);

                    if (!result.Success)
                    {
                        throw new Exception(result.Message);
                    }
                }

                await _personDal.CurrentContext.Database.CommitTransactionAsync();

                return new SuccessResult(Messages.Success_Deleted);
            }
            catch (Exception ex)
            {
                await _personDal.CurrentContext.Database.RollbackTransactionAsync();
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<ICollection<PersonDto>>> Get()
        {
            var person = await _personDal.Queryable()
                .Include(t => t.Contacts.Where(h => h.PersonId == t.Id))
                .ToListAsync();

            return new SuccessDataResult<ICollection<PersonDto>>(_mapper.Map<ICollection<PersonDto>>(person));
        }

        public async Task<IDataResult<PersonDto>> GetById(Guid id)
        {
            var person = await _personDal.Queryable()
                .Include(t => t.Contacts.Where(h => h.PersonId == t.Id))
                .Where(d => d.Id == id)
                .ToListAsync();

            return new SuccessDataResult<PersonDto>(_mapper.Map<PersonDto>(person));
        }

        public async Task<IResult> Save(PersonDto person)
        {
            try
            {
                await _personDal.CurrentContext.Database.BeginTransactionAsync();

                var mappedPerson = _mapper.Map<Person>(person);
                await _personDal.Add(mappedPerson);

                foreach (var contact in person.Contacts)
                {
                    var result = await _contactService.Save(contact);

                    if (!result.Success)
                    {
                        throw new Exception(result.Message);
                    }
                }

                await _personDal.CurrentContext.Database.CommitTransactionAsync();

                return new SuccessResult(Messages.Success_Added);
            }
            catch (Exception ex)
            {
                await _personDal.CurrentContext.Database.RollbackTransactionAsync();
                return new ErrorResult(ex.Message);
            }
        }
    }
}
