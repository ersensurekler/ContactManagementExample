using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces.ContactReports
{
    public interface IContactReportQueueService
    {
        void Send<T>(string queue, T data);
        T Receive<T>(string queue);
    }
}
