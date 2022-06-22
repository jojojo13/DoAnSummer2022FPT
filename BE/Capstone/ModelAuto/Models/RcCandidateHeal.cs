using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class RcCandidateHeal
    {
        public int Id { get; set; }
        public int? CadidateId { get; set; }
        public string ChieuCao { get; set; }
        public string CanNang { get; set; }
        public string NhomMau { get; set; }
        public string HuyetAp { get; set; }
        public string MatTrai { get; set; }
        public string MatPhai { get; set; }
        public string TaiMuiHong { get; set; }
        public string Tim { get; set; }
        public string BenhKhac { get; set; }
        public string Note { get; set; }
        public int? LoaiSk { get; set; }

        public virtual RcCandidate Cadidate { get; set; }
        public virtual OtherList LoaiSkNavigation { get; set; }
    }
}
