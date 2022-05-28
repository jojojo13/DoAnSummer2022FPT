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

        #region DM vi tri cong viec
        [AllowAnonymous]
        [HttpGet("GetAllPosition")]
        public IActionResult GetAllPosition(PositionResponse objResponse)
        {
            Position tobj = new Position();
            tobj.Name = objResponse.Name;
            tobj.Code = objResponse.Code;
            tobj.Status = objResponse.Status;
            tobj.Note = objResponse.Note;
            tobj.Title.Name = objResponse.TitleName;
            tobj.BasicSalary = objResponse.BasicSalary;
            tobj.OtherSkill = objResponse.OtherSkill;
            tobj.Other_List.Name = objResponse.FormWorkingName;
            tobj.Other_List1.Name = objResponse.Learning_levelName;
            tobj.year_exp = objResponse.year_exp;
            tobj.Other_List2.Name = objResponse.majorGroupName;
            tobj.major = objResponse.major;
            tobj.Other_List3.Name = objResponse.languageName;
            tobj.Other_List4.Name = objResponse.language_levelName;
            tobj.Other_List5.Name = objResponse.Information_levelName;
            List<Position>list = p.GetAllPosition(tobj, objResponse.index, objResponse.size);
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
        [HttpPut("ActivePosition")]
        public IActionResult ActivePosition([FromBody] string ListID)
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
                var check = p.ActiveOrDeActivePosition(lst, -1);
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
        [HttpPut("DeActivePosition")]
        public IActionResult DeActivePosition([FromBody] string ListID)
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
                var check = p.ActiveOrDeActivePosition(lst, 0);
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
        [HttpPost("DeletePosition")]
        public IActionResult DeletePosition([FromBody] string ListID)
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
                var check = p.DeletePosition(lst);
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
        [HttpPost("InsertPosition")]
        public IActionResult InsertPosition([FromBody] PositionResponse objresponse)
        {
            try
            {
                Position tobj = new Position();
                tobj.Name = objresponse.Name;
                tobj.Note = objresponse.Note;
                tobj.TitleID = objresponse.TitleID;
                tobj.OtherSkill = objresponse.OtherSkill;
                tobj.FormWorking = objresponse.FormWorking;
                tobj.BasicSalary = objresponse.BasicSalary;
                tobj.Learning_level = objresponse.Learning_level;
                tobj.year_exp = objresponse.year_exp;
                tobj.majorGroup = objresponse.majorGroup;
                tobj.language = objresponse.language;
                tobj.language_level = objresponse.language_level;
                tobj.Information_level = objresponse.Information_level;
                var check = p.InsertPosition(tobj);
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
        [HttpPut("ModifyPosition")]
        public IActionResult ModifyPosition([FromBody] PositionResponse objresponse)
        {
            try
            {
                Position tobj = new Position();
                tobj.Name = objresponse.Name;
                tobj.Note = objresponse.Note;
                tobj.TitleID = objresponse.TitleID;
                tobj.OtherSkill = objresponse.OtherSkill;
                tobj.FormWorking = objresponse.FormWorking;
                tobj.BasicSalary = objresponse.BasicSalary;
                tobj.Learning_level = objresponse.Learning_level;
                tobj.year_exp = objresponse.year_exp;
                tobj.majorGroup = objresponse.majorGroup;
                tobj.language = objresponse.language;
                tobj.language_level = objresponse.language_level;
                tobj.Information_level = objresponse.Information_level;
                var check = p.ModifyPosition(tobj);
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

        #region Quan ly to chuc
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
        #endregion

        #region Thiet lap vi tri cong viec cho phong ban
        [AllowAnonymous]
        [HttpGet("GetAllPositionOrg")]
        public IActionResult GetAllPositionOrg(PositionOrgResponse objResponse)
        {
            PositionOrg tobj = new PositionOrg();
            tobj.Status = objResponse.Status;
            tobj.positionID = objResponse.positionID;
            tobj.OrgID = objResponse.OrgID;
            tobj.position.Name = objResponse.positionName;
            tobj.oRgnization.Name = objResponse.OrgName;
            List<PositionOrg> list = p.GetAllPositionOrg(tobj, objResponse.index, objResponse.size);
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
        [HttpPut("ActivePositionOrg")]
        public IActionResult ActivePositionOrg([FromBody] string ListID)
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
                var check = p.ActiveOrDeActivePositionOrg(lst, -1);
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
        [HttpPut("DeActivePositionOrg")]
        public IActionResult DeActivePositionOrg([FromBody] string ListID)
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
                var check = p.ActiveOrDeActivePositionOrg(lst, 0);
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
        [HttpPost("DeletePositionOrg")]
        public IActionResult DeletePositionOrg([FromBody] string ListID)
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
                var check = p.DeletePositionOrg(lst);
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
        [HttpPost("InsertPositionOrg")]
        public IActionResult InsertPositionOrg([FromBody] PositionOrgResponse objresponse)
        {
            try
            {
                PositionOrg tobj = new PositionOrg();
                tobj.Status = -1;
                tobj.OrgID = objresponse.OrgID;
                tobj.positionID = objresponse.positionID;
                var check = p.InsertPositionOrg(tobj);
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
        [HttpPut("ModifyPositionOrg")]
        public IActionResult ModifyPositionOrg([FromBody] PositionOrgResponse objresponse)
        {
            try
            {
                PositionOrg tobj = new PositionOrg();
                tobj.OrgID = objresponse.OrgID;
                tobj.positionID = objresponse.positionID;
                var check = p.ModifyPositionOrg(tobj);
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
    }
}
