using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Other_List")]
    public class Other_List
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string Atribute1 { get; set; }
        public string Atribute2 { get; set; }
        public string Atribute3 { get; set; }

        public int? TypeID { get; set; }
        [ForeignKey("TypeID")]
        public Other_List_Type Other_List_Type { get; set; }

        public virtual ICollection<Position> Positions { get; set; }    

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<EmployeeCV> EmployeeCVs { get; set; }

        public virtual ICollection<Rc_Request> Rc_Requests { get; set; }
        public virtual ICollection<Rc_Request> Rc_Request1s { get; set; }

        public virtual ICollection<Rc_Candidate_Family> Rc_Candidate_Families { get; set; }
        public virtual ICollection<Rc_Candidate_Heal> Rc_Candidate_Heals { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDUs { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDU1s { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDU2s { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDU3s { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDU4s { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDU5s { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDU6s { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDU7s { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDU8s { get; set; }
        public virtual ICollection<Rc_Candidate_EDU> Rc_Candidate_EDU9s { get; set; }
        public virtual ICollection<Rc_Request_Result> Rc_Request_Results { get; set; }
        public virtual ICollection<Rc_Request_Result> Rc_Request_Result1s { get; set; }

        public virtual ICollection<Rc_Candidate_CV> Rc_Candidate_CVs { get; set; }

        public virtual ICollection<Rc_Request_Schedu> Rc_Request_Schedus { get; set; }
        public virtual ICollection<Rc_Request_Schedu> Rc_Request_Schedu2s { get; set; }
    }
}
