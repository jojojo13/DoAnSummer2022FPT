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

        public int? StatusHr { get; set; }
        [ForeignKey("StatusHr")]
        [InverseProperty("Rc_Requests")]
        public Other_List Other_List { get; set; }

        public int? StatusMg { get; set; }
        [ForeignKey("StatusMg")]
        [InverseProperty("Rc_Request1s")]
        public Other_List Other_List1 { get; set; }

    }
}
