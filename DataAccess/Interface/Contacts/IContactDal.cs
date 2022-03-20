using Core.DataAccess;
using Entities.Concrete.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface.Contacts
{
    public interface IContactDal: IEntityRepository<Contact>
    {
    }
}
