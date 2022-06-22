using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcRequestInterViewResult
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? InterviewId { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }

        public virtual RcCandidate Candidate { get; set; }
        public virtual RcRequestInterView Interview { get; set; }
    }
}
