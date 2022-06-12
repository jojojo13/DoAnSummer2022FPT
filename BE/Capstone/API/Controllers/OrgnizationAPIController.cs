using API.ResponseModel.Common;
using API.ResponseModel.Orgnization;
using ModelAuto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.OrgnizationServiecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.CommonServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgnizationAPIController : ControllerBase
    {
        private IOrgnization p = new OrgnizationImpl();
        private ICommon c = new CommonImpl();
        #region List

        #region OTHER_LIST

        [HttpPost("GetOtherList")]
        public IActionResult GetOtherList(string code)
        {
            List<OtherList> list = new List<OtherList>();
            list = p.GetOtherListsCombo(code);
            var listReturn = from l in list
                             select new
                             {
                                 name= l.Name,
                                 id= l.Id,
                                 code= l.Code
                             };
            if (list.Count > 0)
            {
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            }
            return StatusCode(200, "List is Null");
        }


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
                var check = p.ActiveOrDeActiveOtherList(lst, -1);
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
                var check = p.ActiveOrDeActiveOtherList(lst, 0);
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
                var check = p.DeleteOtherList(lst);
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


        [HttpPost("InsertOT")]
        public IActionResult InsertOT([FromBody] OtherListResponse objresponse)
        {
            try
            {
                OtherList obj = new OtherList();
                obj.Atribute1 = objresponse.Atribute1;
                obj.Atribute2 = objresponse.Atribute2;
                obj.Atribute3 = objresponse.Atribute3;
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.Name = objresponse.Name;
                obj.Code = objresponse.Code;
                var check = p.InsertOtherList(obj);
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


        [HttpPut("ModifyOT")]
        public IActionResult ModifyOT([FromBody] OtherListResponse objresponse)
        {
            try
            {
                OtherList obj = new OtherList();
                obj.Id = objresponse.Id;
                obj.Atribute1 = objresponse.Atribute1;
                obj.Atribute2 = objresponse.Atribute2;
                obj.Atribute3 = objresponse.Atribute3;
                obj.Note = objresponse.Note;
                obj.Name = objresponse.Name;
                var check = p.ModifyOtherList(obj);
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

        [HttpPost("GetAllTitle")]
        public IActionResult GetAllTitle(CommonResponse common)
        {
            List<Title> list = p.GetAllTitle(common.index, common.size);
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

        [HttpPost("GetAllPosition")]
        public IActionResult GetAllPosition(CommonResponse common)
        {
            List<Position> list = p.GetAllPosition(common.index, common.size);
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


        [HttpPost("InsertPosition")]
        public IActionResult InsertPosition([FromBody] PositionResponse objresponse)
        {
            try
            {
                Position tobj = new Position();
                tobj.Name = objresponse.Name;
                tobj.Note = objresponse.Note;
                tobj.TitleId = objresponse.TitleID;
                tobj.OtherSkill = objresponse.OtherSkill;
                tobj.FormWorking = objresponse.FormWorking;
                tobj.BasicSalary = objresponse.BasicSalary;
                tobj.LearningLevel = objresponse.Learning_level;
                tobj.YearExperience = objresponse.year_exp;
                tobj.MajorGroup = objresponse.majorGroup;
                tobj.Language = objresponse.language;
                tobj.LanguageLevel = objresponse.language_level;
                tobj.InformationLevel = objresponse.Information_level;
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


        [HttpPut("ModifyPosition")]
        public IActionResult ModifyPosition([FromBody] PositionResponse objresponse)
        {
            try
            {
                Position tobj = new Position();
                tobj.Name = objresponse.Name;
                tobj.Note = objresponse.Note;
                tobj.TitleId = objresponse.TitleID;
                tobj.OtherSkill = objresponse.OtherSkill;
                tobj.FormWorking = objresponse.FormWorking;
                tobj.BasicSalary = objresponse.BasicSalary;
                tobj.LearningLevel = objresponse.Learning_level;
                tobj.YearExperience = objresponse.year_exp;
                tobj.MajorGroup = objresponse.majorGroup;
                tobj.Language = objresponse.language;
                tobj.LanguageLevel = objresponse.language_level;
                tobj.InformationLevel = objresponse.Information_level;
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


        [HttpPost("getOrgByID")]
        public IActionResult getOrgByID(int Id)
        {
            GetChildOrgnization g = new GetChildOrgnization();
            Orgnization x = c.getOrgByID(Id);
            var returnObj = new
            {
                Name = x.Name,
                Id = x.Id,
                Code = x.Code,
                Level = x.Level,
                ParentID = x.ParentId,
                managerID= x.ManagerId,
                managerName= x.Manager?.FullName
            };
            if (x != null)
            {
                return Ok(new
                {
                    Status = true,
                    Data = returnObj
                });
            }
            return StatusCode(200, "obj is Null");
        }

        [HttpPost("GetAllOrg")]
        public IActionResult GetAllOrg()
        {
            GetChildOrgnization g = new GetChildOrgnization();
            List<Orgnization> list = p.GetAllOrgnization();
            var ListReturn = list.Where(x => x.Level == 1).Select(x => new OrgResponse()
            {
                Name = x.Name,
                Id = x.Id,
                Code = x.Code,
                Level = x.Level,
                ParentID = x.ParentId,
                Children = g.GetChildOrg(list, x.Id),
            }).ToList();
            if (list.Count > 0)
            {
                return Ok(new
                {
                    Status = true,
                    Data = ListReturn
                });
            }
            return StatusCode(200, "List is Null");
        }


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


        [HttpPost("InsertOrg")]
        public IActionResult InsertOrg([FromBody] OrgResponse objresponse)
        {
            try
            {
                Orgnization obj = new Orgnization();
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.CreateDate = objresponse.CreateDate;
                obj.DissolutionDate = objresponse.DissolutionDate;
                obj.ParentId = objresponse.ParentID;
                obj.CreateDate = objresponse.CreateDate;
                obj.DissolutionDate = objresponse.DissolutionDate;
                obj.Note = objresponse.Note;
                obj.Fax = objresponse.Fax;
                obj.Email = objresponse.Email;
                obj.Phone = objresponse.Mobile;
                obj.NumberBussines = objresponse.NumberBussines;
                obj.Address = objresponse.Address;
                obj.NationId = objresponse.NationID;
                obj.ProvinceId = objresponse.ProvinceID;
                obj.DistrictId = objresponse.DistrictID;
                obj.WardId = objresponse.WardID;
                obj.ManagerId = objresponse.ManagerID;
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


        [HttpPut("ModifyOrg")]
        public IActionResult ModifyOrg([FromBody] OrgResponse objresponse)
        {
            try
            {
                Orgnization obj = new Orgnization();
                obj.Note = objresponse.Note;
                obj.Status = -1;
                obj.CreateDate = objresponse.CreateDate;
                obj.DissolutionDate = objresponse.DissolutionDate;
                obj.ParentId = objresponse.ParentID;
                obj.CreateDate = objresponse.CreateDate;
                obj.DissolutionDate = objresponse.DissolutionDate;
                obj.Note = objresponse.Note;
                obj.Fax = objresponse.Fax;
                obj.Email = objresponse.Email;
                obj.Phone = objresponse.Mobile;
                obj.NumberBussines = objresponse.NumberBussines;
                obj.Address = objresponse.Address;
                obj.NationId = objresponse.NationID;
                obj.ProvinceId = objresponse.ProvinceID;
                obj.DistrictId = objresponse.DistrictID;
                obj.WardId = objresponse.WardID;
                obj.ManagerId = objresponse.ManagerID;
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

        [HttpPost("GetAllPositionOrg")]
        public IActionResult GetAllPositionOrg(CommonResponse common)
        {
            List<PositionOrg> list = p.GetAllPositionOrg(common.index, common.size);
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


        [HttpPost("InsertPositionOrg")]
        public IActionResult InsertPositionOrg([FromBody] PositionOrgResponse objresponse)
        {
            try
            {
                PositionOrg tobj = new PositionOrg();
                tobj.Status = -1;
                tobj.OrgId = objresponse.OrgID;
                tobj.PositionId = objresponse.positionID;
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


        [HttpPut("ModifyPositionOrg")]
        public IActionResult ModifyPositionOrg([FromBody] PositionOrgResponse objresponse)
        {
            try
            {
                PositionOrg tobj = new PositionOrg();
                tobj.OrgId = objresponse.OrgID;
                tobj.PositionId = objresponse.positionID;
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


        [HttpPost("GetListOrgByOrgID")]
        public IActionResult GetListOrgByOrgID(int ID)
        {
            List<Orgnization> list = p.GetListOrgByOrgID(ID);

            var listReturn = from l in list
                             select new
                             {
                                 Name = l.Name,
                                 Code = l.Code,
                                 ParentId = l.ParentId,
                                 Level = l.Level,
                                 ID = l.Id
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            else
                return StatusCode(200, "Obj is Null");
        }


        #endregion


        #endregion
    }
}
