using System;
using System.Data;

using Microsoft.Web.UI.WebControls;
using Wicresoft.BusinessObject;
using Wicresoft.Session;

namespace BusinessRule.BaseData
{
    /// <summary>
    /// Region 的摘要说明。
    /// </summary>
    public class Region
    {
        public Region()
        {
            dictionary = new SystemManage.Dictionary();
            dictionary.Type = SystemManage.DictionaryType.Region;
        }

        private SystemManage.Dictionary dictionary;
        public const string sp_GetUserDataPermissionOnCenter = "UDP_GetUserDataPermissionOnCenter @FK_User={0}";
        public const string sp_GetUserDataPermissionOnCity = "UDP_GetUserDataPermissionOnCity @FK_User={0}";
        public const string sp_GetUserDataPermissionOnCityAD = "UDP_GetUserDataPermissionOnCityAD @FK_User={0}";
        public const string sp_GetHaveDataPermissionCityOnUser = "UDP_GetHaveDataPermissionCityOnUser @FK_User={0}";
        public const string sp_GetHaveDataPermissionADTerraceOnUser = "UDP_GetHaveDataPermissionADTerraceOnUser @FK_User={0}";

        /// <summary>
        /// 选出所有城市
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="obType"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DataTable GetCityList(out int totalCount, int pageSize, int pageIndex, Common.OrderByType obType, BusinessFilter filter)
        {
            Common commonRule = new Common();

            BusinessFilter flt = new BusinessFilter("Dictionary");
            flt.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            flt.AddFilterItem("Type", ((int)SystemManage.DictionaryType.Region).ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            flt.AddFilterItem("Level", SystemManage.Level.City, Operation.Equal, FilterType.NumberType, AndOr.AND);

            flt.AddFilter(filter, AndOr.AND);

            // Add Data Permission
            //			flt.AddFilter(GetAuthorizedCityFilter(GlobalFacade.SystemContext.GetContext().UserID), AndOr.AND);

            BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
            boc.SessionInstance = new Session();
            boc.AddFilter(flt);

            DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC) ? true : false);
            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }
        //Qick新加方法
        public DataTable GetCityListAD(out int totalCount, int pageSize, int pageIndex, Common.OrderByType obType, BusinessFilter filter)
        {
            //获取没有中心的城市
            string sql = "select pkid from dictionaryAd where pkid in (select pkid from dictionaryAd where [name] not in (select [name] from dictionary where isvalid =1 and ([level]=1 or [level]=0)) and isvalid = 1 and ([level]=1 or [level]=0)) and ([level]=1 or [level]=0)";
            Wicresoft.Session.Session session = new Wicresoft.Session.Session();
            DataTable dt = session.SqlHelper.ExcuteDataTable(null, sql, CommandType.Text);
            string NOPKIDs = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NOPKIDs += "," + dt.Rows[i][0];
            }
            //获取登陆用户拥有权限的城市			
            /* Andy Modify 2009-12-17 用DictionaryAD表的PKID和FK_Dictionary过滤不同值 */
            BusinessRule.BaseData.Region regionRule = new BusinessRule.BaseData.Region();
            string cityPKIDs = regionRule.GetAuthorizedCitiesPKID(GlobalFacade.SystemContext.GetContext().UserID).ToString();
            if (cityPKIDs.IndexOf("2,") != -1)
                cityPKIDs += ",1";
            if (NOPKIDs != string.Empty)
                NOPKIDs = NOPKIDs.Substring(1, NOPKIDs.Length - 1);
            //			string cityPKIDs = ","+regionRule.GetAuthorizedCitiesPKID(GlobalFacade.SystemContext.GetContext().UserID).ToString()+",";
            //			if(cityPKIDs.IndexOf(",2,")!=-1)
            //			{
            //				cityPKIDs=cityPKIDs.Substring(1,cityPKIDs.Length-2);
            //				cityPKIDs+=",1";
            //				if(NOPKIDs!=null&&NOPKIDs!=""&&NOPKIDs!=string.Empty)
            //				{
            //					cityPKIDs+=NOPKIDs;
            //				}
            //			}
            //			else
            //			{
            //				cityPKIDs=cityPKIDs.Substring(1,cityPKIDs.Length-2);
            //			}

