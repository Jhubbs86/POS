using System;
using System.Xml;
using System.Data ;
using System.IO;
using System.Text;

using Wicresoft.BusinessObject;
using Wicresoft.DataAccess;
using Wicresoft.Session;
using BusinessMapping;
using GlobalFacade ; 
using AjaxPro;

namespace BusinessRule.SystemManage
{
	/// <summary>
	/// Summary description for SysRight.
	/// </summary>
	public class UIPermission
	{
		public UIPermission()
		{
			session = new Session();
			
		}
		public void SetSession(Session _session)
		{
			session = _session;
		}

		#region Fields
		
		private int rolepkid;
		public int RolePKID 
		{
			get
			{
				return rolepkid ; 
			}
			set
			{
				rolepkid = value;
			}
		}
		
		private string outxml ; 
		public string OutXml
		{
			get
			{
				return outxml;
			}
		}


		private Wicresoft.Session.Session session;
		#endregion

		#region 生成功能列表的XML文件*/
		public void GenerateMenuTreeXML()
		{
			XmlElement root ;
			XmlDocument doc = GlobalFacade.XDom.GenXmlDocument("TREENODES",out root);
			BusinessObjectCollection MenuCollection = new BusinessObjectCollection("Menu");
			MenuCollection.SessionInstance = session ; 
			BusinessFilter filter = new BusinessFilter("Menu");
			filter.AddFilterItem("Parent","0",Operation.Equal,FilterType.NumberType,AndOr.AND);
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			MenuCollection.AddFilter(filter);
			/* Andy Modify 2007-04-26 Add Order By */
            MenuCollection.Businessobject.OrderBy = "ORDER BY [DisplayOrder] ASC";
			DataTable childtable = MenuCollection.GetDataTable();
			GenerateElement(doc,root,childtable);
			outxml = doc.OuterXml;
		}

