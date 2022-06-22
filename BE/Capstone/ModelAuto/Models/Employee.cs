using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Accounts = new HashSet<Account>();
            EmployeeContractEmployees = new HashSet<EmployeeContract>();
            EmployeeContractSigns = new HashSet<EmployeeContract>();
            EmployeeCvs = new HashSet<EmployeeCv>();
            Orgnizations = new HashSet<Orgnization>();
            RcCandidateCvs = new HashSet<RcCandidateCv>();
            RcRequestSchedus = new HashSet<RcRequestSchedu>();
            RcRequests = new HashSet<RcRequest>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LastDate { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? IsTuyenDung { get; set; }
        public int? OrgId { get; set; }
        public int? PositionId { get; set; }

        public virtual Orgnization Org { get; set; }
        public virtual Position Position { get; set; }
        public virtual OtherList StatusNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<EmployeeContract> EmployeeContractEmployees { get; set; }
        public virtual ICollection<EmployeeContract> EmployeeContractSigns { get; set; }
        public virtual ICollection<EmployeeCv> EmployeeCvs { get; set; }
        public virtual ICollection<Orgnization> Orgnizations { get; set; }
        public virtual ICollection<RcCandidateCv> RcCandidateCvs { get; set; }
        public virtual ICollection<RcRequestSchedu> RcRequestSchedus { get; set; }
        public virtual ICollection<RcRequest> RcRequests { get; set; }
    }
}
