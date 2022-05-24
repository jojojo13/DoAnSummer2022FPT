using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace CapstoneModels.RequestModel
{
    [Table("Rc_Request_Schedu")]
    public class Rc_Request_Schedu
    {
        [Key]
        public int ID { get; set; }

        public int? Is_Inteview { get; set; }
        public int? Is_Exam { get; set; }
        public int? ExamID { get; set; }
        public int? InterView_ID { get; set; }
        public DateTime? Date { get; set; }
        public string DiaDiem { get; set; }
        public int? HinhThuc { get; set; }
        public int? Candidate_ID { get; set; }

        public string Note { get; set; }
        public int? Expected_Cost { get; set; }

        public int? Phase_RequestID { get; set; }
        public DateTime? StartHourExam { get; set; }
        public DateTime? EndHourExam { get;set; }
        public DateTime? Date_Notify { get; set; }
        public int? Status_Contact { get; set; }
        public DateTime? Gio_PV { get; set; }
        public int? ID_NguoiPV { get; set; }

    }
}
