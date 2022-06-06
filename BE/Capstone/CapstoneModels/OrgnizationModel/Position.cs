using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Position")]
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? TitleID { get; set; }
        [ForeignKey("TitleID")]
        [InverseProperty("Position1")]
        public Title Title { get; set; }

        public int? BasicSalary { get; set; }
        public string OtherSkill { get; set; }
        public int? FormWorking { get; set; }
        [ForeignKey("FormWorking")]
        [InverseProperty("Positions")]
        public Other_List Other_List { get; set; }

        public int? Learning_level { get; set; }
        [ForeignKey("Learning_level")]
        [InverseProperty("Position1s")]
        public Other_List Other_List1 { get; set; }

        public string year_exp { get; set; }

        public int? majorGroup { get; set; }
        [ForeignKey("majorGroup")]
        [InverseProperty("Position2s")]
        public Other_List Other_List2 { get; set; }
        public string major { get; set; }

        public int? language { get; set; }
        [ForeignKey("language")]
        [InverseProperty("Position3s")]
        public Other_List Other_List3 { get; set; }

        public int? language_level { get; set; }
        [ForeignKey("language_level")]
        [InverseProperty("Position4s")]
        public Other_List Other_List4 { get; set; }

        public int? Information_level { get; set; }
        [ForeignKey("Information_level")]
        [InverseProperty("Position5s")]
        public Other_List Other_List5 { get; set; }

  
        [StringLength(100)]
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        [StringLength(100)]
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }
        public virtual ICollection<Rc_Phase_Request> Rc_Phase_Requests { get; set; }

        public virtual ICollection<PositionOrg> PositionOrgs { get; set; }

        public virtual ICollection<Rc_Request> Rc_Requests { get; set; }
    }
}
