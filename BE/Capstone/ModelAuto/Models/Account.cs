using System;
using System.Collections.Generic;

#nullable disable

namespace ModelAuto.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? EmployeeId { get; set; }
        public int? Rule { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
