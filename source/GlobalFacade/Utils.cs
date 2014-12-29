using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlobalFacade
{
	/// <summary>
	/// Summary description for Utils.
	/// </summary>
	public class Utils
	{
		#region Embed Resources
		public static string LoadEmbedResource(System.Reflection.Assembly assembly, string resourceName)
		{
			string resourceString = string.Empty;
			System.IO.Stream stream = assembly.GetManifestResourceStream(resourceName);

			if(stream.Length > 0)
			{
				byte[] buff = new byte[stream.Length];
				stream.Read(buff, 0, buff.Length);
				resourceString = System.Text.Encoding.UTF8.GetString(buff);
			}
				
			stream.Close();
			return resourceString;
		}

		public static byte[] LoadEmbedImage(System.Reflection.Assembly assembly, string resourceName)
		{
			byte[] buff = null;
			System.IO.Stream stream = assembly.GetManifestResourceStream(resourceName);

			if(stream.Length > 0)
			{
				buff = new byte[stream.Length];
				stream.Read(buff, 0, buff.Length);
			}

			stream.Close();
			return buff;
		}

		public static void SendScriptResource(string resourceString)
		{
			System.Web.HttpContext.Current.Response.ContentType = "text/x-javascript";
			System.Web.HttpContext.Current.Response.Write(resourceString);
			System.Web.HttpContext.Current.Response.End();
		}

		public static void SendHTCResource(string resourceString)
		{
			System.Web.HttpContext.Current.Response.ContentType = "text/x-component";
			System.Web.HttpContext.Current.Response.Write(resourceString);
			System.Web.HttpContext.Current.Response.End();
		}

		public static void SendCSSResource(string resourceString)
		{
			System.Web.HttpContext.Current.Response.ContentType = "text/css";
			System.Web.HttpContext.Current.Response.Write(resourceString);
			System.Web.HttpContext.Current.Response.End();
		}

		public static void SendGIFResource(byte[] resourceBuff)
		{
			System.Web.HttpContext.Current.Response.ContentType = "image/gif";
			System.Web.HttpContext.Current.Response.OutputStream.Write(resourceBuff, 0, resourceBuff.Length);
			System.Web.HttpContext.Current.Response.End();
		}
		#endregion

		#region Converter
		public static string ConvertStatus(object o)
		{
			if(o.ToString() == "0")
				return "未完成";
			else if(o.ToString() == "1")
				return "已完成";
			else
				return string.Empty;
		}

		public static string ConvertPriority(object o)
		{
			if(o.ToString() == "1")
				return "高";
			else if(o.ToString() == "2")
				return "中";
			else if(o.ToString() == "3")
				return "低";
			else
				return string.Empty;
		}

		public static bool HasAttachment(object o)
		{
			return (o != null && o.ToString().Trim() != string.Empty)?true:false;
		}
		#endregion

		public static DataTable GetTimeTable(int hourSpan, int minuteSpan)
		{
			if(hourSpan > 12 || minuteSpan > 30)
				return null;

			DataTable timeTable = new DataTable();
			timeTable.Columns.Add("Hour",  typeof(int));
			timeTable.Columns.Add("Minute",typeof(int));
			timeTable.Columns.Add("Desc",  typeof(string));

			for (int hour = 0; hour <= 23; hour += hourSpan)
			{
				for (int minute = 0; minute <= 59; minute += minuteSpan)
				{
					DataRow newRow = timeTable.NewRow();
					newRow["Hour"]   = hour;
					newRow["Minute"] = minute;
					newRow["Desc"]   = string.Format("{0}:{1}", hour.ToString("00"), minute.ToString("00"));

					timeTable.Rows.Add(newRow);
				}
			}

			return timeTable;
		}

		public static void CloseWindowAndRefreshParent()
		{
			System.Web.HttpContext.Current.Response.Write("<script>");
			System.Web.HttpContext.Current.Response.Write("window.close();window.returnValue=true;");
			System.Web.HttpContext.Current.Response.Write("</script>");
		}
		//allen 弹出窗口保存后转到另一个页面
		public static void CloseWindowAndRefreshParent(string url)
		{
			System.Web.HttpContext.Current.Response.Write("<script>");
			System.Web.HttpContext.Current.Response.Write("window.dialogArguments.top.main.location.href ='"+url+"';");
			System.Web.HttpContext.Current.Response.Write("window.close();window.returnValue=false;");
			System.Web.HttpContext.Current.Response.Write("</script>");
		}

		public static void CloseWindow()
		{
			System.Web.HttpContext.Current.Response.Write("<script>");
			System.Web.HttpContext.Current.Response.Write("window.close();window.returnValue=false;");
			System.Web.HttpContext.Current.Response.Write("</script>");
		}
		//allen 弹出窗口关闭转到另一个页面
		public static void CloseWindow(string url)
		{
			System.Web.HttpContext.Current.Response.Write("<script>");
			System.Web.HttpContext.Current.Response.Write("window.dialogArguments.top.main.location.href ='"+url+"';");
			System.Web.HttpContext.Current.Response.Write("window.close();window.returnValue=false;");
			System.Web.HttpContext.Current.Response.Write("</script>");
		}

		public static void ShowMessage(string message)
		{
			message = message.Replace("'", "''");
			string script = "<script>alert('" + message + "')</script>";

			(System.Web.HttpContext.Current.Handler as System.Web.UI.Page).RegisterStartupScript(Guid.NewGuid().ToString(), script);
		}

		public static void ShowMessageUrl(string message, string url)
		{
			message = message.Replace("'", "''");
			string script = "<script>alert('" + message + "');location.href='" + url + "'</script>";

			(System.Web.HttpContext.Current.Handler as System.Web.UI.Page).RegisterStartupScript(Guid.NewGuid().ToString(), script);
		}

		public static void WindowText()
		{
			System.Web.HttpContext.Current.Response.Write("<script>");
			System.Web.HttpContext.Current.Response.Write("alert('客户信息添加成功!');");
			System.Web.HttpContext.Current.Response.Write("</script>");
		}
		public static void CloseWindowText(string message)
		{
			System.Web.HttpContext.Current.Response.Write("<script>");
			System.Web.HttpContext.Current.Response.Write("alert('"+message+"');window.opener=null;self.close();");
			System.Web.HttpContext.Current.Response.Write("</script>");
		}

		public static void CloseWindowText1(string message)
		{
			System.Web.HttpContext.Current.Response.Write("<script>");
			System.Web.HttpContext.Current.Response.Write("alert('"+message+"');window.opener=null;self.close();window.dialogArguments.close();");
			System.Web.HttpContext.Current.Response.Write("</script>");
		}

		public static void CloseWindowText()
		{
			System.Web.HttpContext.Current.Response.Write("<script>");
			System.Web.HttpContext.Current.Response.Write("window.opener=null;self.close();");
			System.Web.HttpContext.Current.Response.Write("</script>");
		}


		/// <summary>
		/// 用于转向 Url
		/// </summary>
		/// <param name="url"></param>
		/// <remarks>Andy 2006/11/30</remarks>		
		public static void RedirectUrl(string url)
		{
			System.Web.HttpContext.Current.Response.Write("<script>");
			System.Web.HttpContext.Current.Response.Write("location.href='"+url+"';");
			System.Web.HttpContext.Current.Response.Write("</script>");
		}
		
		public static bool IsFloat(string num)
		{
			try
			{
				Convert.ToSingle(num);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool IsDecimal(string num)
		{
			try
			{
				Convert.ToDecimal(num);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool IsInt(string num)
		{
			try
			{
				Convert.ToInt32(num);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool IsDateTime(string date)
		{
			try
			{
				Convert.ToDateTime(date);
				return true;
			}
			catch
			{
				return false;
			}
		}

		#region 半角/全角 字符转换
		/// <summary>
		/// 全角=>半角
		/// </summary>
		/// <param name="src"></param>
		/// <returns>半角字符串</returns>
		public static string SBCToDBC(string src)
		{
			if(src == null || src == string.Empty)
				return string.Empty;

			char[] c=src.ToCharArray();
			for (int i=0;i<c.Length;i++)
			{
				byte[] b=System.Text.Encoding.Unicode.GetBytes(c,i,1);
				if (b.Length==2)
				{
					if (b[1]==255)
					{
						b[0]=(byte)(b[0]+32);
						b[1]=0;
						c[i]=System.Text.Encoding.Unicode.GetChars(b)[0];
					}
				}
			}
			return new string(c);
		}
		/// <summary>
		/// 半角=>全角
		/// </summary>
		/// <param name="src"></param>
		/// <returns>全角字符串</returns>
		public static string DBCToSBC(string src)
		{
			if(src == null || src == string.Empty)
				return string.Empty;

			char[] c=src.ToCharArray();
			for (int i=0;i<c.Length;i++)
			{
				byte[] b=System.Text.Encoding.Unicode.GetBytes(c,i,1);
				if (b.Length==2)
				{
					if (b[1]==0)
					{
						b[0]=(byte)(b[0]-32);
						b[1]=255;
						c[i]=System.Text.Encoding.Unicode.GetChars(b)[0];
					}
				}
			}
			return new string(c);
		}
		#endregion

        public static void SetReadonly(Control container)
        {
            for (int i = 0; i < container.Controls.Count; i++)
            {
                if (container.Controls[i] is TextBox)
                {
                    WebControl wc = container.Controls[i] as WebControl;
                    wc.Attributes.Add("readonly", "readonly");
                    wc.Attributes.Add("onkeydown", "javascript:if(window.event.keyCode == 8) return false;");
                    wc.Style.Add("background-color", "#f1f1f1");
                }
                else if (container.Controls[i] is DropDownList || container.Controls[i] is CheckBox ||
                container.Controls[i] is RadioButton || container.Controls[i] is LinkButton || container.Controls[i] is RadioButtonList)
                {
                    WebControl wc = container.Controls[i] as WebControl;
                    wc.Attributes.Add("disabled", "disabled");
                    wc.Style.Add("background-color", "#f1f1f1");
                }
                else
                {
                    if (container.Controls[i].Controls.Count > 0)
                        SetReadonly(container.Controls[i]);
                }
            }
        }
	}
}
