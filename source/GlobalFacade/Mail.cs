using System;
using System.Web.Mail;
using System.Configuration;

namespace GlobalFacade
{
	/// <summary>
	/// clsSendMail 的摘要说明。
	/// </summary>
	public class Mail
	{
		public string Application; 
		public string FromAddress; 
		public string ToAddress; 
		public string CClist; 
		public string BCClist; 
		public string Filelist; 
		public string Subject; 
		public MailPriority Priority;
		public MailFormat Mailformat; 
		public string Body; 
		
		private string refno;
		private string refid;
		
		public string RefNO
		{
			get 
			{
				return Application+refno;
			}
		}
		public string RefID
		{
			get 
			{
				return refid;
			}
		}


		public Mail()
		{
			int d=(int)System.DateTime.Now.Day;
			if (d<=9)
			{
				d=d+48;
			}
			else
			{
				d=d+55;
			}
			char c=(char)d;
			refno=System.DateTime.Now.ToString("yy")+System.DateTime.Now.Month.ToString("X1")+
				c.ToString()+System.DateTime.Now.ToString("HHmmss")+System.DateTime.Now.Millisecond.ToString();

			refid=System.Guid.NewGuid().ToString();

		}


		public void SendMail(string subject,string body,string from,string to,string application,MailPriority priority,MailFormat mailformat,string cc,string bcc,string attachments)
		{
			Application=application;
			FromAddress=from; 
			ToAddress=to; 
			CClist=cc; 
			BCClist=bcc; 
			Filelist=attachments; 
			Subject=subject; 
			Priority=priority; 
			Mailformat=mailformat; 
			Body=body; 

			SendMail();
		}

		private void SendMail()
		{
			MailMessage Message = new MailMessage();
			string files="";
			
			try
			{
				try
				{
					Message.To = ToAddress;
					Message.From = FromAddress;
					Message.Cc=CClist;
					Message.Bcc=BCClist;

                    if (ConfigurationManager.AppSettings["SMTP_NeedAuthentication"].ToLower() == "true")
					{
						//定义SMTP邮件服务器需要身份认证
						Message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
						//认证的用户名
                        Message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", ConfigurationManager.AppSettings["SMTP_User"]);
						//认证密码
                        Message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", ConfigurationManager.AppSettings["SMTP_Password"]);
					}

					if(Filelist != string.Empty)
					{
						string[] flist=Filelist.Split(';');
						for(int i=0;i<flist.Length;i++)
						{
							string[] t=flist[i].Split('\\');
							files+=(files==""?"":";")+t[t.Length-1];
							Message.Attachments.Add(new MailAttachment(flist[i]));
						}
					}

					Message.Subject = Subject;
					Message.Priority = Priority;
					Message.Body = "RefNO: "+Application+refno+(char)13+(char)10+(Mailformat==MailFormat.Html?"<p><hr></p>":"") + Body;
					Message.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");
					Message.BodyFormat = Mailformat;
				
					try
					{
                        SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SMTPServer"];
						SmtpMail.Send(Message);
					}
					catch(System.Web.HttpException)
					{
						return;
					}
				}
				catch(IndexOutOfRangeException)
				{
					return;
				}
			}
			catch(System.Exception)
			{
				return;
			}
			
		}
	}
}
