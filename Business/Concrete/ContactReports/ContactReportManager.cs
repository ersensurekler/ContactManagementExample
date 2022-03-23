using Business.Constants;
using Business.Interfaces.ContactReports;
using Business.Interfaces.Contacts;
using Core.Utilities.Results;
using Entities.Dtos.ContactReports;
using MassTransit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete.ContactReports
{
    public class ContactReportManager : IContactReportService
    {
        private readonly IBus _bus;
        private readonly IContactReportQueueService _contactReportQueueService;
        private readonly IPersonService _personService;
        public ContactReportManager(
            IBus bus,
            IContactReportQueueService contactReportQueueService,
            IPersonService personService)
        {
            _contactReportQueueService = contactReportQueueService;
            _personService = personService;
            _bus = bus;
        }

        public async Task<IResult> GetAllReportSend()
        {
            ContactReportRequestDto contactReportRequestDto = new ContactReportRequestDto
            {
                ReportDate = DateTime.Now
            };

            //var persons = await _personService.Get();
            //_contactReportQueueService.Send(QueueConstants.ReportQueue, persons);

            Uri uri = new Uri(QueueConstants.QueueHostName);
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(contactReportRequestDto);

            return new SuccessDataResult<ContactReportRequestDto>(contactReportRequestDto);
        }

        public async Task<IDataResult<ContactReportResponseDto>> GetAllReportReceive(ContactReportRequestDto contactReportRequestDto)
        {
            var persons = await _personService.Get();
            var contactReportResponseDto = new ContactReportResponseDto
            {
                ReportDate = contactReportRequestDto.ReportDate,
                PersonCount = persons.Data.Count,
                ContactCount = persons.Data.Select(s => s.Contacts).Count(),
                ReportState = Messages.Report_State_Completed
            };
            return new SuccessDataResult<ContactReportResponseDto>(contactReportResponseDto);
        }
    }
}