            Common commonRule = new Common();

            BusinessFilter flt = new BusinessFilter("DictionaryAD");
            flt.AddCustomerFilter("(DictionaryAD.PKID IN(" + NOPKIDs + ") OR DictionaryAD.FK_Dictionary IN (" + cityPKIDs + "))", AndOr.AND);
            //			flt.AddCustomerFilter("(DictionaryAD.PKID IN(" + cityPKIDs + ") OR DictionaryAD.PKID IN (" + cityPKIDs + "))", AndOr.AND);
            flt.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            flt.AddFilter(filter, AndOr.AND);

            // Add Data Permission
            //			flt.AddFilter(GetAuthorizedCityFilter(GlobalFacade.SystemContext.GetContext().UserID), AndOr.AND);

            BusinessObjectCollection boc = new BusinessObjectCollection("DictionaryAD");
            boc.SessionInstance = new Session();
            boc.AddFilter(flt);

            DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC) ? true : false);
            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }
        //Qick 获取城市列表 2009-02-06
        public DataTable GetCityListNew(out int totalCount, int pageSize, int pageIndex, Common.OrderByType obType, BusinessFilter filter)
        {
            Common commonRule = new Common();

            BusinessFilter flt = new BusinessFilter("DictionaryAD");
            flt.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);

            flt.AddCustomerFilter("(DictionaryAD.Level =1 OR DictionaryAD.Level =0)", AndOr.AND);
            flt.AddFilter(filter, AndOr.AND);

            BusinessObjectCollection boc = new BusinessObjectCollection("DictionaryAD");
            boc.SessionInstance = new Session();
            boc.AddFilter(flt);

            DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC) ? true : false);
            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }

        /* Jian.li Modify 2010-01-22 */
        public string GetCenterString()
        {
            //获取没有中心的城市
            string sql = "select pkid from dictionaryAd where isvalid = 1 and ([level]=1 or [level]=0)";
            Wicresoft.Session.Session session = new Wicresoft.Session.Session();
            DataTable dt = session.SqlHelper.ExcuteDataTable(null, sql, CommandType.Text);
            string NOPKIDs = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NOPKIDs += "," + dt.Rows[i][0];
            }
            if (NOPKIDs != string.Empty)
                NOPKIDs = NOPKIDs.Substring(1, NOPKIDs.Length - 1);

            return NOPKIDs;
        }

        //		/// <summary>
        //		/// 返回所有城市的对象集合
        //		/// </summary>
        //		/// <returns></returns>
        //		public BusinessObjectCollection GetAllCities()
        //		{
        //			BusinessFilter filter = new BusinessFilter("Dictionary");
        //			filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
        //			filter.AddFilterItem("Type", Convert.ToInt32(SystemManage.DictionaryType.Region).ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
        //			filter.AddFilterItem("Level", SystemManage.Level.City, Operation.Equal, FilterType.NumberType, AndOr.AND);
        //
        //			BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
        //			boc.SessionInstance = new Session();
        //			boc.AddFilter(filter);
        //			boc.Query();
        //			return boc;
        //		}



        /// <summary>
        /// 选出所有中心
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="obType"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DataTable GetCenterList(out int totalCount, int pageSize, int pageIndex, Common.OrderByType obType, BusinessFilter filter)
        {
            Common commonRule = new Common();

            BusinessFilter flt = new BusinessFilter("Dictionary");
            flt.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            flt.AddFilterItem("Level", SystemManage.Level.Center, Operation.Equal, FilterType.NumberType, AndOr.AND);

            flt.AddFilter(filter, AndOr.AND);

            // Add Data Permission
            //			flt.AddFilter(GetAuthorizedCenterFilter(GlobalFacade.SystemContext.GetContext().UserID), AndOr.AND);

            BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
            boc.SessionInstance = new Session();
            boc.AddFilter(flt);

            DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC) ? true : false);
            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }

        //		/// <summary>
        //		/// 返回所有中心的对象集合
        //		/// </summary>
        //		/// <returns></returns>
        //		public BusinessObjectCollection GetAllCenters()
        //		{
        //			BusinessFilter filter = new BusinessFilter("Dictionary");
        //			filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
        //			filter.AddFilterItem("Type", Convert.ToInt32(SystemManage.DictionaryType.Region).ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
        //			filter.AddFilterItem("Level", SystemManage.Level.Center, Operation.Equal, FilterType.NumberType, AndOr.AND);
        //
        //			BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
        //			boc.SessionInstance = new Session();
        //			boc.AddFilter(filter);
        //			boc.Query();
        //			return boc;
        //		}


        /// <summary>
        /// 获取用户具有权限的所有城市
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public BusinessObjectCollection GetAuthorizedCities(int userid)
        {
            BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
            boc.SessionInstance = new Wicresoft.Session.Session();
            boc.AddFilter(GetAuthorizedCityFilter(userid));
            boc.Query();

            return boc;
        }

        /// <summary>
        /// 获取用户具有权限的所有城市(包括中心级别用户)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public BusinessObjectCollection GetAuthorizedCitiesAll(int userid)
        {
            BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
            boc.SessionInstance = new Wicresoft.Session.Session();
            boc.AddFilter(GetAuthorizedCityFilterAll(userid));
            boc.Query();

            return boc;
        }

        /// <summary>
        /// 获取用户具有权限的所有中心
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public BusinessObjectCollection GetAuthorizedCenters(int userid)
        {
            BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
            boc.SessionInstance = new Wicresoft.Session.Session();
            boc.AddFilter(GetAuthorizedCenterFilter(userid));
            boc.Query();

            return boc;
        }

        /// <summary>
        /// 获取用户具有权限的城市过滤条件对象
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public BusinessFilter GetAuthorizedCityFilter(int userid)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();

            string sql = string.Format(sp_GetUserDataPermissionOnCity, userid);
            string citypkids = dal.ExecuteScalar(sql, CommandType.Text).ToString();

            BusinessFilter filter = new BusinessFilter("Dictionary");
            filter.AddCustomerFilter("Dictionary.PKID IN (" + citypkids + ")", AndOr.AND);

            return filter;
        }

        /// <summary>
        /// 推广--获取用户具有权限的城市过滤条件对象
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public BusinessFilter GetCityFilterByPromotion(int userid)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();
            BusinessFilter filter = new BusinessFilter("Dictionary");
            string sql = string.Format("select a.FK_Center,b.parent as CityID,b.name  from AssistantDataPermission  as a left join [Dictionary] as b on a.fk_center = b.pkid where a.fk_center <> -1 and a.fk_Assistant =" + userid);
            DataTable dt = dal.ExcuteDataTable(new DataTable(), sql, CommandType.Text);
            //if (temp != null && temp.Rows.Count != 0)
            //{
            //    filter.AddCustomerFilter("Dictionary.PKID IN (" + temp.Rows[0]["CityID"].ToString() + ")", AndOr.AND);
            //}
            string strCity = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["CityID"] != null && dt.Rows[i]["CityID"].ToString() != string.Empty)
                {
                    strCity += "," + dt.Rows[i]["CityID"].ToString();
                }
            }
            if (strCity != string.Empty)
            {
                strCity = strCity.Substring(1, strCity.Length - 1);
                filter.AddCustomerFilter("Dictionary.PKID IN (" + strCity + ")", AndOr.AND);
            }

            return filter;
        }

        /// <summary>
        /// 推广--获取用户具有权限的中心过滤条件对象
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public BusinessFilter GetCenterFilterByPromotion(string userid)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();
            BusinessFilter filter = new BusinessFilter("Dictionary");
            filter.AddCustomerFilter("Dictionary.PKID IN (" + GetCenterFilterByPromotion(int.Parse(userid)) + ")", AndOr.AND);
            return filter;
        }

        /// <summary>
        /// 推广--获取用户具有权限的中心过滤条件对象
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetCenterFilterByPromotion(int userid)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();
            string str = string.Empty;
            string sql = "select FK_Center  from AssistantDataPermission where fk_Assistant =  " + userid;
            DataTable temp = dal.ExcuteDataTable(new DataTable(), sql, CommandType.Text);
            if (temp != null && temp.Rows.Count != 0)
            {

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    str += temp.Rows[i]["FK_Center"].ToString() + ",";
                }
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }


        /// <summary>
        /// 获取用户具有权限的城市过滤条件对象(包括中心级别用户)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        /// <remarks>Andy Add 2008-03-06</remarks>
        public BusinessFilter GetAuthorizedCityFilterAll(int userid)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();

            string sql = string.Format(sp_GetHaveDataPermissionCityOnUser, userid);
            string citypkids = dal.ExecuteScalar(sql, CommandType.Text).ToString();

            BusinessFilter filter = new BusinessFilter("Dictionary");
            filter.AddCustomerFilter("Dictionary.PKID IN (" + citypkids + ")", AndOr.AND);

            return filter;
        }

        /// <summary>
        /// 获取用户具有权限的中心过滤条件对象
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public BusinessFilter GetAuthorizedCenterFilter(int userid)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();

            string sql = string.Format(sp_GetUserDataPermissionOnCenter, userid);
            string centerpkids = dal.ExecuteScalar(sql, CommandType.Text).ToString();

            BusinessFilter filter = new BusinessFilter("Dictionary");
            filter.AddCustomerFilter("Dictionary.PKID IN (" + centerpkids + ")", AndOr.AND);

            return filter;
        }


        public string GetAuthorizedCitiesPKID(int userid)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();

            string sql = string.Format(sp_GetUserDataPermissionOnCity, userid);
            return dal.ExecuteScalar(sql, CommandType.Text).ToString();
        }

        /* Andy Modify 2009-03-08 */
        public string GetAuthorizedADTerracePKID(int userid)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();

            string sql = string.Format(sp_GetHaveDataPermissionADTerraceOnUser, userid);
            return dal.ExecuteScalar(sql, CommandType.Text).ToString();
        }

        /// <summary>
        /// 根据当前用户，得到该用户拥有的中心权限
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>返回值20,21,22</returns>
        public string GetAuthorizedCentersPKID(int userid)
        {
            Wicresoft.Session.Session session = new Session();
            string sql = string.Format(sp_GetUserDataPermissionOnCenter, userid);
            return session.SqlHelper.ExecuteScalar(sql, CommandType.Text).ToString();
        }

        public DataTable GetRegionList(out int totalCount, int pageSize, int pageIndex, Common.OrderByType obType, BusinessFilter subfilter, string Parent)
        {
            Wicresoft.Session.Session session = new Wicresoft.Session.Session();
            BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary");
            BusinessFilter filter = new BusinessFilter("Dictionary");
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("Type", ((int)SystemManage.DictionaryType.Region).ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            if (Parent == SystemManage.Level.Top)
            {
                BusinessMapping.Dictionary TopParent = new BusinessMapping.Dictionary();
                TopParent.SessionInstance = session;
                BusinessFilter searchparent = new BusinessFilter("Dictionary");
                searchparent.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
                searchparent.AddFilterItem("Type", ((int)SystemManage.DictionaryType.Region).ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
                searchparent.AddFilterItem("Parent", SystemManage.Level.Top, Operation.Equal, FilterType.NumberType, AndOr.AND);
                TopParent.AddFilter(searchparent);
                TopParent.Load();
                if (TopParent.HaveRecord)
                    Parent = TopParent.PKID.Value.ToString();
            }

            if (!(Parent == null || Parent.Equals(string.Empty)))
                filter.AddFilterItem("Parent", Parent.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);

            if (subfilter != null)
            {
                filter.AddFilter(subfilter, AndOr.AND);
            }
            boc.SessionInstance = session;
            boc.AddFilter(filter);
            DataSet ds = boc.GetPagedRecords(pageIndex, pageSize, "PKID", (obType == Common.OrderByType.ASC) ? true : false);

            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }


        public string GetRoot()
        {
            BusinessFilter filter = new BusinessFilter("Dictionary");
            filter.AddFilterItem("Type", ((int)SystemManage.DictionaryType.Region).ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("Parent", SystemManage.Level.Top, Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);

            BusinessMapping.Dictionary rootregion = new BusinessMapping.Dictionary();
            rootregion.AddFilter(filter);
            rootregion.SessionInstance = new Session();
            rootregion.Load();

            return (rootregion.HaveRecord) ? rootregion.PKID.Value.ToString() : SystemManage.Level.Top;
        }

        public bool IsRegionExclusive(string fieldName, string fieldValue, bool stringField, int FK_Dictionary)
        {
            BusinessFilter filter = new BusinessFilter("Dictionary_RegionDetail");
            filter.AddFilterItem("FK_Dictionary", FK_Dictionary.ToString(), Operation.NotEqual, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem(fieldName, fieldValue, Operation.Equal, stringField ? FilterType.StringType : FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);

            BusinessObjectCollection boc = new BusinessObjectCollection("Dictionary_RegionDetail");
            boc.SessionInstance = new Wicresoft.Session.Session();
            boc.AddFilter(filter);
            boc.Query();

            return (boc.Count > 0) ? false : true;
        }

        #region 生成树
        public void GenerateRegionTree(Microsoft.Web.UI.WebControls.TreeView tr_region)
        {
            tr_region.Nodes.Clear();
            dictionary.GenerateTree(tr_region);
        }
        #endregion


        #region Delete Region
        public bool DeleteAllNode(int PKID)
        {
            Wicresoft.Session.Session session = new Session();
            try
            {
                DeleteNode(PKID, session);
                session.Commit();
                return true;
            }
            catch
            {
                session.Rollback();
                return false;
            }
        }


        private void DeleteNode(int Dictionary_PKID, Wicresoft.Session.Session session)
        {
            // Delete the entry in Dictionary
            BusinessMapping.Dictionary owner = new BusinessMapping.Dictionary();
            owner.SessionInstance = session;
            owner.PKID.Value = Dictionary_PKID;
            owner.IsValid.Value = false;
            owner.Update();

            // Delete the entry in Dictionary_RegionDetail
            BusinessObjectCollection region = new BusinessObjectCollection("Dictionary_RegionDetail");
            region.SessionInstance = session;

            BusinessFilter regiondeletefilter = new BusinessFilter("Dictionary_RegionDetail");
            regiondeletefilter.AddFilterItem("FK_Dictionary", Dictionary_PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            region.AddFilter(regiondeletefilter);

            ((BusinessMapping.Dictionary_RegionDetail)region.Businessobject).IsValid.Value = false;
            region.UpdateFilter();


            // Delete any child entries
            BusinessObjectCollection child = new BusinessObjectCollection("Dictionary");
            child.SessionInstance = session;

            BusinessFilter filter = new BusinessFilter("Dictionary");
            filter.AddFilterItem("Parent", Dictionary_PKID.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("Type", ((int)SystemManage.DictionaryType.Region).ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            child.AddFilter(filter);

            DataTable childtable = child.GetDataTable();

            for (int i = 0; i < childtable.Rows.Count; i++)
            {
                DeleteNode(int.Parse(childtable.Rows[i]["PKID"].ToString()), session);
            }
        }
        #endregion


    }
}
