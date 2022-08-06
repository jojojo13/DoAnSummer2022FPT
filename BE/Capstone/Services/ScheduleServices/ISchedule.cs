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
        bool InsertSchedule(List<RcEvent>list);
        bool ModifySchedule(RcEvent T);
        bool DeleteSchedule(List<int> listID);
        #endregion
    }
}
