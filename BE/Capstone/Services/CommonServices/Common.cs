using CapstoneModels;
using Microsoft.Extensions.Configuration;
using Services.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommonServices
{
    public class Common : ICommon
    {
        #region"List"
        public string autoGenCode3character(string tableName, string firstCode)
        {
            try
            {
                string query = "select Code from " + tableName + " order by Id desc";
                DataTable dt = DAOContext.GetDataBySql(query);
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
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
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
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
        public ORgnization getOrgByID(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    ORgnization obj = context.ORgnizations.Where(x => x.Id == id).FirstOrDefault();
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
                using (Context context = new Context())
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
                using (Context context = new Context())
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




        #region "Get data OtherList combo"
        public List<Other_List> GetOther_ListsCombo(string code)
        {
            try
            {
                using (Context context = new Context())
                {
                    Other_List_Type type = context.Other_Lists_Types.Where(x => x.Code.Trim().ToLower().Equals(code)).FirstOrDefault();
                    List<Other_List> list = context.Other_Lists.Where(x => x.TypeID == type.Id).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<Other_List>();
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
                    foreach(var item in mailobj.listCC)
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
                SmtpClient smtpClient = new SmtpClient("mail.example.com");

                //Create nerwork credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential(mailobj.fromMail, mailobj.pass);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 25; // this is default port number - you can also change this
                smtpClient.EnableSsl = false; // if ssl required you need to enable it
                smtpClient.Send(mail);
                return true;
            }
            catch{
                return false;
            }
        }
        #endregion

    }
}
