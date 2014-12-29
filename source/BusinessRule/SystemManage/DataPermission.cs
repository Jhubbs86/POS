using System;
using System.Xml;
using System.Data;

using Wicresoft.Session;
using Wicresoft.BusinessObject;
using BusinessMapping;
using GlobalFacade ;

using AjaxPro ;

namespace BusinessRule.SystemManage
{
	/// <summary>
	/// Summary description for SysDataRight.
	/// </summary>
	public class DataPermission
	{
		public DataPermission()
		{
			session = new Session();
		}

		private Wicresoft.Session.Session session ;
		public void SetSession(Session _session)
		{
			session = _session;
		}

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

		private string outregionxml ; 
		public string OutRegionXML
		{
			get
			{
				return outregionxml;
			}
		}


		#region RegionTree

		public void GenerateRegionTreeXML()
		{
			XmlElement root ;
			XmlDocument doc = GlobalFacade.XDom.GenXmlDocument("TREENODES",out root);
			BusinessObjectCollection RegionCollection = new BusinessObjectCollection("Dictionary");
			RegionCollection.SessionInstance = session ; 

			BusinessFilter filter = new BusinessFilter("Dictionary");
			filter.AddFilterItem("Parent","0",Operation.Equal,FilterType.NumberType,AndOr.AND);
			filter.AddFilterItem("Type",Convert.ToString((int)DictionaryType.Region),Operation.Equal,FilterType.NumberType,AndOr.AND);
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			RegionCollection.AddFilter(filter);

			DataTable childtable = RegionCollection.GetDataTable();
			GenerateRegionElement(doc,root,childtable);
			this.outregionxml = doc.OuterXml;
		}

		private void GenerateRegionElement(XmlDocument doc ,XmlElement Parent,DataTable childtable)
		{
			for (int i = 0 ; i <childtable.Rows.Count ; i++)
			{
				int childpkid;
				string Name ; 
				childpkid = (int)childtable.Rows[i]["PKID"];
				Name = (string)childtable.Rows[i]["Name"];
				System.Xml.XmlElement child = GlobalFacade.XDom.CreateDocumentElement(doc,"TREENODE");
				RoleDataPermission HaveRegion = new RoleDataPermission();
				HaveRegion.SessionInstance = session ; 
				BusinessFilter checkfilter = new BusinessFilter("RoleDataPermission");
				checkfilter.AddFilterItem("Type",Convert.ToString((int)DictionaryType.Region),Operation.Equal,FilterType.NumberType,AndOr.AND);
				checkfilter.AddFilterItem("FK_Role",this.RolePKID.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				checkfilter.AddFilterItem("FK_Dictionary",childpkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				HaveRegion.AddFilter(checkfilter);
				HaveRegion.Load();
				if (HaveRegion.HaveRecord)
				{
					GlobalFacade.XDom.SetNodeAttribute(doc,child,"checked","True");
				}
				GlobalFacade.XDom.SetNodeAttribute(doc,child,"checkBox","True");
				GlobalFacade.XDom.SetNodeAttribute(doc,child,"Expanded","True");
				GlobalFacade.XDom.SetNodeAttribute(doc,child,"Text",Name);
				GlobalFacade.XDom.SetNodeAttribute(doc,child,"NodeData",childpkid.ToString());
				Parent.AppendChild(child);
				System.Data.DataTable subchildTable ; 
				BusinessObjectCollection  subchild = new BusinessObjectCollection("Dictionary");
				subchild.SessionInstance = session ; 
				BusinessFilter filter = new BusinessFilter("Dictionary");
				filter.AddFilterItem("Parent",childpkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				filter.AddFilterItem("Type",Convert.ToString((int)DictionaryType.Region),Operation.Equal,FilterType.NumberType,AndOr.AND);
				filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
				subchild.AddFilter(filter);
				subchildTable = subchild.GetDataTable();
				if (subchildTable.Rows.Count>0)
					GenerateRegionElement(doc,child,subchildTable);
			}
		}
		#endregion


//		#region  RegionSave
//		public void SaveAllRegionNodes(Microsoft.Web.UI.WebControls.TreeView menutree)
//		{
//			foreach (Microsoft.Web.UI.WebControls.TreeNode node in menutree.Nodes)
//			{
//				SaveRegionNode(node);
//			}
//		}
//
//		private void SaveRegionNode(Microsoft.Web.UI.WebControls.TreeNode parent)
//		{
//			if (parent.Checked)
//			{
//				RoleDataPermission regionright = new RoleDataPermission();
//				Session session = new Session();
//				regionright.SessionInstance = session ; 
//				regionright.FK_Role.Value = this.RolePKID;
//				regionright.Type.Value = (int)DictionaryType.Region;
//				regionright.FK_Dictionary.Value = int.Parse(parent.NodeData);
//				regionright.Insert();
//			}
//			
//			foreach(Microsoft.Web.UI.WebControls.TreeNode child in parent.Nodes)
//			{
//				SaveRegionNode(child);
//			}
//		}
//		#endregion
	}

	public class AjaxRegionRight
	{
		
		[AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
		public void SaveRegionConfig(string[] name,int rolepkid)
		{
			Session session = new Session();
			try
			{
				session.BeginTransaction();
				BusinessObjectCollection regioncollection = new BusinessObjectCollection("RoleDataPermission");
				regioncollection.SessionInstance = session ; 
				BusinessFilter filter = new BusinessFilter("RoleDataPermission");
				filter.AddFilterItem("FK_Role",rolepkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				filter.AddFilterItem("Type",Convert.ToString((int)DictionaryType.Region),Operation.Equal,FilterType.NumberType,AndOr.AND);
				regioncollection.AddFilter(filter);
				regioncollection.DeleteFilter();

				for (int index = 0 ; index < name.Length ; index++)
				{
					BusinessMapping.RoleDataPermission regionright = new RoleDataPermission();
					regionright.SessionInstance = session ; 
					regionright.FK_Role.Value = rolepkid;
					regionright.Type.Value = 1;
					regionright.FK_Dictionary.Value = int.Parse(name[index].ToString());
					regionright.CreateUser.Value  = SystemContext.GetContext().UserID;
					regionright.ModifyUser.Value  = SystemContext.GetContext().UserID;
					regionright.CreateTime.Value = regionright.ModifyTime.Value = DateTime.Now;
					regionright.Insert();
				}
				session.Commit();

				OperationLog opLog = new OperationLog();
				opLog.WriteOperationLog("数据权限管理", "配置数据权限");
			}
			catch
			{
				session.Rollback();
			}
		}
	}
}
