using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.ProfileModel
{
    public class EmployeeResponseServices
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string OrgnizationName { get; set; }
        public string PositionName { get; set; }
        public int? OrgId { get; set; }
        public int? PositionId { get; set; }
        public int? StatusId { get; set; }
        public string StatusName { get; set; }
        public string TitleName { get; set; }
        public int? TitleId { get; set; }
        public string JoinDate { get; set; }
        public string ContractNo { get; set; }
    }
}
