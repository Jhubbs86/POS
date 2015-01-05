using System;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

using Wicresoft.BusinessObject;

namespace BusinessRule
{
    /// <summary>
    /// Summary description for Common.
    /// </summary>
    public class Common
    {
        public enum OrderByType
        {
            ASC = 0,
            DESC = 1
        }
        public const string sp_GetPagedRecords = "exec GetPagedRecords @tblName='{0}',@PageSize={1},@doCount=1,@PageIndex={2},@fldName='{3}',@strGetFields='{4}',@OrderType='{5}',@strWhere='{6}',@strJoin='{7}'";
        //		public const string sp_GetAuthorizedDictionaryEntries = "UDP_GetAuthorizedDictionaryEntries @FK_User={0},@FK_DictionaryType={1},@Level={2}";


        public const string sp_GetPagedRecords_withCustomOrder = "exec GetPagedRecords @tblName='{0}',@PageSize={1},@doCount=1,@PageIndex={2},@fldName='{3}',@strGetFields='{4}',@strWhere='{6}',@strJoin='{7}',@finalOrder='{5}',@OrderType={8}";

        public DataTable GetPagedRecords(out int totalCount, string tblName, int pageSize, int pageIndex, string idColumn, string fieldList, OrderByType obType, string strWhere, string strJoin)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();

            string sql = string.Format(sp_GetPagedRecords, tblName, pageSize, pageIndex, idColumn, fieldList, (int)obType, strWhere.Replace("'", "''"), strJoin);
            DataSet ds = dal.ExecuteDataSet(sql, CommandType.Text);
            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }

        public DataTable GetPagedRecordsNew(out int totalCount, string tblName, int pageSize, int pageIndex, string idColumn, string fieldList, OrderByType obType, string strWhere, string strJoin)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();

