using System;
using System.Collections.Generic;

#nullable disable

namespace Win.Models
{
    public partial class ToaNha
    {
        public ToaNha()
        {
            ChuPhongs = new HashSet<ChuPhong>();
            Qlnguoios = new HashSet<Qlnguoio>();
        }

        public int Id { get; set; }
        public string TenPhong { get; set; }
        public int? Tang { get; set; }

        public virtual ICollection<ChuPhong> ChuPhongs { get; set; }
        public virtual ICollection<Qlnguoio> Qlnguoios { get; set; }
    }
}
