using System;
using System.Collections.Generic;

#nullable disable

namespace Win.Models
{
    public partial class Qlnguoio
    {
        public int Id { get; set; }
        public int? Idphong { get; set; }
        public int? Ten { get; set; }
        public int? Ngaysinh { get; set; }
        public int? Sdt { get; set; }
        public string QuanheCh { get; set; }
        public bool? Status { get; set; }

        public virtual ToaNha IdphongNavigation { get; set; }
    }
}
