using Core.DataAccess.EF;
using DataAccess.Concrete.EntityFramework.Context;
using DataAccess.Interfaces.Contacts;
using Entities.Concrete.Contacts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Dal.Contacts
{
    public class EFContactDal : EFEntityRepositoryBase<Contact>, IContactDal
    {
        public EFContactDal(ContactManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
