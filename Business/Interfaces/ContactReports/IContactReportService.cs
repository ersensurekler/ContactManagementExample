using Core.Utilities.Results;
using Entities.Dtos.ContactReports;
using Entities.Dtos.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.ContactReports
{
    public interface IContactReportService
    {
        Task<IResult> GetAllReportSend();
        Task<IDataResult<ContactReportResponseDto>> GetAllReportReceive(ContactReportRequestDto contactReportRequestDto);
    }
}
