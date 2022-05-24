using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace CapstoneModels.ProfileModel
{
    [Table("Employee_Working_Before")]
    public class Employee_Working_Before
    {
        [Key]
        public int Id { get; set; }
        //


        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        [InverseProperty("")]
   // thieu

        //
        public string CompanyName { get; set; }

        public string Address { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string ReasonOut { get; set; }
        public string Note { get; set; }
    }
}
