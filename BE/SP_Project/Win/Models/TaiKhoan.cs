using System;
using System.Collections.Generic;

#nullable disable

namespace Win.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            TtchuNhas = new HashSet<TtchuNha>();
        }

        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public int? Role { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<TtchuNha> TtchuNhas { get; set; }
    }
}
