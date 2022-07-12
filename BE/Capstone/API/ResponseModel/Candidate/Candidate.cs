﻿using System;
using System.Collections.Generic;

namespace API.ResponseModel.Candidate
{
    public class Candidate
    {
        // trong ban rccandidate
        public string FullName { get; set; }
        // trong bang rccandidatecv
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
        public string Phone { get; set; }
        public string Zalo { get; set; }
        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Twiter { get; set; }
        public string NoiO { get; set; }
        public int? NationLive { get; set; }
        public int? PorvinceLive { get; set; }
        public int? DistrictLive { get; set; }
        public int? WardLive { get; set; }

        // trong bang rccandidate Edu
        public string Major { get; set; }
        public DateTime? Graduate { get; set; }
        public string School { get; set; }
        public Decimal? Gpa { get; set; }
        public string Awards { get; set; }

        // trong ban rccandidate Skill
        public List<Skill> listSkill { get; set; }
        public List<Exp> listExp { get; set; }


        public int RecordStatus { get; set; }
    }
    public class Skill
    {
        public int? TypeSkill { get; set; }
        public int? Type { get; set; }
        public int? Level { get; set; }
        public string Goal { get; set; }
    }

    public class Exp
    {
        public int? TypeID { get; set; }
        public string Firm { get; set; }
        public string Positiob { get; set; }
        public string Time { get; set; }

    }

    public class MatchingResponse
    {
        public int RequestID { get; set; }
        public List<int> lstCandidateID { get; set; }
    }

    


}
