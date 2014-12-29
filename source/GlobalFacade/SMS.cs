using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Net;
using System.Web.SessionState;
using System.ComponentModel;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Collections.Specialized;

namespace GlobalFacade
{
    public class SMS
    {
        #region 短信相关
        // true 发送验证码/ false成功短信
        public string SendMsg(string mobile, bool ckcode)
        {
            string result = string.Empty;
            string sname = ConfigurationManager.AppSettings["sname"].ToString();
            string spwd = ConfigurationManager.AppSettings["spwd"].ToString();
            string scorpid = ConfigurationManager.AppSettings["scorpid"].ToString();
            string sprdid = ConfigurationManager.AppSettings["sprdid"].ToString();
            string sdst = mobile;
            string smsg = string.Empty;
            string code = string.Empty;
            if (ckcode)
            {
                smsg = ConfigurationManager.AppSettings["MsgContent"].ToString();
                code = new Random().Next(100000, 999999).ToString();//生成验证码
                smsg = smsg.Replace("{code}", code);
            }
            else
            {
                smsg = ConfigurationManager.AppSettings["MsgSucContent"].ToString();
            }
            string PostUrl = ConfigurationManager.AppSettings["PostUrl"];
            string postStrTpl = "sname={0}&spwd={1}&scorpid={2}&sprdid={3}&sdst={4}&smsg={5}";

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, sname, spwd, scorpid, sprdid, sdst, smsg));

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                result = reader.ReadToEnd();
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(result);
                System.Xml.XmlNodeList list = xmlDoc.DocumentElement.ChildNodes;
                result += "{";
                string temp1 = string.Empty;
                string temp2 = string.Empty;
                foreach (System.Xml.XmlNode info in list)
                {
                    result += "\"" + info.Name + "\":\"" + info.InnerText + "\",";
                    if (info.Name == "State" && info.InnerText != "0")
                    {
                        temp1 = info.InnerText;
                    }
                    if (temp1 != string.Empty && info.Name == "MsgState")
                    {
                        temp2 = info.InnerText;
                    }
                }
                result = result.Substring(0, result.Length - 1);
                result += "}";
            }
            else
            {
                result = "{\"error\":\"错误的信息内容\"}";
            }
            return result;
        }

        #endregion
    }        
}
       

