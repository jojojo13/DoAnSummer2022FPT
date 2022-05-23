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
        public int Status { get; set; }
        public string Note { get; set; }
        public int? TitleID { get; set; }
        [ForeignKey("TitleID")]
        [InverseProperty("Position1")]
        public Title Title { get; set; }


        public int? OrgID { get; set; }
        [ForeignKey("OrgID")]
        [InverseProperty("Positions")]
        public ORgnization Organization { get; set; }


        public int BasicSalary { get; set; }
        public string OtherSkill { get; set; }
        public int? FormWorking { get; set; }
        [ForeignKey("FormWorking")]
        [InverseProperty("Positions")]
        public Other_List Other_List { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }


    }
}
