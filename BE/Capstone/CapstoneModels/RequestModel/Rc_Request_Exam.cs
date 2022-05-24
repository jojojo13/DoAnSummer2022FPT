using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Rc_Request_Exam")]
    public class Rc_Request_Exam
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? HeDiem { get; set; }
        public int? DiemQua { get; set; }

        public int? Phase_ID { get; set; }
        [ForeignKey("Phase_ID")]
        [InverseProperty("Rc_Request_Exams")]
        public Rc_Phase_Request rc_Phase_Request { get; set; }
        public virtual ICollection<Rc_Request_Exam_Result> Rc_Request_Exam_Results { get; set; }
    }
}
