using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.ContactReports
{
    public class ContactReportResponseDto
    {
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int ContactCount { get; set; }

        public DateTime ReportDate { get; set; }
        public string ReportState { get; set; }
    }
}
