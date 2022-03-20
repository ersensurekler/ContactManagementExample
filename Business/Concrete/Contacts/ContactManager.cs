using AutoMapper;
using Business.Interface.Contacts;
using Core.Utilities.Results;
using DataAccess.Interface.Contacts;
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

        public ContactManager(
            IMapper mapper,
            IContactDal contactDal)
        {
            _mapper = mapper;
            _contactDal = contactDal;
        }

        public async Task<IDataResult<ContactDto>> GetById(int id)
        {
            var contact = await _contactDal.GetByIdAsync(id);

            return new SuccessDataResult<ContactDto>(_mapper.Map<ContactDto>(contact));
        }
    }
}
