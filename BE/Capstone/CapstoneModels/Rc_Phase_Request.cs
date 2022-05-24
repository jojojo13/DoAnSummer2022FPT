﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Rc_Phase_Request")]
    public class Rc_Phase_Request
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        public int? RequestId { get; set; }
        [ForeignKey("RequestId")]
        [InverseProperty("Rc_Phase_Requests")]
        public Rc_Request rc_Request { get; set; }

        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        [InverseProperty("Rc_Phase_Requests")]
        public Position position { get; set; }

        public string note { get; set; }
        public int? NumberNeed { get; set; }
        public int? Cost { get; set; }
        public int? Status { get; set; }
    }
}
