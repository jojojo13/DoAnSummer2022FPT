using API.ResponseModel.Orgnization;
using CapstoneModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.OrgnizationServiecs;
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
        private IOrgnization p = new Orgnization();

        #region List

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
        [HttpPut("ModifyOT")]
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


        #region DM chuc danh
        [AllowAnonymous]
        [HttpGet("GetAllTitle")]
        public IActionResult GetAllTitle(TitleResponse title)
        {
            Title tobj = new Title();
            tobj.Name = title.Name;
            tobj.Code = title.Code;
            tobj.Note = title.Note;
            tobj.Status = title.Status;
            List<Title> list = p.GetAllTitle(tobj, title.index, title.size);
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
        [HttpPut("ActiveTitle")]
        public IActionResult ActiveTitle([FromBody] string ListID)
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
                var check = p.ActiveOrDeActiveTitle(lst, -1);
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
        [HttpPut("DeActiveTitle")]
        public IActionResult DeActiveTitle([FromBody] string ListID)
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
                var check = p.ActiveOrDeActiveTitle(lst, 0);
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
        [HttpPost("DeleteTitle")]
        public IActionResult DeleteTitle([FromBody] string ListID)
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
                var check = p.DeleteTitle(lst);
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
        [HttpPost("InsertTitle")]
        public IActionResult InsertTitle([FromBody] TitleResponse objresponse)
        {
            try
            {
                Title obj = new Title();
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.Name = objresponse.Name;
                obj.Code = objresponse.Code;
                var check = p.InsertTitle(obj);
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
        [HttpPut("ModifyTitle")]
        public IActionResult ModifyTitle([FromBody] TitleResponse objresponse)
        {
            try
            {
                Title obj = new Title();
                obj.Id = objresponse.Id;
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                var check = p.ModifyTitle(obj);
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

        #endregion

        #region Business

        [AllowAnonymous]
        [HttpGet("GetAllOrg")]
        public IActionResult GetAllOrg(OrgResponse Org)
        {
            ORgnization tobj = new ORgnization();
            tobj.Name = Org.Name;
            tobj.Code = Org.Code;
            tobj.Note = Org.Note;
            tobj.Status = Org.Status;
            tobj.CreateDate = Org.CreateDate;
            tobj.DissolutionDate = Org.DissolutionDate;
            tobj.Note = Org.Note;
            tobj.Fax = Org.Fax;
            tobj.Email = Org.Email;
            tobj.Mobile = Org.Mobile;
            tobj.NumberBussines = Org.NumberBussines;
            tobj.Address = Org.Address;
            List<ORgnization> list = p.GetAllORgnization(tobj);
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
        [HttpPut("ActiveOrg")]
        public IActionResult ActiveOrg([FromBody] int ID)
        {
            try
            {
                var check = p.ActiveOrDeActiveOrg(ID, -1);
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
        [HttpPut("DeActiveOrg")]
        public IActionResult DeActiveOrg([FromBody] int ID)
        {
            try
            {
                var check = p.ActiveOrDeActiveOrg(ID, 0);
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
        [HttpPost("DeleteOrg")]
        public IActionResult DeleteOrg([FromBody] int ID)
        {
            try
            {

                var check = p.DeleteOrg(ID);
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
        [HttpPost("InsertOrg")]
        public IActionResult InsertOrg([FromBody] OrgResponse objresponse)
        {
            try
            {
                ORgnization obj = new ORgnization();
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.CreateDate = objresponse.CreateDate;
                obj.DissolutionDate = objresponse.DissolutionDate;
                obj.ParentID = objresponse.ParentID;
                obj.CreateDate = objresponse.CreateDate;
                obj.DissolutionDate = objresponse.DissolutionDate;
                obj.Note = objresponse.Note;
                obj.Fax = objresponse.Fax;
                obj.Email = objresponse.Email;
                obj.Mobile = objresponse.Mobile;
                obj.NumberBussines = objresponse.NumberBussines;
                obj.Address = objresponse.Address;
                obj.NationID = objresponse.NationID;
                obj.ProvinceID = objresponse.ProvinceID;
                obj.DistrictID = objresponse.DistrictID;
                obj.WardID = objresponse.WardID;
                obj.ManagerID = objresponse.ManagerID;
                var check = p.InsertOrg(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
                    });
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
        [HttpPut("ModifyOrg")]
        public IActionResult ModifyOrg([FromBody] OrgResponse objresponse)
        {
            try
            {
                ORgnization obj = new ORgnization();
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.CreateDate = objresponse.CreateDate;
                obj.DissolutionDate = objresponse.DissolutionDate;
                obj.ParentID = objresponse.ParentID;
                obj.CreateDate = objresponse.CreateDate;
                obj.DissolutionDate = objresponse.DissolutionDate;
                obj.Note = objresponse.Note;
                obj.Fax = objresponse.Fax;
                obj.Email = objresponse.Email;
                obj.Mobile = objresponse.Mobile;
                obj.NumberBussines = objresponse.NumberBussines;
                obj.Address = objresponse.Address;
                obj.NationID = objresponse.NationID;
                obj.ProvinceID = objresponse.ProvinceID;
                obj.DistrictID = objresponse.DistrictID;
                obj.WardID = objresponse.WardID;
                obj.ManagerID = objresponse.ManagerID;
                var check = p.ModifyOrg(obj);
                if (check)
                    return Ok(new
                    {
                        Status = true
                    });
                else
                    return Ok(new
                    {
                        Status = false
                    });
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }

        #region Quan ly to chuc

        #endregion

        #endregion
    }
}
