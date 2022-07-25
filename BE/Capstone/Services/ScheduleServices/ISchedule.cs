using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ScheduleServices
{
    public interface ISchedule
    {
        #region Lịch thi , lịch PV
        bool InsertSchedule(List<int> listCandidate, RcRequestSchedu T);
        bool ModifySchedule(RcRequestSchedu T);
        bool DeleteSchedule(List<int> listID);
        #endregion

        #region Thiết lập môn thi
        bool InsertExam(RcRequestExam T);
        bool ModifyExam(RcRequestExam T);
        bool DeleteExam(List<int>listID);
        bool ActiveExam(List<int> listID);
        bool DeactiveExam(List<int> listID);

        #endregion

    }
}