		private void GenerateElement(XmlDocument doc ,XmlElement Parent,DataTable childtable)
		{
			
			for (int i = 0 ; i <childtable.Rows.Count ; i++)
			{
				int childpkid;
				string ChsName ; 
				childpkid = (int)childtable.Rows[i]["PKID"];
				ChsName = (string)childtable.Rows[i]["ChineseName"];
				System.Xml.XmlElement child = GlobalFacade.XDom.CreateDocumentElement(doc,"TREENODE");
				RoleMenu checkmenu = new RoleMenu();
				checkmenu.SessionInstance = session ; 
				BusinessFilter checkfilter = new BusinessFilter("RoleMenu");
				checkfilter.AddFilterItem("FK_Menu",childpkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				checkfilter.AddFilterItem("FK_Role",this.rolepkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				checkfilter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
				checkmenu.AddFilter(checkfilter);
				checkmenu.Load();
				if (checkmenu.HaveRecord)
				{
					GlobalFacade.XDom.SetNodeAttribute(doc,child,"checked","true");
				}
				GlobalFacade.XDom.SetNodeAttribute(doc,child,"checkbox","true");
				GlobalFacade.XDom.SetNodeAttribute(doc,child,"TEXT",ChsName);
				GlobalFacade.XDom.SetNodeAttribute(doc,child,"NODEDATA",childpkid.ToString());
				GlobalFacade.XDom.SetNodeAttribute(doc,child,"EXPANDED","true");
				Parent.AppendChild(child);
				System.Data.DataTable subchildTable ; 
				BusinessObjectCollection  subchild = new BusinessObjectCollection("Menu");
				subchild.SessionInstance = session ; 
				BusinessFilter filter = new BusinessFilter("Menu");
				filter.AddFilterItem("Parent",childpkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
				subchild.AddFilter(filter);
				/* Andy Modify 2007-04-26 Add Order By */
                subchild.Businessobject.OrderBy = "ORDER BY [DisplayOrder] ASC";
				subchildTable = subchild.GetDataTable();
				if (subchildTable.Rows.Count>0)
					GenerateElement(doc,child,subchildTable);
			}
		}
		#endregion
		

		#region 生成用户的配置信息到指定文件下
		public string GetMenuXML()
		{
			XmlElement root ;
			XmlDocument doc = GlobalFacade.XDom.GenXmlDocument("TREENODES",out root);
			BusinessObjectCollection MenuCollection = new BusinessObjectCollection("Menu");
			MenuCollection.SessionInstance = session ; 
			BusinessFilter filter = new BusinessFilter("Menu");
			filter.AddFilterItem("Parent","0",Operation.Equal,FilterType.NumberType,AndOr.AND);
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			MenuCollection.AddFilter(filter);

            MenuCollection.Businessobject.OrderBy = "ORDER BY [DisplayOrder] ASC";
			DataTable childtable = MenuCollection.GetDataTable();
			SaveElement(doc,root,childtable);
			return doc.OuterXml;
		}

		public string GetMenuXML(int roleid)
		{
			this.rolepkid = roleid;
			return GetMenuXML();
		}

		public void SaveMenuTreeXML(string path)
		{
			XmlElement root ;
			XmlDocument doc = GlobalFacade.XDom.GenXmlDocument("TREENODES",out root);
			BusinessObjectCollection MenuCollection = new BusinessObjectCollection("Menu");
			MenuCollection.SessionInstance = session ; 
			BusinessFilter filter = new BusinessFilter("Menu");
			filter.AddFilterItem("Parent","0",Operation.Equal,FilterType.NumberType,AndOr.AND);
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			MenuCollection.AddFilter(filter);
			/* Andy Modify 2007-04-26 Add Order By */
            MenuCollection.Businessobject.OrderBy = "ORDER BY [DisplayOrder] ASC";
			DataTable childtable = MenuCollection.GetDataTable();
			SaveElement(doc,root,childtable);
			if (!System.IO.Directory.Exists(path))
				System.IO.Directory.CreateDirectory(path);
			path = path + "\\" + this.rolepkid.ToString()+".xml";
			doc.Save(path);
		}

		private void SaveElement(XmlDocument doc ,XmlElement Parent,DataTable childtable)
		{
			for (int i = 0 ; i <childtable.Rows.Count ; i++)
			{
				int childpkid;
				string ChsName ; 
				string URL ;
				
				childpkid = (int)childtable.Rows[i]["PKID"];
				ChsName = (string)childtable.Rows[i]["ChineseName"];
				if (childtable.Rows[i]["URL"]!=null || childtable.Rows[i]["URL"].ToString() != "")
				{
					URL = childtable.Rows[i]["URL"].ToString();
				}
				else
					URL = "" ;
				RoleMenu checkmenu = new RoleMenu();
				checkmenu.SessionInstance = session ; 
				BusinessFilter checkfilter = new BusinessFilter("RoleMenu");
				checkfilter.AddFilterItem("FK_Menu",childpkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				checkfilter.AddFilterItem("FK_Role",this.rolepkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				checkfilter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
				checkmenu.AddFilter(checkfilter);
				checkmenu.Load();
				if (checkmenu.HaveRecord)
				{
					System.Xml.XmlElement child = GlobalFacade.XDom.CreateDocumentElement(doc,"TREENODE");
					GlobalFacade.XDom.SetNodeAttribute(doc,child,"TEXT",ChsName);
					GlobalFacade.XDom.SetNodeAttribute(doc,child,"NODEDATA",childpkid.ToString());
					GlobalFacade.XDom.SetNodeAttribute(doc,child,"EXPANDED","false");
					GlobalFacade.XDom.SetNodeAttribute(doc,child,"TARGET","main");
					GlobalFacade.XDom.SetNodeAttribute(doc,child,"NAVIGATEURL",URL);
					Parent.AppendChild(child);

					System.Data.DataTable subchildTable ; 
					BusinessObjectCollection  subchild = new BusinessObjectCollection("Menu");
					subchild.SessionInstance = session ; 
					BusinessFilter filter = new BusinessFilter("Menu");
					filter.AddFilterItem("Parent",childpkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
					filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
					subchild.AddFilter(filter);
					/* Andy Modify 2007-04-26 Add Order By */
                    subchild.Businessobject.OrderBy = "ORDER BY [DisplayOrder] ASC";
					subchildTable = subchild.GetDataTable();
					if (subchildTable.Rows.Count>0)
						SaveElement(doc,child,subchildTable);
				}
			}
		}

		#endregion

	}

	//用于保存菜单的选择信息到数据库中
	public class AjaxMenuRight
	{
		public AjaxMenuRight()
		{
				
		}
		[AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public void SaveConfig(string[] name,int rolepkid)
		{
			Session session = new Session();
			try
			{
				session.BeginTransaction();
				BusinessObjectCollection rolemenucollection = new BusinessObjectCollection("RoleMenu");
				rolemenucollection.SessionInstance = session ; 
				BusinessFilter filter = new BusinessFilter("RoleMenu");
				filter.AddFilterItem("FK_Role",rolepkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
				rolemenucollection.AddFilter(filter);
				rolemenucollection.DeleteFilter();
				for (int index = 0 ; index < name.Length ; index++)
				{
					RoleMenu rolemenu = new RoleMenu();
					rolemenu.SessionInstance = session ; 
					rolemenu.FK_Menu.Value = int.Parse(name[index].ToString());
					rolemenu.FK_Role.Value = rolepkid ;
					rolemenu.CreateUser.Value = GlobalFacade.SystemContext.GetContext().UserID;
					rolemenu.ModifyUser.Value = GlobalFacade.SystemContext.GetContext().UserID;
					rolemenu.CreateTime.Value = DateTime.Now;
					rolemenu.ModifyTime.Value = DateTime.Now;
					rolemenu.IsValid.Value = true; 
					rolemenu.Insert();
				}
				session.Commit();

				BusinessRule.SystemManage.OperationLog opLog = new BusinessRule.SystemManage.OperationLog();
				opLog.WriteOperationLog("界面权限管理", "配置界面权限");
			}
			catch
			{
				session.Rollback();
			}
		}
    }
}
