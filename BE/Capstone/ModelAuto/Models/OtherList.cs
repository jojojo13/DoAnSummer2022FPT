using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class OtherList
    {
        public OtherList()
        {
            EmployeeCvs = new HashSet<EmployeeCv>();
            Employees = new HashSet<Employee>();
            PositionFormWorkingNavigations = new HashSet<Position>();
            PositionInformationLevelNavigations = new HashSet<Position>();
            PositionLanguageLevelNavigations = new HashSet<Position>();
            PositionLanguageNavigations = new HashSet<Position>();
            PositionLearningLevelNavigations = new HashSet<Position>();
            PositionMajorGroupNavigations = new HashSet<Position>();
            RcCandidateCvs = new HashSet<RcCandidateCv>();
            RcCandidateEduDeeGree1Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduDeeGree2Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduDeeGree3Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduInforMaticsLevel1Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduInforMaticsLevel2Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduInforMaticsLevel3Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduLanguage1Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduLanguage2Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduLanguage3Navigations = new HashSet<RcCandidateEdu>();
            RcCandidateEduLearningLevelNavigations = new HashSet<RcCandidateEdu>();
            RcCandidateFamilies = new HashSet<RcCandidateFamily>();
            RcCandidateHeals = new HashSet<RcCandidateHeal>();
            RcRequestProjectNavigations = new HashSet<RcRequest>();
            RcRequestResultStatusContactNavigations = new HashSet<RcRequestResult>();
            RcRequestResultStatusRequestNavigations = new HashSet<RcRequestResult>();
            RcRequestScheduHinhThucNavigations = new HashSet<RcRequestSchedu>();
            RcRequestScheduStatusContactNavigations = new HashSet<RcRequestSchedu>();
            RcRequestStatusHrNavigations = new HashSet<RcRequest>();
            RcRequestStatusMgNavigations = new HashSet<RcRequest>();
            RcRequestTypeNavigations = new HashSet<RcRequest>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string Atribute1 { get; set; }
        public string Atribute2 { get; set; }
        public string Atribute3 { get; set; }
        public int? TypeId { get; set; }

        public virtual OtherListType Type { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvs { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Position> PositionFormWorkingNavigations { get; set; }
        public virtual ICollection<Position> PositionInformationLevelNavigations { get; set; }
        public virtual ICollection<Position> PositionLanguageLevelNavigations { get; set; }
        public virtual ICollection<Position> PositionLanguageNavigations { get; set; }
        public virtual ICollection<Position> PositionLearningLevelNavigations { get; set; }
        public virtual ICollection<Position> PositionMajorGroupNavigations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvs { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduDeeGree1Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduDeeGree2Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduDeeGree3Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduInforMaticsLevel1Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduInforMaticsLevel2Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduInforMaticsLevel3Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduLanguage1Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduLanguage2Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduLanguage3Navigations { get; set; }
        public virtual ICollection<RcCandidateEdu> RcCandidateEduLearningLevelNavigations { get; set; }
        public virtual ICollection<RcCandidateFamily> RcCandidateFamilies { get; set; }
        public virtual ICollection<RcCandidateHeal> RcCandidateHeals { get; set; }
        public virtual ICollection<RcRequest> RcRequestProjectNavigations { get; set; }
        public virtual ICollection<RcRequestResult> RcRequestResultStatusContactNavigations { get; set; }
        public virtual ICollection<RcRequestResult> RcRequestResultStatusRequestNavigations { get; set; }
        public virtual ICollection<RcRequestSchedu> RcRequestScheduHinhThucNavigations { get; set; }
        public virtual ICollection<RcRequestSchedu> RcRequestScheduStatusContactNavigations { get; set; }
        public virtual ICollection<RcRequest> RcRequestStatusHrNavigations { get; set; }
        public virtual ICollection<RcRequest> RcRequestStatusMgNavigations { get; set; }
        public virtual ICollection<RcRequest> RcRequestTypeNavigations { get; set; }
    }
}
