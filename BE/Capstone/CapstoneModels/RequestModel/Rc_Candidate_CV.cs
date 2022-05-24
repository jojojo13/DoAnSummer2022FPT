﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace CapstoneModels.RequestModel
{
    [Table("Rc_Candidate_CV")]
    public class Rc_Candidate_CV
    {
        [Key]
        public int ID { get; set; }
        public int? CandidateID { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Employee Employee { get; set; }


        public int? Gender { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Other_List Other_List { get; set; }
        public byte? Image { get; set; }
        public DateTime? Dob { get; set; }
        // noi sinh
        public string NoiSinh { get; set; }
        public int? NationOB { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Nation Nation1 { get; set; }
        public int? PorvinceOB { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Province Province1 { get; set; }
        public int? DistrictOB { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public District District1 { get; set; }
        public int? WardOB { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Ward Ward1 { get; set; }

        public string CMND { get; set; }
        public string CMNDPlace { get; set; }

        public string VisaNumber { get; set; }
        public string VisaPlace { get; set; }

        public string Email { get; set; }

        public string EmailWork { get; set; }

        public string Mobile { get; set; }
        // noi o
        public string NoiO { get; set; }
        public int? NationLive { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Nation Nation2 { get; set; }


        public int? PorvinceLive { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Province Province2 { get; set; }


        public int? DistrictLive { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public District District2 { get; set; }
        public int? WardLive { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Ward Ward2 { get; set; }




        // Ho khau thuong chu
        public string HoKhau { get; set; }
        public int? NationHK { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Nation Nation3 { get; set; }
        public int? PorvinceHK { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Province Province3 { get; set; }
        public int? DistrictHK { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public District District3 { get; set; }
        public int? WardHK { get; set; }
        [ForeignKey("")]
        [InverseProperty("")]
        public Ward Ward3 { get; set; }
    }
}
