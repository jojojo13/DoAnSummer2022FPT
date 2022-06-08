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
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<OtherList> OtherLists { get; set; }
    }
}
