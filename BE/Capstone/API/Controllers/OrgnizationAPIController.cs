using API.ResponseModel.Orgnization;
using CapstoneModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgnizationAPIController : ControllerBase
    {
        private ICommon p = new Common();
        #region OTHER_LIST
        [AllowAnonymous]
        [HttpGet("GetOtherList")]
        public IActionResult GetOtherList(string code)
        {
            List<Other_List> list = new List<Other_List>();
            list = p.GetOther_ListsCombo(code);
            if (list.Count > 0)
            {
                return Ok(new
                {
                    Status = true,
                    Data = list
                });
            }
            return StatusCode(200, "List is Null");
        }

        [AllowAnonymous]
        [HttpPut("ActiveOT")]
        public IActionResult ActiveOT([FromBody] string ListID)
        {
            try
            {
                string[] listID = ListID.Split(" ");
                List<int> lst = new List<int>();
                foreach (var item in listID)
                {
                    if (!item.Trim().Equals(""))
                    {
                        lst.Add(Convert.ToInt32(item));
                    }
                }
                var check = p.ActiveOrDeActiveOther_List(lst, -1);
                if (check)
                {
                    return Ok(new
                    {
                        Status = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = false
                    });
                }
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }

        [AllowAnonymous]
        [HttpPut("DeActiveOT")]
        public IActionResult DeActiveOT([FromBody] string ListID)
        {
            try
            {
                string[] listID = ListID.Split(" ");
                List<int> lst = new List<int>();
                foreach (var item in listID)
                {
                    if (!item.Trim().Equals(""))
                    {
                        lst.Add(Convert.ToInt32(item));
                    }
                }
                var check = p.ActiveOrDeActiveOther_List(lst, 0);
                if (check)
                {
                    return Ok(new
                    {
                        Status = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = false
                    });
                }
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("DeleteOT")]
        public IActionResult DeleteOT([FromBody] string ListID)
        {
            try
            {
                string[] listID = ListID.Split(" ");
                List<int> lst = new List<int>();
                foreach (var item in listID)
                {
                    if (!item.Trim().Equals(""))
                    {
                        lst.Add(Convert.ToInt32(item));
                    }
                }
                var check = p.DeleteOther_List(lst);
                if (check)
                {
                    return Ok(new
                    {
                        Status = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = false
                    });
                }
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("InsertOT")]
        public IActionResult InsertOT([FromBody] OtherListResponse objresponse)
        {
            try
            {
                Other_List obj = new Other_List();
                obj.Atribute1 = objresponse.Atribute1;
                obj.Atribute2 = objresponse.Atribute2;
                obj.Atribute3 = objresponse.Atribute3;
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.Name = objresponse.Name;
                obj.Code = objresponse.Code;
                var check = p.InsertOther_List(obj);
                if (check)
                {
                    return Ok(new
                    {
                        Status = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = false
                    });
                }
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("ModifyOT")]
        public IActionResult ModifyOT([FromBody] OtherListResponse objresponse)
        {
            try
            {
                Other_List obj = new Other_List();
                obj.Id = objresponse.Id;
                obj.Atribute1 = objresponse.Atribute1;
                obj.Atribute2 = objresponse.Atribute2;
                obj.Atribute3 = objresponse.Atribute3;
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                var check = p.ModifyOther_List(obj);
                if (check)
                {
                    return Ok(new
                    {
                        Status = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = false
                    });
                }
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }
        #endregion
    }
}
