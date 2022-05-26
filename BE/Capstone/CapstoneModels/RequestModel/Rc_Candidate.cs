﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Rc_Candidate")]
    public class Rc_Candidate
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public int? PhaseID { get; set; }
        [ForeignKey("PhaseID")]
        [InverseProperty("Rc_Candidates")]
        public Rc_Phase_Request rc_Phase_Request { get; set; }


        public int? ResourceID { get; set; }
        [ForeignKey("ResourceID")]
        [InverseProperty("Rc_Candidates")]
        public Rc_Resource_Candidate rc_Resource_Candidate { get; set; }

        public int? Status { get; set; }

        public virtual ICollection<Rc_Candidate_Family> Rc_Candidate_Families { get; set; }

        public virtual ICollection<Rc_Candidate_Worrking_Before> Rc_Candidate_Worrking_Befores { get; set; }
        public virtual ICollection<Rc_Candidate_Heal> Rc_Candidate_Heals { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDUs { get; set; }
        public virtual ICollection<Rc_Request_Exam_Result> Rc_Request_Exam_Results { get; set; }
        public virtual ICollection<Rc_Request_InterView_Result> Rc_Request_InterView_Results { get; set; }
        public virtual ICollection<Rc_Request_Result> Rc_Request_Results { get; set; }
        public virtual ICollection<Rc_Request_Schedu> Rc_Request_Schedus { get; set; }
    }
}