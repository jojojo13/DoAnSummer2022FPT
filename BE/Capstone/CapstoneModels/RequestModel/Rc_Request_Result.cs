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
    [Table("Rc_Request_Result")]
 public   class Rc_Request_Result
    {
        [Key]
        public int Id { get; set; }
        public int? CandidateID { get; set; }
        public int? Request_Phase_ID { get; set; }  
        public int? Status_Request { get; set; }
        public int? Avg_Score { get; set; }
        public int? Result_Interview { get; set; }
        public string Note { get; set; }
        public int? StatusContact { get; set; }

        public int? Status { get; set; }
        public int? Is_Move_HSNV { get; set; }

    }
}
