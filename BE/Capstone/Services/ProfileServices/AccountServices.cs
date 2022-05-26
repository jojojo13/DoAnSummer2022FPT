using CapstoneModels;
using Services.CommonModel;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileServices
{
    partial class Profile : IProfile
    {
        public Account GetAccount(Account a)
        {
            try
            {

                using (Context context = new Context())
                {
                    Account tobj = context.Accounts.Where(x => x.UserName == a.UserName && x.Pass == a.Pass).FirstOrDefault();
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
                using (Context context = new Context())
                {
                    Account tobj = context.Accounts.Where(x => x.UserName == a.UserName && x.Pass == a.Pass).FirstOrDefault();
                    tobj.Pass = a.Pass;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ResetPass(Account a, MailDTO mailDTO)
        {
            try
            {
                using (Context context = new Context())
                {
                    Account tobj = context.Accounts.Where(x => x.UserName == a.UserName && x.Pass == a.Pass).FirstOrDefault();
                    tobj.Pass = Guid.NewGuid().ToString("d").Substring(1, 8);
                    context.SaveChanges();
                    EmployeeCV em = context.EmployeeCVs.Where(x => x.EmployeeID == tobj.EmployeeID).FirstOrDefault();
                    string email = em.EmailWork;
                    mailDTO.tomail = email;
                    mailDTO.content = "Mật khẩu mới của bạn là : " + tobj.Pass+"</br>"+"Vui lòng thay đổi mật khẩu mới sau khi đăng nhập";
                    Common common = new Common();
                    if (common.sendMail(mailDTO))
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
