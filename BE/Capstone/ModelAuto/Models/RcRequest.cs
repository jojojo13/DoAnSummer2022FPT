﻿using System;
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
        public int? RequestLevel { get; set; }
        public int? OrgnizationId { get; set; }
        public int? PositionId { get; set; }
        public int? Number { get; set; }
        public int? SignId { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? YearExperience { get; set; }
        public int? Level { get; set; }
        public int? Type { get; set; }
        public int? Project { get; set; }
        public int? Budget { get; set; }
        public string Note { get; set; }
        public string Comment { get; set; }
        public int? Status { get; set; }
        public int? ParentId { get; set; }
        public int? Rank { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual OtherList LevelNavigation { get; set; }
        public virtual Orgnization Orgnization { get; set; }
        public virtual Position Position { get; set; }
        public virtual OtherList ProjectNavigation { get; set; }
        public virtual OtherList RequestLevelNavigation { get; set; }
        public virtual Employee Sign { get; set; }
        public virtual OtherList TypeNavigation { get; set; }
        public virtual ICollection<RcPhaseRequest> RcPhaseRequests { get; set; }
    }
}