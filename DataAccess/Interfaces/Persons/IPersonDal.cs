using Core.DataAccess;
using Entities.Concrete.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.Persons
{
    public interface IPersonDal: IEntityRepository<Person>
    {
    }
}
