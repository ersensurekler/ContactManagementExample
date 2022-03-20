using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DbContexts
{
    public interface IDbContext
    {
        DatabaseFacade Database { get; }
    }
}
