using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class OtherListType
    {
        public OtherListType()
        {
            OtherLists = new HashSet<OtherList>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int PhanHe { get; set; }
        public int IsSystem { get; set; }

        public virtual ICollection<OtherList> OtherLists { get; set; }
    }
}
