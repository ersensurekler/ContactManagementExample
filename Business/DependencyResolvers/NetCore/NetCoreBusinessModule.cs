using Business.Concrete.ContactReports;
using Business.Constants;
using DataAccess.Concrete.Dal.Contacts;
using DataAccess.Interfaces.Contacts;
using MassTransit;
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

            services.AddMassTransit(x =>
            {
                x.AddConsumer<ContactReportConsumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    //cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri(QueueConstants.QueueHostName), h =>
                    {
                        h.Username(QueueConstants.QueueUserName);
                        h.Password(QueueConstants.QueuePassword);
                    });
                    cfg.ReceiveEndpoint(QueueConstants.ReportQueue, ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<ContactReportConsumer>(provider);
                    });
                }));
            });
        }
    }
}
