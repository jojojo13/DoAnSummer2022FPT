﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace CapstoneModels.ProfileModel
{   
    [Table("Employee_Salary")]
    public class Employee_Salary
    {
        [Key]
        public int Id { get; set; }
        public int? EmployeeId { get; set; }


        public int? Org_ID { get; set; }


        public string Decisiong_NO { get; set; }
        public string Note { set; get; }
        public DateTime? Effect_Date { get; set; }
        public DateTime? Expire_Date { get; set; }
        public int? Sign_ID { get; set; }
        public DateTime? Sign_Date { get; set; }
        public int? Status { get; set; }
        public int? SAL_Rank { get; set; }
        public int? SAL_Basic { get; set; }
        public int? Is_Wage { get; set; }
        public int? SAL_Total { get; set; }
        public int? KPI { get; set; }
    }
}
