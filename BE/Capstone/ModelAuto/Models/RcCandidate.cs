﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcCandidate
    {
        public RcCandidate()
        {
            RcCandidateCvs = new HashSet<RcCandidateCv>();
            RcCandidateEdus = new HashSet<RcCandidateEdu>();
            RcCandidateExps = new HashSet<RcCandidateExp>();
            RcCandidateFamilies = new HashSet<RcCandidateFamily>();
            RcCandidateSkills = new HashSet<RcCandidateSkill>();
            RcRequestExamResults = new HashSet<RcRequestExamResult>();
            RcRequestInterViewResults = new HashSet<RcRequestInterViewResult>();
            RcRequestResults = new HashSet<RcRequestResult>();
            RcRequestSchedus = new HashSet<RcRequestSchedu>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public int? PhaseId { get; set; }
        public int? ResourceId { get; set; }
        public int? Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? StepCv { get; set; }
        public int? InterViewId { get; set; }

        public virtual Employee InterView { get; set; }
        public virtual RcPhaseRequest Phase { get; set; }
        public virtual RcResourceCandidate Resource { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvs { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEdus { get; set; }
        public virtual ICollection<RcCandidateExp> RcCandidateExps { get; set; }
        public virtual ICollection<RcCandidateFamily> RcCandidateFamilies { get; set; }
        public virtual ICollection<RcCandidateSkill> RcCandidateSkills { get; set; }
        public virtual ICollection<RcRequestExamResult> RcRequestExamResults { get; set; }
        public virtual ICollection<RcRequestInterViewResult> RcRequestInterViewResults { get; set; }
        public virtual ICollection<RcRequestResult> RcRequestResults { get; set; }
        public virtual ICollection<RcRequestSchedu> RcRequestSchedus { get; set; }
    }
}
