using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class EmployeeContract
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string ContractNo { get; set; }
        public int? ContractType { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? SignId { get; set; }
        public DateTime SignDate { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public int? IsThue { get; set; }
        public int? IsCamKet { get; set; }
        public int? OrgId { get; set; }
        public int? PositionId { get; set; }
        public string Comment { get; set; }

        public virtual ContractType ContractTypeNavigation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Orgnization Org { get; set; }
        public virtual Position Position { get; set; }
        public virtual Employee Sign { get; set; }
    }
}
