using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{   
    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }

        public int? ProvinceID { get; set; }
        [ForeignKey("ProvinceID")]
        public Province Province { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }  
        public virtual ICollection<ORgnization> ORgnizations { get; set; }

        public virtual ICollection<EmployeeCV> EmployeeCV1s { get; set; }
        public virtual ICollection<EmployeeCV> EmployeeCV2s { get; set; }
        public virtual ICollection<EmployeeCV> EmployeeCV3s { get; set; }
        public virtual ICollection<Rc_Candidate_Family> Rc_Candidate_Families { get; set; }
        public virtual ICollection<Rc_Candidate_CV> Rc_Candidate_CVs { get; set; }
        public virtual ICollection<Rc_Candidate_CV> Rc_Candidate_CV1s { get; set; }
        public virtual ICollection<Rc_Candidate_CV> Rc_Candidate_CV2s { get; set; }
    }
}