            string sql = string.Format(sp_GetPagedRecords, tblName, pageSize, pageIndex, idColumn, fieldList, (int)obType, strWhere.Replace("'", "''"), strJoin);
            DataSet ds = dal.ExecuteDataSet(sql, CommandType.Text);
            try { totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]); }
            catch { totalCount = 0; }
            return ds.Tables[1];
        }

        public DataTable GetPagedRecords(out int totalCount, string tblName, int pageSize, int pageIndex, string idColumn, string fieldList, OrderByType obType, string strOrderBy, string strWhere, string strJoin)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();

            string sql = string.Format(sp_GetPagedRecords_withCustomOrder, tblName, pageSize, pageIndex, idColumn, fieldList, strOrderBy, strWhere.Replace("'", "''"), strJoin, (int)obType);
            DataSet ds = dal.ExecuteDataSet(sql, CommandType.Text);
            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }

        public const string sp_GetPagedRecords_withCustomOrder_New = "exec GetPagedRecords_New @tblName='{0}',@PageSize={1},@doCount=1,@PageIndex={2},@fldName='{3}',@strGetFields='{4}',@strWhere='{6}',@strJoin='{7}',@finalOrder='{5}',@OrderType={8},@strJoin1='{9}',@strGetFields1='{10}'";

        public DataTable GetPagedRecords_New(out int totalCount, string tblName, int pageSize, int pageIndex, string idColumn, string fieldList, OrderByType obType, string strOrderBy, string strWhere, string strJoin, string strJoin1, string fieldList1)
        {
            Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();

            string sql = string.Format(sp_GetPagedRecords_withCustomOrder_New, tblName, pageSize, pageIndex, idColumn, fieldList, strOrderBy, strWhere.Replace("'", "''"), strJoin, (int)obType, @strJoin1, fieldList1);
            DataSet ds = dal.ExecuteDataSet(sql, CommandType.Text);
            totalCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return ds.Tables[1];
        }

        //		public string GetAuthorizedDictionaryEntries(int userid, SystemManage.DictionaryType type, string level)
        //		{
        //			Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();
        //
        //			string sql = string.Format(sp_GetAuthorizedDictionaryEntries, userid, Convert.ToInt32(type), level);
        //			return dal.ExecuteScalar(sql, CommandType.Text).ToString();
        //		}
        /// <summary>
        /// allen 验证是否是float类型
        /// </summary>
        /// <param name="inputtext"></param>
        /// <returns></returns>
        public bool ValidateFloatStyle(string inputtext)
        {
            bool IsValid = false;
            System.Text.RegularExpressions.Regex ValidateFloat = new System.Text.RegularExpressions.Regex(@"^(-?\d+)(\.\d+)?$");//^[1-9]{1}[0-9/.]{0,}$   "^(0|[1-9]\d*)(\.\d+)?$"
            IsValid = (ValidateFloat.IsMatch(inputtext, 0)) ? true : false;
            return IsValid;
        }

        public bool IsFieldExclusive(string fieldName, string fieldValue, string ObjectName, bool stringField, int objectPKID)
        {
            BusinessFilter filter = new BusinessFilter(ObjectName);
            filter.AddFilterItem("PKID", objectPKID.ToString(), Operation.NotEqual, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem(fieldName, fieldValue, Operation.Equal, stringField ? FilterType.StringType : FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);

            BusinessObjectCollection boc = new BusinessObjectCollection(ObjectName);
            boc.SessionInstance = new Wicresoft.Session.Session();
            boc.AddFilter(filter);
            boc.Query();

            return (boc.Count > 0) ? false : true;
        }

        public void UpDateDataTimeColumn(string strtblName, string strPKID, string strColumnName)
        {
            string sqlUpDateDataTimeColumn = "UPDATE " + strtblName + " SET " + strColumnName + " = NULL " + " WHERE PKID = " + strPKID;
            //			Wicresoft.DataAccess.SQLServer dal = new Wicresoft.DataAccess.SQLServer();
            //			dal.ExecuteNonQuery(sqlUpDateDataTimeColumn, CommandType.Text);

            string conString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlUpDateDataTimeColumn, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //		public bool CheckObjectReference(BusinessObject bo)
        //		{
        //			if(bo == null || !bo.HaveRecord)
        //				throw new NullReferenceException("Invalid Object!");
        //			else
        //			{
        //				FieldInfo fi = bo.GetType().GetField("PKID");
        //				Field field = fi.GetValue(bo) as Field;
        //
        //				int pkid = field.GetType().GetProperty("Value").GetValue(field,null);
        //
        //				FieldInfo[] fields = bo.GetType().GetFields();
        //				for(int i = 0; i < fields.Length; i++)
        //				{
        //					ForeignKeyAttribute[] fkAttr = fields[i].GetCustomAttributes(typeof(ForeignKeyAttribute), false) as ForeignKeyAttribute[];
        //					if(fkAttr != null)
        //					{
        //						for(int j = 0; j < fkAttr.Length; j++)
        //						{
        //							BusinessFilter filter = new BusinessFilter(fkAttr[j].TableName);
        //							filter.AddFilterItem("PKID", )
        //
        //							BusinessObjectCollection boc = new BusinessObjectCollection(fkAttr[j].TableName);
        //							boc.SessionInstance = new Wicresoft.Session.Session();
        //							
        //						}
        //					}
        //				}
        //			}
        //		}

        /// <summary>
        /// 验证大于零的整数格式
        /// </summary>
        /// <param name="inputtext">接收需要验证的文本</param>
        /// <paramref name="IsValid">返回验证是否通过</paramref>
        /// <remarks></remarks>
        public static bool ValidateIntegerStyle(string inputtext)
        {
            bool IsValid = false;
            System.Text.RegularExpressions.Regex ValidateInteger = new System.Text.RegularExpressions.Regex("^^[1-9][0-9]*$");
            IsValid = (ValidateInteger.IsMatch(inputtext, 0)) ? true : false;
            return IsValid;
        }

        public static bool ValidateIntegerStyleM(string inputtext)
        {
            bool IsValid = false;
            System.Text.RegularExpressions.Regex ValidateInteger = new System.Text.RegularExpressions.Regex("^[1-9]*[0-9]*$");
            IsValid = (ValidateInteger.IsMatch(inputtext, 0)) ? true : false;
            return IsValid;
        }
    }
}
