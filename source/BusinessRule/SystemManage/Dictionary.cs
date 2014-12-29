using System;
using System.Data;

using Wicresoft.BusinessObject;
using Wicresoft.Session;
using Microsoft.Web.UI.WebControls;


namespace BusinessRule.SystemManage
{
	/// <summary>
	/// Summary description for DictionaryRule.
	/// </summary>
	public class Dictionary
	{
		public Dictionary()
		{
			session = new Wicresoft.Session.Session();
		}
		private Wicresoft.Session.Session session ;

		private DictionaryType type;
		public DictionaryType Type
		{
			set
			{
				type = value;
			}
		}

		public void GenerateTree(Microsoft.Web.UI.WebControls.TreeView tr_region)
		{
			BusinessObjectCollection ParentCollection = new BusinessObjectCollection("Dictionary");
			ParentCollection.SessionInstance = session ; 

			BusinessFilter filter = new BusinessFilter("Dictionary");
			filter.AddFilterItem("Parent",Level.Top,Operation.Equal,FilterType.NumberType,AndOr.AND);
			filter.AddFilterItem("Type",Convert.ToString((int)type),Operation.Equal,FilterType.NumberType,AndOr.AND);
//			filter.AddFilterItem("Parent","0",Operation.Equal,FilterType.NumberType,AndOr.AND);
//			if (type == DictionaryType.Region)
//			{
//				filter.AddFilterItem("Type","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
//			}
//			else if (type == DictionaryType.Product)
//			{
//				filter.AddFilterItem("Type","2",Operation.Equal,FilterType.NumberType,AndOr.AND);
//			}
//			else 
//			{
//				filter.AddFilterItem("Type","3",Operation.Equal,FilterType.NumberType,AndOr.AND);
//			}

			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			ParentCollection.AddFilter(filter);

			DataTable parenttable = ParentCollection.GetDataTable();

			for (int i = 0 ; i<parenttable.Rows.Count ; i++)
			{
				Microsoft.Web.UI.WebControls.TreeNode node = new TreeNode();
				node.NodeData = parenttable.Rows[i]["PKID"].ToString();
				node.Text = parenttable.Rows[i]["Name"].ToString();
				node.ID = parenttable.Rows[i]["path"].ToString();
				tr_region.Nodes.Add(node);
				

				BusinessObjectCollection childCollection = new BusinessObjectCollection("Dictionary");
				childCollection.SessionInstance = session ; 
				BusinessFilter subfilter = new BusinessFilter("Dictionary");
				subfilter.AddFilterItem("Parent",parenttable.Rows[i]["PKID"].ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				
				subfilter.AddFilterItem("Type",Convert.ToString((int)type),Operation.Equal,FilterType.NumberType,AndOr.AND);
//				if (type == DictionaryType.Region)
//				{
//					subfilter.AddFilterItem("Type","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
//				}
//				else if (type == DictionaryType.Product)
//				{
//					subfilter.AddFilterItem("Type","2",Operation.Equal,FilterType.NumberType,AndOr.AND);
//				}
//				else 
//				{
//					subfilter.AddFilterItem("Type","3",Operation.Equal,FilterType.NumberType,AndOr.AND);
//				}
				subfilter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
				childCollection.AddFilter(subfilter);
				DataTable childtable = childCollection.GetDataTable();
				GenerateElement(node,childtable);
			}
		}


		
		private void GenerateElement(Microsoft.Web.UI.WebControls.TreeNode Parent,DataTable childtable)
		{
			
			for (int i = 0 ; i <childtable.Rows.Count ; i++)
			{
				int childpkid;
				string Name ; 
				string path ;
				childpkid = (int)childtable.Rows[i]["PKID"];
				Name = childtable.Rows[i]["Name"].ToString();
				path = childtable.Rows[i]["path"].ToString();
				Microsoft.Web.UI.WebControls.TreeNode node = new TreeNode();
				
				node.NodeData = childpkid.ToString();
				node.Text = Name;
				node.ID = path ;
				Parent.Nodes.Add(node);
				
				System.Data.DataTable subchildTable ; 
				BusinessObjectCollection subchild = new BusinessObjectCollection("Dictionary");
				subchild.SessionInstance = session ; 
				BusinessFilter filter = new BusinessFilter("Dictionary");
				filter.AddFilterItem("Parent",childpkid.ToString(),Operation.Equal,FilterType.NumberType,AndOr.AND);
				
				filter.AddFilterItem("Type",Convert.ToString((int)type),Operation.Equal,FilterType.NumberType,AndOr.AND);
//				if (type == DictionaryType.Region)
//				{
//					filter.AddFilterItem("Type","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
//				}
//				else if (type == DictionaryType.Product)
//				{
//					filter.AddFilterItem("Type","2",Operation.Equal,FilterType.NumberType,AndOr.AND);
//				}
//				else 
//				{
//					filter.AddFilterItem("Type","3",Operation.Equal,FilterType.NumberType,AndOr.AND);
//				}
				filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
				subchild.AddFilter(filter);

				subchildTable = subchild.GetDataTable();
				if (subchildTable.Rows.Count>0)
					GenerateElement(node,subchildTable);
			}
		}

		public string GetEntryNameById(string entryId)
		{
			BusinessFilter flt = new BusinessFilter("Dictionary");
			flt.AddFilterItem("PKID", entryId, Operation.Equal, FilterType.NumberType, AndOr.AND);

			BusinessMapping.Dictionary bo = new BusinessMapping.Dictionary();
			bo.SessionInstance = session;
			bo.AddFilter(flt);
			bo.Load();

			return (bo.HaveRecord)?bo.Name.Value:string.Empty;	
		}

		public string GetEntryLevelById(string entryId)
		{
			BusinessFilter flt = new BusinessFilter("Dictionary");
			flt.AddFilterItem("PKID", entryId, Operation.Equal, FilterType.NumberType, AndOr.AND);

			BusinessMapping.Dictionary bo = new BusinessMapping.Dictionary();
			bo.SessionInstance = session;
			bo.AddFilter(flt);
			bo.Load();

			return (bo.HaveRecord)?bo.Level.Value.ToString():string.Empty;	
		}


		public static string  GetSelectedNodeData(Microsoft.Web.UI.WebControls.TreeView tv,string index)
		{
			Microsoft.Web.UI.WebControls.TreeNode node ;
			node = tv.GetNodeFromIndex(index);
			return node.NodeData;
		}

		public static string GetSelectedText(Microsoft.Web.UI.WebControls.TreeView tv ,string index)
		{
			Microsoft.Web.UI.WebControls.TreeNode node ;
			node = tv.GetNodeFromIndex(index);
			return node.Text ; 
		}

		public static string GetSelectedPath(Microsoft.Web.UI.WebControls.TreeView tv ,string index)
		{
			Microsoft.Web.UI.WebControls.TreeNode node ;
			node = tv.GetNodeFromIndex(index);
			return node.ID;
		}
		
		
		
		public DataTable GetDictionaryList(out int totalCount, int pageSize, int pageIndex, 
			Common.OrderByType obType, BusinessFilter subfilter)
		{
//			//找出没有中心的城市PKID
//			string sql="select pkid from dictionaryAd where pkid in (select pkid from dictionaryAd where [name] not in (select [name] from dictionary where isvalid =1 and ([level]=1 or [level]=0)) and isvalid = 1 and ([level]=1 or [level]=0)) and ([level]=1 or [level]=0)";
//			Wicresoft.Session.Session session = new Wicresoft.Session.Session();
//			DataTable dt = session.SqlHelper.ExcuteDataTable(null,sql,CommandType.Text);
//			string NOPKIDs="";
//			for(int i=0;i<dt.Rows.Count;i++)
//			{
//				NOPKIDs+=","+dt.Rows[i][0];
//			}
//		
//			//找出当前用户所拥有权限的城市PKID
//			BusinessRule.BaseData.Region regionRule = new BusinessRule.BaseData.Region();
//		
//			string cityPKIDs = ","+regionRule.GetAuthorizedCitiesPKID(GlobalFacade.SystemContext.GetContext().UserID).ToString()+",";
//		
//			BusinessObjectCollection boc = new BusinessObjectCollection("ADClient");
//			boc.SessionInstance = session;
//			BusinessFilter filter = new BusinessFilter("ADClient");
//			
//			//找出是总部发布的PKID
//			string sqlADInfomation="select PKID from ADInfomation where FK_Center =1 and isvalid=1";
//			Wicresoft.Session.Session sessionADInfomation = new Wicresoft.Session.Session();
//			DataTable dtADInfomation=sessionADInfomation.SqlHelper.ExcuteDataTable(null,sqlADInfomation,CommandType.Text);
//			string ADInfomationPKID =  string.Empty;
//			if(dtADInfomation.Rows.Count>0)
//			{
//				for(int j=0;j<dtADInfomation.Rows.Count;j++)
//				{
//					ADInfomationPKID+=dtADInfomation.Rows[j][0]+",";
//				}
//				ADInfomationPKID=ADInfomationPKID.Substring(0,ADInfomationPKID.Length-1);
//			}
//			//防止ADInfomationPKID为空
//			if(ADInfomationPKID ==  string.Empty)
//			{
//				ADInfomationPKID = "0";
//			}
//			//有总部权限的
//			if(cityPKIDs.IndexOf(",2,")!=-1)
//			{
//				cityPKIDs=cityPKIDs.Substring(1,cityPKIDs.Length-2);
//				cityPKIDs+=",1";
//				if(NOPKIDs!=null&&NOPKIDs!=""&&NOPKIDs!=string.Empty)
//				{
//					cityPKIDs+=NOPKIDs;
//				}
//				//如果该用户是总部的 就能看到
//							/* Andy Modify 2009-03-08 */				
//				filter.AddCustomerFilter("(ADClient.FK_City IN(" + cityPKIDs + ") OR ADClient.FK_ADInfomation IN (" + ADInfomationPKID + ")) AND ADClient.FK_ADInfomation IN (" + regionRule.GetAuthorizedADInfomationPKID(GlobalFacade.SystemContext.GetContext().UserID) + ")", AndOr.AND);	
//			}
//			else
//			{
//				cityPKIDs=cityPKIDs.Substring(1,cityPKIDs.Length-2);
//				//如果该用户不是总部的 无法看到
//				/* Andy Modify 2009-03-08 */
//				filter.AddCustomerFilter("(ADClient.FK_City IN(" + cityPKIDs + ") AND ADClient.FK_ADInfomation not IN (" + ADInfomationPKID + ")) AND ADClient.FK_ADInfomation IN (" + regionRule.GetAuthorizedADInfomationPKID(GlobalFacade.SystemContext.GetContext().UserID) + ")", AndOr.AND);
//			}
//						//过滤城市
//			//filter.AddCustomerFilter("(ADClient.FK_City IN(" + cityPKIDs + ") OR ADClient.FK_City IN (" + cityPKIDs + "))", AndOr.AND);
//			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
//			
//			if (subfilter != null)
//				filter.AddFilter(subfilter,AndOr.AND);
//			boc.AddFilter(filter);
//			DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC)?true:false);
//			
//			totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
//			return ds.Tables[1];
			Wicresoft.Session.Session session = new Wicresoft.Session.Session();
			BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
			boc.SessionInstance = session;
			BusinessFilter filter = new BusinessFilter("Dictionary");
			filter.AddFilterItem("IsValid","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			filter.AddFilterItem("Level","1",Operation.Equal,FilterType.NumberType,AndOr.AND);
			if (subfilter != null)
				filter.AddFilter(subfilter,AndOr.AND);
			boc.AddFilter(filter);
			DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC)?true:false);
			
			totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
			return ds.Tables[1];
		}

