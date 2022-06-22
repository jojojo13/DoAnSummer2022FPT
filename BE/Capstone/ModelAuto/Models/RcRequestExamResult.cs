using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcRequestExamResult
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? ExamId { get; set; }
        public int? Scoure { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }

        public virtual RcCandidate Candidate { get; set; }
        public virtual RcRequestExam Exam { get; set; }
    }
}
