using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CandidateService
{
   public class CandidateImpl: ICandidate
    {
        public List<OtherList> GetOtherListByAttribute(int? ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<OtherList> listReturn = context.OtherLists.Where(x => x.Atribute1 == ID.ToString()).ToList();
                    return listReturn;
                }
            }
            catch
            {
                return new List<OtherList>();
            }
        }
    }
}
