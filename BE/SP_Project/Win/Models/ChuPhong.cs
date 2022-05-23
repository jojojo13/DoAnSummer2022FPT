using System;
using System.Collections.Generic;

#nullable disable

namespace Win.Models
{
    public partial class ChuPhong
    {
        public int Id { get; set; }
        public int? Idchu { get; set; }
        public int? Idphong { get; set; }

        public virtual TtchuNha IdchuNavigation { get; set; }
        public virtual ToaNha IdphongNavigation { get; set; }
    }
}
