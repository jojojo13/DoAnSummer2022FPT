using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcRequest
    {
        public RcRequest()
        {
            RcPhaseRequests = new HashSet<RcPhaseRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? OrgId { get; set; }
        public int? SignId { get; set; }
        public DateTime? SignDate { get; set; }
        public string Note { get; set; }
        public string Comment { get; set; }
        public int? Status { get; set; }
        public int? StatusHr { get; set; }
        public int? StatusMg { get; set; }
        public int? Type { get; set; }
        public int? PositionId { get; set; }
        public int? Number { get; set; }
        public string Exp { get; set; }
        public int? Project { get; set; }

        public virtual Orgnization Org { get; set; }
        public virtual Position Position { get; set; }
        public virtual OtherList ProjectNavigation { get; set; }
        public virtual Employee Sign { get; set; }
        public virtual OtherList StatusHrNavigation { get; set; }
        public virtual OtherList StatusMgNavigation { get; set; }
        public virtual OtherList TypeNavigation { get; set; }
        public virtual ICollection<RcPhaseRequest> RcPhaseRequests { get; set; }
    }
}
