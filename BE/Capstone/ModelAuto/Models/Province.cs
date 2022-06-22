using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class Province
    {
        public Province()
        {
            Districts = new HashSet<District>();
            EmployeeCvProvinceHkNavigations = new HashSet<EmployeeCv>();
            EmployeeCvProvinceLiveNavigations = new HashSet<EmployeeCv>();
            EmployeeCvProvinceObNavigations = new HashSet<EmployeeCv>();
            Orgnizations = new HashSet<Orgnization>();
            RcCandidateCvPorvinceHkNavigations = new HashSet<RcCandidateCv>();
            RcCandidateCvPorvinceLiveNavigations = new HashSet<RcCandidateCv>();
            RcCandidateCvPorvinceObNavigations = new HashSet<RcCandidateCv>();
            RcCandidateFamilies = new HashSet<RcCandidateFamily>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? NationId { get; set; }

        public virtual Nation Nation { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvProvinceHkNavigations { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvProvinceLiveNavigations { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvProvinceObNavigations { get; set; }
        public virtual ICollection<Orgnization> Orgnizations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvPorvinceHkNavigations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvPorvinceLiveNavigations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvPorvinceObNavigations { get; set; }
        public virtual ICollection<RcCandidateFamily> RcCandidateFamilies { get; set; }
    }
}
