using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcResourceCandidate
    {
        public RcResourceCandidate()
        {
            RcCandidates = new HashSet<RcCandidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public int? NumberCandidate { get; set; }

        public virtual ICollection<RcCandidate> RcCandidates { get; set; }
    }
}
