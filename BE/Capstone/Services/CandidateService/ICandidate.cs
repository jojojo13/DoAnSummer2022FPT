using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CandidateService
{
   public interface ICandidate
    {
        List<OtherList> GetOtherListByAttribute(int? ID);
    }
}
