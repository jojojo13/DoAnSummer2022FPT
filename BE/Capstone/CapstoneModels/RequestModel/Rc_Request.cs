using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Rc_Request")]
    public class Rc_Request
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        public int? OrgId { get; set; }
        [ForeignKey("OrgId")]
        [InverseProperty("Rc_Requests")]
        public ORgnization oRgnization { get; set; }

        public int? SignId { get; set; }
        [ForeignKey("SignId")]
        [InverseProperty("Rc_Requests")]
        public Employee employee { get; set; }

        public DateTime? SignDate { get; set; }

        public string Note { get; set; }


        public string Comment { get; set; }

        public int? Status { get; set; }
        //ko dùng
        public int? StatusHr { get; set; }
        [ForeignKey("StatusHr")]
        [InverseProperty("Rc_Requests")]
        public Other_List Other_List { get; set; }

        public int? StatusMg { get; set; }
        [ForeignKey("StatusMg")]
        [InverseProperty("Rc_Request1s")]
        public Other_List Other_List1 { get; set; }
        //


        public int? Type { get; set; }
        [ForeignKey("Type")]
        [InverseProperty("Rc_Request2s")]
        public Other_List Other_List2 { get; set; }

        public int? PositionID { get; set; }
        [ForeignKey("PositionID")]
        [InverseProperty("Rc_Requests")]
        public Position position { get; set; }

        public int? Number { get; set; }

        public string Exp { get; set; }

        public int? Project { get; set; }
        [ForeignKey("Project")]
        [InverseProperty("Rc_Request3s")]
        public Other_List Other_List3 { get; set; }

        public virtual ICollection<Rc_Phase_Request> Rc_Phase_Requests  { get; set; }
    }
}