        /// <summary>
        /// 获取城市名称
        /// </summary>
        /// <param name="pkid">城市PKID</param>
        /// <returns></returns>
        public string GetDictionaryName(string pkid)
        {
            string name = string.Empty;

            BusinessMapping.Dictionary bo = new BusinessMapping.Dictionary();
            bo.SessionInstance = new Wicresoft.Session.Session();

            BusinessFilter filter = new BusinessFilter("Dictionary");

            filter.AddFilterItem("PKID", pkid, Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            bo.AddFilter(filter);

            bo.Load();
            if (bo.HaveRecord)
            {
                name = bo.Name.Value;
            }

            return name;
        }

        /// <summary>
        /// 判断当前操作者所有权限的城市是否和传过来的城市是相同城市的
        /// </summary>
        /// <param name="strPKID">城市PKID</param>
        /// <returns></returns>
        public bool IsSameCity(string strPKID)
        {
            bool IsSameCity = false;
            string strCity = string.Empty;

            BusinessRule.BaseData.Region rule = new BusinessRule.BaseData.Region();
            DataTable dtCity = rule.GetAuthorizedCitiesAll(GlobalFacade.SystemContext.GetContext().UserID).GetDataTable();
            if (dtCity.Rows.Count > 0)
            {
                for (int i = 0; i < dtCity.Rows.Count; i++)
                {
                    strCity += "'" + dtCity.Rows[i]["PKID"].ToString() + "',";
                }

                if (strCity != string.Empty)
                    strCity = strCity.Substring(0, strCity.Length - 1);
            }

            if (strCity.IndexOf("'" + strPKID + "'") != -1)
                IsSameCity = true;

            return IsSameCity;
        }
	}
}
