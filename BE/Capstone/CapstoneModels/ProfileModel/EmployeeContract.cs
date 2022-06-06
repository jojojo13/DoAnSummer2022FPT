using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("EmployeeContract")]
    public class EmployeeContract
    {
        [Key]
        public int Id { get; set; }

        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        [InverseProperty("EmployeeContracts")]
        public Employee Employee { get; set; }

        public string Contract_NO { get; set; }

        public int? Contract_type { get; set; }
        [ForeignKey("Contract_type")]
        [InverseProperty("EmployeeContracts")]
        public Contract_Type contract_Type { get; set; }

        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        public int? SignId { get; set; }
        [ForeignKey("SignId")]
        [InverseProperty("EmployeeContract1s")]
        public Employee Employee1 { get; set; }

        public DateTime SignDate { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public int? Is_thue { get; set; }
        public int? Is_CamKet { get; set; }

        public int? OrgId { get; set; }
        [ForeignKey("OrgId")]
        [InverseProperty("EmployeeContracts")]
        public ORgnization oRgnization { get; set; }

        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        [InverseProperty("EmployeeContracts")]
        public Position position { get; set; }

        public string Comment { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
