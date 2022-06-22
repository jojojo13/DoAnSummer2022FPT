using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class ContractType
    {
        public ContractType()
        {
            EmployeeContracts = new HashSet<EmployeeContract>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string Bhxh { get; set; }
        public string Bhyt { get; set; }
        public string Bhtn { get; set; }

        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }
    }
}
