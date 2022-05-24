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
    [Table("Employee_Family")]
    public class Employee_Family
    {
        [Key]
        public int Id { get; set; }

        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        [InverseProperty("")]
      

        public string Fullname { get; set; }


        public int? RelationId { get; set; }
        [ForeignKey("RelationId")]
        [InverseProperty("")]


        public int? Is_Deduct { get; set; }
        public DateTime? Deduct_From { get; set; }
        public DateTime? Deduct_To { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int? NationID { get; set; }
        [ForeignKey("NationID")]
        [InverseProperty("")]
        public Nation Nation { get; set; }


        public int? Porvince { get; set; }
        [ForeignKey("Porvince")]
        [InverseProperty("Rc_Candidate_Families")]
        public Province province { get; set; }


        public int? DistrictID { get; set; }
        [ForeignKey("DistrictID")]
        [InverseProperty("")]
        public District District { get; set; }
        public int? WardID { get; set; }
        [ForeignKey("WardID")]
        [InverseProperty("")]
        public Ward Ward { get; set; }
    }
}
