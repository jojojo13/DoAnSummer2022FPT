using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Schedule
{
    public class ScheduleResponse
    {
        public int Id { get; set; }
        public int? IsInteview { get; set; }
        public int? IsExam { get; set; }
        public int? ExamId { get; set; }
        public int? InterViewId { get; set; }
        public DateTime? Date { get; set; }
        public string DiaDiem { get; set; }
        public int? HinhThuc { get; set; }
        public int? CandidateId { get; set; }
        public string Note { get; set; }
        public int? ExpectedCost { get; set; }
        public DateTime? StartHourExam { get; set; }
        public DateTime? EndHourExam { get; set; }
        public DateTime? DateNotify { get; set; }
        public int? StatusContact { get; set; }
        public DateTime? GioPv { get; set; }
        public int? IdNguoiPv { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<int>listID { get; set; }
    }
    public class ExamResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? HeDiem { get; set; }
        public int? DiemQua { get; set; }
        public int? RequestId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
