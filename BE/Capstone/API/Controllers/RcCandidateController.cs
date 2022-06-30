using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CommonServices;
using Services.RcCandidateServices;
using ModelAuto.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RcCandidateController : AuthorizeByIDController

    {
        private IRcCandidate rc= new RcCandidateBus();
        private ICommon c = new CommonImpl();

        [HttpPost("GetAllOtherList")]
        public IActionResult GetAllOtherList(string  other_list_type)
        {
            List<OtherList> list  = new List<OtherList>();
            string level = c.Level_Of_OtherListType(other_list_type);
               list= c.List_OtherList_ByID(other_list_type);
            var list1 = from a in list
                        let listcon = from c in c.List_OtherList_OfLevel(other_list_type, level) select new
                        {
                            ID = c.Id,
                            Code = c.Code,
                            Name = c.Name,
                            Type = c.TypeId,
                            Note= c.Note
                        }
                        select new
                        {
                            ID = a.Id,
                            Code = a.Code,
                            Name = a.Name,
                            Type = a.TypeId,
                            list11 = listcon
                        };
            if (list.Count > 0)
            {
                return Ok(new
                {
                   Status= true,
                   Data= list1
                });
            }
            else
            {
                return Ok(new
                {
                    Status= false,
                    Data = new List<OtherList>()
                });
            }
        }
        

    }
  
 
}
