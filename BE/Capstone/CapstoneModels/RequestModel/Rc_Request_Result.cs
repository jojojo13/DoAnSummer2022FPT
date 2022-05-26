﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace CapstoneModels
{
    [Table("Rc_Request_Result")]
    public class Rc_Request_Result
    {
        [Key]
        public int Id { get; set; }
        public int? CandidateID { get; set; }
        [ForeignKey("CandidateID")]
        [InverseProperty("Rc_Request_Results")]
        public Rc_Candidate rc_Candidate { get; set; }

        public int? Status_Request { get; set; }
        [ForeignKey("Status_Request")]
        [InverseProperty("Rc_Request_Results")]
        public Other_List other_List { get; set; }

        public int? Avg_Score { get; set; }
        public int? Result_Interview { get; set; }

        public string Note { get; set; }

        public int? StatusContact { get; set; }
        [ForeignKey("StatusContact")]
        [InverseProperty("Rc_Request_Result1s")]
        public Other_List other_List1 { get; set; }

        public int? Is_Move_HSNV { get; set; }

    }
}