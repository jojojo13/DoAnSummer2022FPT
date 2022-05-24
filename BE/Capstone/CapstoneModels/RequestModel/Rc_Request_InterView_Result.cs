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
    [Table("Rc_Request_InterView_Result")]
   public class Rc_Request_InterView_Result
    {
        [Key]
        public int Id { get; set; }
        public int? CandidateID { get; set; }
        public int? InterviewID { get; set; }
     
        public int? Status { get; set; }
        public string Note { get; set; }
    }
}
