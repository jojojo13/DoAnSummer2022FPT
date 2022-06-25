﻿using ModelAuto;
using ModelAuto.Models;
using Services.CommonModel;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileServices
{
    public partial class ProfileImpl : IProfile
    {

        public Account GetAccount(Account a)
        {
            try
            {
                ICommon common = new CommonImpl();
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Account tobj = context.Accounts.Where(x => x.UserName == a.UserName && x.Pass == common.sha256_hash(a.Pass)).FirstOrDefault();
                    tobj.Employee = context.Employees.Where(x => x.Id == tobj.EmployeeId).FirstOrDefault();
                    if (tobj != null)
                    {
                        return tobj;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public bool ChangePass(Account a)
        {
            try
            {
                ICommon c = new CommonImpl();
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Account tobj = context.Accounts.Where(x => x.UserName == a.UserName && x.Pass == a.Pass).FirstOrDefault();
                    tobj.Pass = c.sha256_hash(a.Pass);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public Employee GetEmployeeByID(int? ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Employee e = context.Employees.Where(x => x.Id == ID).FirstOrDefault();
                    return e;
                }
            }
            catch
            {
                return null;
            }
        }
        public bool ResetPass(string userName, MailDTO mailobj)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    ICommon c = new CommonImpl();
                    Account tobj = context.Accounts.Where(x => x.UserName.Equals(userName)).FirstOrDefault();
                    string newpass = Guid.NewGuid().ToString("d").Substring(1, 8);
                    string newHashPass = c.sha256_hash(newpass);
                    tobj.Pass = newHashPass;
                    context.SaveChanges();
                    EmployeeCv em = context.EmployeeCvs.Where(x => x.EmployeeId == tobj.EmployeeId).FirstOrDefault();
                    string email = em.EmailWork;
                    mailobj.tomail = email;
                    mailobj.content = "Mật khẩu mới của bạn là : " + newpass  + "</br>   Vui lòng thay đổi mật khẩu mới sau khi đăng nhập";
                    ICommon common = new CommonImpl();
                    if (common.sendMail(mailobj))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
