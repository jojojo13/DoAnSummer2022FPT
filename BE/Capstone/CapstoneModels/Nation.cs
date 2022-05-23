using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Nation")]
    public class Nation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }    

        public virtual ICollection<Province> Provinces { get; set; }

        public virtual ICollection<ORgnization> ORgnizations { get; set; }
        public virtual ICollection<EmployeeCV> EmployeeCV1s { get; set; }
        public virtual ICollection<EmployeeCV> EmployeeCV2s { get; set; }
        public virtual ICollection<EmployeeCV> EmployeeCV3s { get; set; }
    }
}
