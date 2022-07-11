using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ResponseModel.Request
{
    public class RequestResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? RequestLevel { get; set; }
        public int? OrgnizationId { get; set; }
        public int? PositionID { get; set; }
        public int? Number { get; set; }
        public int? SignId { get; set; }
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? YearExperience { get; set; }
        public int? Level { get; set; }
        public int? Type { get; set; }
        public int? Project { get; set; }
        public int? Budget { get; set; }
        public string Note { get; set; }
        public string Comment { get; set; }
        public int? Status { get; set; }
        public int? ParentID { get; set; }
        public int? Rank { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? HrInchange { get; set; }
        public int? OtherSkill { get; set; }
    }

    public class CommentResponse
    {
        public int Id { get; set; }
        public string comment { get; set; }
    }

    public class HrinchangeResponse
    {
        public int Id { get; set; }
        public int hrID { get; set; }
    }
}