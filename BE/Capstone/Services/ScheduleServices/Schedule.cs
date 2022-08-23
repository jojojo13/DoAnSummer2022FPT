using ModelAuto.Models;
using Services.CandidateService;
using Services.CommonModel;
using Services.CommonServices;
using Services.ResponseModel.CandidateModel;
using Services.ResponseModel.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ScheduleServices
{
    public class ScheduleImpl : ISchedule
    {

        ICandidate c = new CandidateImpl();

        public bool DeleteSchedule(List<int> listID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in listID)
                    {
                        RcEvent tobj = new RcEvent();
                        tobj = context.RcEvents.Where(x => x.Id == item).FirstOrDefault();
                        context.RcEvents.Remove(tobj);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool InsertSchedule(RcEvent T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    RcEvent tobj = new RcEvent();
                    tobj.Classname = T.Classname;
                    tobj.Title = T.Title;
                    tobj.RequestId = T.RequestId;
                    tobj.CandidateId = T.CandidateId;
                    tobj.StartHour = T.StartHour;
                    tobj.EndHour = T.EndHour;
                    context.RcEvents.Add(tobj);
                    context.SaveChanges();


                    string time =T.Title+"_"+ T.Classname +" : "+ T.StartHour + " -> " + T.EndHour;
                   
                    ICommon common = new CommonImpl();
                    var obj = (from cv in context.RcCandidateCvs.Where(x => x.CandidateId == T.CandidateId)
                               from can in context.RcCandidates.Where(x => x.Id == cv.CandidateId)
                               select new
                               {
                                   fullname = can.FullName,
                                   email = cv.Email,
                               }).FirstOrDefault();


                    var obj2 = (from re in context.RcRequests.Where(x => x.Id == T.RequestId)
                                from p in context.Positions.Where(x => x.Id == re.PositionId).DefaultIfEmpty()
                                from o in context.Orgnizations.Where(x => x.Id == re.OrgnizationId).DefaultIfEmpty()
                                from e in context.Employees.Where(x => x.Id == re.HrInchange).DefaultIfEmpty()
                                from ecv in context.EmployeeCvs.Where(x => x.EmployeeId == e.Id).DefaultIfEmpty()
                                select new
                                {
                                    orgName = o.Name,
                                    location = o.Address,
                                    hrName = e.FullName,
                                    phoneHr = ecv.Phone,
                                    position = p.Name
                                }).FirstOrDefault();

                    string contact = obj2.hrName + " SDT :" + obj2.phoneHr;
                    if (obj.email != null)
                    {
                        MailDTO mailDTO = new MailDTO();
                        mailDTO.subject = "CapSum22 Thư mời phỏng vấn / Test";
                        mailDTO.content = "<p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>&nbsp;</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>Xin ch&agrave;o Anh/Chị "+obj.fullname+" ,</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white; border-box;overflow-wrap: break-word;font-variant-ligatures: normal;font-variant-caps: normal;orphans: 2;text-align:start;widows: 2;-webkit-text-stroke-width: 0px;text-decoration-thickness: initial;text-decoration-style: initial;text-decoration-color: initial;word-spacing:0px;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>Ch&uacute;c mừng Anh/Chị đ&atilde; vượt qua v&ograve;ng x&eacute;t tuyển hồ sơ của c&ocirc;ng ty cổ phần &nbsp;phần mềm CapSum2022 cho vị tr&iacute; &nbsp;"+obj2.position +" .</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white; border-box;overflow-wrap: break-word;font-variant-ligatures: normal;font-variant-caps: normal;orphans: 2;text-align:start;widows: 2;-webkit-text-stroke-width: 0px;text-decoration-thickness: initial;text-decoration-style: initial;text-decoration-color: initial;word-spacing:0px;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>C&ocirc;ng ty ch&uacute;ng t&ocirc;i nhận thấy Anh/Chị c&oacute; những kiến thức chuy&ecirc;n m&ocirc;n ph&ugrave; hợp để đ&aacute;p ứng những c&ocirc;ng việc cho vị tr&iacute; m&agrave; ch&uacute;ng t&ocirc;i đang tuyển. V&igrave; thế, ch&uacute;ng t&ocirc;i xin gửi thư n&agrave;y để hẹn Anh/Chị một buổi phỏng/test vấn tại:</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white; border-box;overflow-wrap: break-word;font-variant-ligatures: normal;font-variant-caps: normal;orphans: 2;text-align:start;widows: 2;-webkit-text-stroke-width: 0px;text-decoration-thickness: initial;text-decoration-style: initial;text-decoration-color: initial;word-spacing:0px;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>Địa chỉ : "+obj2.location+"&nbsp;</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white; border-box;overflow-wrap: break-word;font-variant-ligatures: normal;font-variant-caps: normal;orphans: 2;text-align:start;widows: 2;-webkit-text-stroke-width: 0px;text-decoration-thickness: initial;text-decoration-style: initial;text-decoration-color: initial;word-spacing:0px;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>Thời gian : "+ time + "  </span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white; border-box;overflow-wrap: break-word;font-variant-ligatures: normal;font-variant-caps: normal;orphans: 2;text-align:start;widows: 2;-webkit-text-stroke-width: 0px;text-decoration-thickness: initial;text-decoration-style: initial;text-decoration-color: initial;word-spacing:0px;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>Anh/Chị vui l&ograve;ng x&aacute;c nhận lại thời gian, địa điểm phỏng vấn ngay khi nhận được thư n&agrave;y để ch&uacute;ng t&ocirc;i chuẩn bị đ&oacute;n tiếp Anh/Chị một c&aacute;ch chu đ&aacute;o nhất. Để biết th&ecirc;m c&aacute;c th&ocirc;ng tin kh&aacute;c, Anh/Chị c&oacute; thể li&ecirc;n hệ với ch&uacute;ng t&ocirc;i qua:</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white; border-box;overflow-wrap: break-word;font-variant-ligatures: normal;font-variant-caps: normal;orphans: 2;text-align:start;widows: 2;-webkit-text-stroke-width: 0px;text-decoration-thickness: initial;text-decoration-style: initial;text-decoration-color: initial;word-spacing:0px;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>Địa chỉ li&ecirc;n hệ : "+contact+"&nbsp;</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>Tr&acirc;n trọng!</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>&nbsp;</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:8.0pt;line-height:107%;background:white;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>C&ocirc;ng ty C&ocirc;ng ty Cổ phần Phần mềm CapSum2022</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:8.0pt;line-height:107%;background:white;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>Địa chỉ Tầng 5, Green Office- Meco Complex, 102 Trường Chinh, Đống Đa, H&agrave; Nội</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:8.0pt;line-height:107%;background:white;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>Website http://softmart.net.vn</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:19.5pt;line-height:107%;background:white;'><span style='font-size:17px;font-family:\"Helvetica\",\"sans-serif\";color:#222222;'>Hotline : 098.939.6668</span></p><p style='margin-right:0in;margin-left:0in;font-size:15px;font-family:\"Calibri\",\"sans-serif\";margin-top:0in;margin-bottom:8.0pt;line-height:107%;'>&nbsp;</p>";
                        mailDTO.fromMail = "aisolutionssum22@gmail.com";
                        mailDTO.pass = "miztlfnbereqmeko";
                        mailDTO.listCC = new List<string>();
                        mailDTO.listBC = new List<string>();
                        mailDTO.tomail = obj.email;
                        common.sendMail(mailDTO);
                    }


                    // add vào bước 2
                    List<RcEvent> listintestview = context.RcEvents.Where(x => x.CandidateId == T.CandidateId && x.RequestId == T.RequestId && x.Classname == "interview").ToList();
                    List<RcEvent> listtest = context.RcEvents.Where(x => x.CandidateId == T.CandidateId && x.RequestId == T.RequestId && x.Classname == "test").ToList();
                    SetStep2 step2 = new SetStep2();
                    step2.CandidateId = T.CandidateId;
                    step2.RequestId = T.RequestId;
                    if (listintestview.Count > 0)
                    {
                        step2.Step2InterView = 1;
                    }
                    if (listtest.Count > 0)
                    {
                        step2.Step2Test = 1;
                    }
                    bool check = c.AddStep2(step2);
                    return true;
                }
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                return false;
            }
        }


        public bool ModifySchedule(RcEvent T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    RcEvent tobj = context.RcEvents.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Classname = T.Classname;
                    tobj.Title = T.Title;
                    tobj.RequestId = T.RequestId;
                    tobj.CandidateId = T.CandidateId;
                    tobj.StartHour = T.StartHour;
                    tobj.EndHour = T.EndHour;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<RcEvent> getSchedule(int requestId, int candidateId)
        {
            List<RcEvent> list = new List<RcEvent>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    list = context.RcEvents.Where(x => x.RequestId == requestId && x.CandidateId == candidateId).ToList();
                }
            }
            catch
            {

            }
            return list;
        }

        public bool CheckTime(RcEvent T)
        {
            bool check = false;
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    DateTime startHour = Convert.ToDateTime(T.StartHour);
                    DateTime endHour = Convert.ToDateTime(T.EndHour);
                    List<RcEvent> list = new List<RcEvent>();
                    list = context.RcEvents.Where(x => x.RequestId == T.RequestId && x.CandidateId == T.CandidateId).ToList();
                    if (list.Count == 0)
                    {
                        check = true;
                    }
                    else
                    {
                        foreach (var item in list)
                        {
                            DateTime from = Convert.ToDateTime(item.StartHour);
                            DateTime to = Convert.ToDateTime(item.EndHour);
                            if (startHour < from && endHour <= from || startHour >= to && endHour > to)
                            {
                                check = true;
                            }
                            else
                            {
                                check = false;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return check;
        }
        public List<ScheduleRes> GettoAddStep3Interview(int candidate, int request)
        {

            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    var list = from c in context.RcEvents.Where(x => x.RequestId == request && x.CandidateId == candidate && x.Classname == "interview").ToList()
                               select new ScheduleRes { Id = c.Id, Title = c.Title, Score = c.Score, Note = c.Note };
                    return list.OrderBy(x => x.Id).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public List<ScheduleRes> GettoAddStep3Test(int candidate, int request)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    var list = from c in context.RcEvents.Where(x => x.RequestId == request && x.CandidateId == candidate && x.Classname == "test").ToList()
                               select new ScheduleRes { Id = c.Id, Title = c.Title, Score = c.Score, Note = c.Note };
                    return list.OrderBy(x => x.Id).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public string GettoAddStep3Interview1(int candidate, int request)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    var list = from c in context.RcEvents.Where(x => x.RequestId == request && x.CandidateId == candidate && x.Classname == "interview").ToList()
                               select new ScheduleRes { Id = c.Id, Title = c.Title, Score = c.Score, Note = c.Note };
                    string txt = "";
                  
                    foreach (ScheduleRes item in list)
                    {
                        txt +=  "Title: " + item.Title + " \nScore:" + item.Score + "\nNote:" + item.Note + " \n---\n ";
                      
                    }
                    return txt;
                }
            }
            catch
            {
                return null;
            }
        }

        public string GettoAddStep3Test1(int candidate, int request)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    var list = from c in context.RcEvents.Where(x => x.RequestId == request && x.CandidateId == candidate && x.Classname == "test").ToList()
                               select new ScheduleRes { Id = c.Id, Title = c.Title, Score = c.Score, Note = c.Note };
                    string txt = "";
                    
                    foreach (ScheduleRes item in list)
                    {
                        txt += "Title: " + item.Title + " \nScore:" + item.Score + "\nNote:" + item.Note + " \n---\n ";
                      
                    }
                    return txt;
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
