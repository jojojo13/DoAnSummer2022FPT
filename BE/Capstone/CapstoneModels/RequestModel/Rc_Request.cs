﻿using System;
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
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        public int? OrgnizationId { get; set; }
        [ForeignKey("OrgnizationId")]
        [InverseProperty("Rc_Requests")]
        public ORgnization oRgnization { get; set; }

        public int? SignId { get; set; }
        [ForeignKey("SignId")]
        [InverseProperty("Rc_Requests")]
        public Employee Signer { get; set; }

        public DateTime? SignDate { get; set; }

        public string Note { get; set; }

        [StringLength(100)]
        public string Comment { get; set; }

        public int? Status { get; set; }
        //ko dùng
        public int? StatusHr { get; set; }
        [ForeignKey("StatusHr")]
        [InverseProperty("Rc_Requests")]
        public Other_List StatusHrObj { get; set; }

        public int? StatusMg { get; set; }
        [ForeignKey("StatusMg")]
        [InverseProperty("Rc_Request1s")]
        public Other_List StatusMgObj { get; set; }
        //


        public int? Type { get; set; }
        [ForeignKey("Type")]
        [InverseProperty("Rc_Request2s")]
        public Other_List TypeObj { get; set; }

        public int? PositionID { get; set; }
        [ForeignKey("PositionID")]
        [InverseProperty("Rc_Requests")]
        public Position position { get; set; }

        public int? Number { get; set; }
        [StringLength(100)]
        public string Exp { get; set; }

        public int? Project { get; set; }
        [ForeignKey("Project")]
        [InverseProperty("Rc_Request3s")]
        public Other_List ProjectObj { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<Rc_Phase_Request> Rc_Phase_Requests  { get; set; }
    }
}
