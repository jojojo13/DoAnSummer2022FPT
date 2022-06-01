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
        public DateTime? EffectDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        public int? OrgId { get; set; }
        public string OrgName { get; set; }

        public int? SignId { get; set; }
        public string SignName { get; set; }

        public DateTime? SignDate { get; set; }

        public string Note { get; set; }


        public string Comment { get; set; }

        public int? Status { get; set; }
        public string StatusName { get; set; }

        public int? StatusHr { get; set; }

        public int? StatusMg { get; set; }

        public int? Type { get; set; }
        public string TypeName { get; set; }
        public int? PositionID { get; set; }
        public string PositionName { get; set; }

        public int? Number { get; set; }

        public string Exp { get; set; }

        public int? Project { get; set; }
        public string ProjectName { get; set; }


        public int index { get; set; }
        public int size { get; set; }
    }
}
