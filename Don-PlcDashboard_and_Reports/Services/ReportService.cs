using Don_PlcDashboard_and_Reports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Don_PlcDashboard_and_Reports.Services
{
    public class ReportService
    {
        public bool IsReportSent { get; set; }
        public DateTime TimeOfReport { get; set;}
        public String MailList { get; set; }
        public string MailSubject { get; set; }
        public string MailBodyText { get; set; }
        public void SendDaillyReport(DateTime time)
        {
        }

        // Function Check if TimeNow is biggger than the report set time
        public bool IsReportTime(DateTime time)
        {
            // IF report set time is < than current time make report and report set time plus 3 seconds is >= curent time stop make report (this way I make a window of 3 seconds to mke reports)
            if (TimeSpan.Compare(time.TimeOfDay, DateTime.Now.TimeOfDay) <= 0 && TimeSpan.Compare(time.AddSeconds(3).TimeOfDay, DateTime.Now.TimeOfDay) >= 0)
                return true;

            return false;
        }
        public void SendMail()
        {

        }

        public Defect FinishNotFinishedDefect(Defect defect)
        {
            defect.DefectFinalizat = true;
            defect.TimpStopDefect = DateTime.Now;
            defect.IntervalStationare = defect.TimpStopDefect - defect.TimpStartDefect;
            return defect;
        }
    }
}
