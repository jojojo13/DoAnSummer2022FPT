using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Schedule
{
    public class ScheduleResponse
    {
        public int requestId { get; set; }
        public int candidateId { get; set; }
        public List<EventResponse>listEvent { get; set; }
    }
    public class EventResponse
    {
        public string Title { get; set; }
        public DateTime? StartHour { get; set; }
        public DateTime? EndHour { get; set; }
        public string Classname { get; set; }
    }
}
