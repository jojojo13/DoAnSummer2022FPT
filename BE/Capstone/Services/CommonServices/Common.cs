using ModelAuto.Models;
using ModelAuto;
using Services.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommonServices
{
    public class CommonImpl : ICommon
    {
        #region"List"
        public string autoGenCode3character(string tableName, string firstCode)
        {
            try
            {
                string query = "select Code from " + tableName + " order by Id desc";
                DataTable dt = DAOContext.GetDataBySql(query);
                DataRow lastRow = dt.Rows[0];
                string Code = lastRow["Code"].ToString();

                if (Code != null)
                {
                    string number = Code.Substring(Code.Length - 3);
                    return firstCode + (Convert.ToInt32(number) + 1).ToString("000");
                }
                else
                {
                    return firstCode + "001";
                }
            }
            catch
            {
                return firstCode + "001";
            }
        }

        public string autoGenCode4character(string tableName, string firstCode)
        {
            try
            {
                string query = "select Code from " + tableName + " order by Id desc";
                DataTable dt = DAOContext.GetDataBySql(query);
                DataRow lastRow = dt.Rows[0];
                string Code = lastRow["Code"].ToString();

                if (Code != null)
                {
                    string number = Code.Substring(Code.Length - 4);
                    return firstCode + (Convert.ToInt32(number) + 1).ToString("0000");
                }
                else
                {
                    return firstCode + "0001";
                }
            }
            catch
            {
                return firstCode + "0001";
            }
        }
        #endregion


        #region Get by ID
        public Orgnization getOrgByID(int id)
        {
            try
            {
                using (CapstoneProject2022Context context =new CapstoneProject2022Context())
                {
                    Orgnization obj = context.Orgnizations.Where(x => x.Id == id).FirstOrDefault();
                    obj.Manager = context.Employees.Where(x => x.Id == obj.ManagerId).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null;
            }

        }

        public Title getTitleByID(int id)
        {
            try
            {
                using (CapstoneProject2022Context context =new CapstoneProject2022Context())
                {
                    Title obj = context.Titles.Where(x => x.Id == id).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null;
            }

        }
        public Position getPositionByID(int id)
        {
            try
            {
                using (CapstoneProject2022Context context =new CapstoneProject2022Context())
                {
                    Position obj = context.Positions.Where(x => x.Id == id).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null;
            }

        }
        #endregion




        #region "Get OtherList type"

        public List<OtherListType> GetOtherListType()
        {
            try
            {
                using (CapstoneProject2022Context context =new CapstoneProject2022Context())
                {
                    List<OtherListType> list = context.OtherListTypes.Where(x => x.Status == -1).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<OtherListType>();
            }
        }
        #endregion




        #region EMAIL
        public bool sendMail(MailDTO mailobj)
        {
            try
            {
                MailMessage mail = new MailMessage();
                // you need to enter your mail address
                mail.From = new MailAddress(mailobj.fromMail);

                //To Email Address - your need to enter your to email address
                mail.To.Add(mailobj.tomail);

                mail.Subject = mailobj.subject;

                //you can specify also CC and BCC - i will skip this
                if (mailobj.listCC.Count > 0)
                {
                    foreach (var item in mailobj.listCC)
                    {
                        mail.CC.Add(item);
                    }
                }

                if (mailobj.listBC.Count > 0)
                {
                    foreach (var item in mailobj.listBC)
                    {
                        mail.Bcc.Add(item);
                    }
                }

                mail.IsBodyHtml = true;
                mail.Body = mailobj.content;


                //create SMTP instant

                //you need to pass mail server address and you can also specify the port number if you required
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                //Create nerwork credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential(mailobj.fromMail, mailobj.pass);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 25; // this is default port number - you can also change this
                smtpClient.EnableSsl = false; // if ssl required you need to enable it
                smtpClient.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        #region "Cryptography"

        public string sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
        #endregion



        public int getTotalRecord(string tableName, bool isRank)
        {
            string query =isRank==true? ("select count(*) COUNT from " + tableName+" where Rank=1"): ("select count(*) COUNT from " + tableName);
            DataTable dt = DAOContext.GetDataBySql(query);
            DataRow lastRow = dt.Rows[0];
            int COUNT = Convert.ToInt32(lastRow["COUNT"]);
            return COUNT;
        }

        public RcRequest GetRequestByID(int ID)
        {
            try
            {
                using (CapstoneProject2022Context context =new CapstoneProject2022Context())
                {
                    RcRequest obj = context.RcRequests.Where(x => x.Id == ID).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null;
            }

        }





        public int getNextSequence(string tablename)
        {
            string query = " SELECT NEXT VALUE FOR SEQ_"+tablename+" AS GID";
            DataTable dt = DAOContext.GetDataBySql(query);
            DataRow lastRow = dt.Rows[0];
            int gID = Convert.ToInt32(lastRow["GID"]);
            return gID;
        }
    }
}
