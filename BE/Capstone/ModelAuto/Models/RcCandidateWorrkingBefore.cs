using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcCandidateWorrkingBefore
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string ReasonOut { get; set; }
        public string Note { get; set; }

        public virtual RcCandidate Candidate { get; set; }
    }
}
