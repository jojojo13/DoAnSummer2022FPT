using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("Contract_Type")]
    public class Contract_Type
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public string BHXH { get; set; }
        public string BHYT { get; set; }
        public string BHTN { get; set; }

        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }
    }
}
