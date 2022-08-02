using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResponseModel.ProfileModel
{
   public class ContractEmployeeResponse
    {
        public int ID { get; set; }
        public string OrgnizationName { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string ContractNo { get; set; }
        public string ContractType { get; set; }
        public string EffectDate { get; set; }
        public string ExpireDate { get; set; }
        public string Note { get; set; }
    }
}
