using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Rc_Request_History")]
    public class Rc_Request_History
    {
        [Key]
        public int Id { get; set; }
       
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string User_log { get; set; }

        public int? Phase_Request_ID { get; set; }
        [ForeignKey("Phase_Request_ID")]
        [InverseProperty("Rc_Request_Histories")]
        public Rc_Phase_Request rc_Phase_Request { get; set; }
    }
}
