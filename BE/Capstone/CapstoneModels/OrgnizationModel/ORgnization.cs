﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneModels
{
    [Table("ORgnization")]
    public class ORgnization
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentID { get; set; }   
        public int? Level { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime DissolutionDate { get; set; }
        //
        public int? Status { get; set; }
        //
        public string Note { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string NumberBussines { get; set; }
        public string Address { get; set; }
        //
        public int? NationID { get; set; }
        [ForeignKey("NationID")]
        [InverseProperty("ORgnizations")]
        public Nation Nation { get; set; }
        //
        public int? ProvinceID { get; set; }
        [ForeignKey("ProvinceID")]
        [InverseProperty("ORgnizations")]
        public Province Province { get; set; }
        //
        public int? DistrictID { get; set; }
        [ForeignKey("DistrictID")]
        [InverseProperty("ORgnizations")]
        public District District { get; set; }

        //
        public int? WardID { get; set; }
        [ForeignKey("WardID")]
        [InverseProperty("ORgnizations")]
        public Ward Ward { get; set; }  
        //
        public int? ManagerID { get; set; }
        [ForeignKey("ManagerID")]
        [InverseProperty("ORgnizations")]
        public Employee Employee { get; set; }

        public virtual ICollection<Position> Positions { get; set; }    

        public virtual ICollection<Employee> Employees1 { get; set; }

        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }

        public virtual ICollection<Rc_Request> Rc_Requests { get; set; }
    }
}
