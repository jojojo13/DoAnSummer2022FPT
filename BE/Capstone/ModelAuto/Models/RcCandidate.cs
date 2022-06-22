using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcCandidate
    {
        public RcCandidate()
        {
            RcCandidateEdus = new HashSet<RcCandidateEdu>();
            RcCandidateFamilies = new HashSet<RcCandidateFamily>();
            RcRequestExamResults = new HashSet<RcRequestExamResult>();
            RcRequestInterViewResults = new HashSet<RcRequestInterViewResult>();
            RcRequestResults = new HashSet<RcRequestResult>();
            RcRequestSchedus = new HashSet<RcRequestSchedu>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int? PhaseId { get; set; }
        public int? ResourceId { get; set; }
        public int? Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? StepCv { get; set; }

        public virtual RcPhaseRequest Phase { get; set; }
        public virtual RcResourceCandidate Resource { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEdus { get; set; }
        public virtual ICollection<RcCandidateFamily> RcCandidateFamilies { get; set; }
        public virtual ICollection<RcRequestExamResult> RcRequestExamResults { get; set; }
        public virtual ICollection<RcRequestInterViewResult> RcRequestInterViewResults { get; set; }
        public virtual ICollection<RcRequestResult> RcRequestResults { get; set; }
        public virtual ICollection<RcRequestSchedu> RcRequestSchedus { get; set; }
    }
}
