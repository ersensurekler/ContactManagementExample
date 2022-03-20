using Core.DataAccess.EF;
using DataAccess.Concrete.EntityFramework.Context;
using DataAccess.Interfaces.Persons;
using Entities.Concrete.Persons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Dal.Persons
{
    public class EFPersonDal : EFEntityRepositoryBase<Person>, IPersonDal
    {
        public EFPersonDal(ContactManagementContext dbContext) : base(dbContext)
        {
        }
    }
}
