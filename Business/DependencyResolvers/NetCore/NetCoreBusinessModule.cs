using DataAccess.Concrete.Dal.Contacts;
using DataAccess.Interface.Contacts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.NetCore
{
    public class NetCoreBusinessModule
    {
        public static void Common(IServiceCollection services)
        {
            services.AddScoped<IContactDal, EFContactDal>();
        }
    }
}
