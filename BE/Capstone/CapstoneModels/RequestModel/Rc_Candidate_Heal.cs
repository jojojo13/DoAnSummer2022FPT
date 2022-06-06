using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace CapstoneModels
{
    [Table("Rc_Candidate_Heal")]
    public class Rc_Candidate_Heal
    {
        [Key]
        public int Id { get; set; } 

        public int? Cadidate_ID { get; set; }
        [ForeignKey("Cadidate_ID")]
        [InverseProperty("Rc_Candidate_Heals")]
        public Rc_Candidate rc_Candidate { get; set; }
        [StringLength(100)]
        public string Chieu_Cao { get; set; }
        [StringLength(100)]
        public string Can_Nang { get; set; }
        [StringLength(100)]
        public string Nhom_mau { get; set; }
        [StringLength(100)]
        public string Huyet_Ap { get; set; }
        [StringLength(100)]
        public string Mat_Trai { get; set; }
        [StringLength(100)]
        public string Mat_Phai { get; set; }
        [StringLength(100)]
        public string Tai_Mui_Hong { get; set; }
        [StringLength(100)]
        public string Tim { get; set; }
        [StringLength(100)]
        public string Benh_Khac { get; set; }
        public string Note { get; set; }

        public int? LoaiSK { get;set; }
        [ForeignKey("LoaiSK")]
        [InverseProperty("Rc_Candidate_Heals")]
        public Other_List Other_List { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
