using System;
using System.Collections.Generic;

#nullable disable

namespace Win.Models
{
    public partial class TtchuNha
    {
        public TtchuNha()
        {
            ChuPhongs = new HashSet<ChuPhong>();
        }

        public int Idcn { get; set; }
        public int? Idtk { get; set; }
        public string Ten { get; set; }
        public DateTime? Dob { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }

        public virtual TaiKhoan IdtkNavigation { get; set; }
        public virtual ICollection<ChuPhong> ChuPhongs { get; set; }
    }
}
