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
    [Table("Employee_Heal")]
    public class Employee_Heal
    {
        [Key]
        public int Id { get; set; }
        public int? Employee_ID { get; set; }



        public string Chieu_Cao { get; set; }
        public string Can_Nang { get; set; }
        public string Nhom_mau { get; set; }
        public string Huyet_Ap { get; set; }

        public string Mat_Trai { get; set; }
        public string Mat_Phai { get; set; }
        public string Tai_Mui_Hong { get; set; }
        public string Tim { get; set; }
        public string Benh_Khac { get; set; }
        public string Note { get; set; }
        public int? LoaiSK { get; set; }
    }
}