using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcRequestInterView
    {
        public RcRequestInterView()
        {
            RcRequestInterViewResults = new HashSet<RcRequestInterViewResult>();
            RcRequestSchedus = new HashSet<RcRequestSchedu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? PhaseId { get; set; }

        public virtual RcPhaseRequest Phase { get; set; }
        public virtual ICollection<RcRequestInterViewResult> RcRequestInterViewResults { get; set; }
        public virtual ICollection<RcRequestSchedu> RcRequestSchedus { get; set; }
    }
}
