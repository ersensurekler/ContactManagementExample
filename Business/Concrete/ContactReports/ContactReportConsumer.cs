using AutoMapper;
using Business.Constants;
using Business.Interfaces.Contacts;
using Core.Utilities.Results;
using Entities.Concrete.Persons;
using Entities.Dtos.ContactReports;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.ContactReports
{
    public class ContactReportConsumer: IConsumer<ContactReportRequestDto>
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;
        public ContactReportConsumer(
            IMapper mapper,
            IPersonService personService)
        {
            _mapper = mapper;
            _personService = personService;
        }

        public async Task Consume(ConsumeContext<ContactReportRequestDto> context)
        {
            var contactReportRequestDto = context.Message;

            var persons = await _personService.Get();
            var contactReportResponseDto = new ContactReportResponseDto
            {
                ReportDate = contactReportRequestDto.ReportDate,
                PersonCount = persons.Data.Count,
                ContactCount = persons.Data.Select(s => s.Contacts).Count(),
                ReportState = Messages.Report_State_Completed
            };

            await context.Publish(contactReportResponseDto);
        }
    }
}
