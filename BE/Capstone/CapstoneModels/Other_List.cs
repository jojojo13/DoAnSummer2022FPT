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
        public int Status { get; set; }
        public string Note { get; set; }
        public string Atribute1 { get; set; }
        public string Atribute2 { get; set; }
        public string Atribute3 { get; set; }

        public int TypeID { get; set; }
        [ForeignKey("TypeID")]
        public Other_List_Type Other_List_Type { get; set; }
        public virtual ICollection<ORgnization > ORgnizations { get; set; }

        public virtual ICollection<Position> Positions { get; set; }    

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<EmployeeCV> EmployeeCVs { get; set; }
    }
}
