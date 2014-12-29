using System;
using System.Collections;
using System.Reflection;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for AssemblyObject.
	/// </summary>
	public class AssemblyBusinessObject
	{
		
		

		private static string InvokeMethod(BusinessObject BO , System.Reflection.FieldInfo fieldInfo , string methodName)
		{
			string FieldName;
			/*获得该字段的数据字段的名称*/
			Field _Field =(Field) fieldInfo.GetValue(BO);
			System.Reflection.MethodInfo _Method = _Field.GetType().GetMethod(methodName);
			FieldName = (string)_Method.Invoke(_Field,null);
			return FieldName;
		}

		
		#region GetSelectSQL
		public static string  GetSelectSQL(BusinessObject BO)
		{
			string primaryTable;
			string sql;
			string orderby ;
			System.Text.StringBuilder select = new System.Text.StringBuilder();
			System.Text.StringBuilder from = new System.Text.StringBuilder();
			System.Text.StringBuilder where = new System.Text.StringBuilder();
			System.Text.StringBuilder join = new System.Text.StringBuilder();
			
			primaryTable = BO.TableName;
			select.Append(" SELECT  ");
			from.Append(" FROM  " + primaryTable);
			where.Append(" WHERE 1 = 1 ");
			orderby = BO.OrderBy;
			System.Reflection.FieldInfo[] fieldInfo = BO.GetType().GetFields();
			for(int i = 0; i < fieldInfo.Length; i++)
			{
				System.Attribute[] attribute = System.Attribute.GetCustomAttributes(fieldInfo[i]);
				
				//处理有外键的情况
				if (attribute.Length>0)
				{
					string ForeignFactTable			= string.Empty;
					string ForeignMapTable			= string.Empty;

					string ForeignDisplayField		= string.Empty;
					string ForeignKeyField			= string.Empty;
					string ForeignMapField			= string.Empty;

					int into  =0  ;
					int first = 0 ;
					for( int j = 0 ;j <attribute.Length ; j++)
					{
						if (attribute[j].ToString() == "Wicresoft.BusinessObject.ForeignKeyAttribute")
						{
							into = 1;
							if (first == 0)
							{
								ForeignKeyAttribute foreignKeyAttribute = (ForeignKeyAttribute)attribute[j];
								ForeignFactTable = foreignKeyAttribute.TableName;
								ForeignMapTable = fieldInfo[i].Name;

								ForeignKeyField = foreignKeyAttribute.PKID;
								ForeignDisplayField = foreignKeyAttribute.DisplayName;
								ForeignMapField = foreignKeyAttribute.MappingName;


								select.Append(ForeignMapTable + "." + ForeignKeyField + " AS  " +  fieldInfo[i].Name + ",");
								//2005-10-13，Tony，修改外键AS的名称
								select.Append(ForeignMapTable + "." + ForeignDisplayField +" AS " + ForeignMapField + ",");
//								
//								//2005-10-13，Tony，添加条件：!foreignTableList.Contains(foreignTableName)
//								if (!from.Equals(string.Empty))
//								{
//									from.Append(" , " + ForeignFactTable+" AS " + ForeignMapTable); 
//								}
//								where.Append(" AND " + primaryTable + "." + InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " = " + ForeignMapTable + "." + ForeignKeyField);
								
								join.AppendFormat(" LEFT JOIN {0} AS {1} ON {1}.{2} = {3}.{4} ", ForeignFactTable, ForeignMapTable, ForeignKeyField, primaryTable, InvokeMethod(BO,fieldInfo[i],"GetFieldName"));
								first = 1;
							}
							else
							{
								ForeignKeyAttribute foreignKeyAttribute = (ForeignKeyAttribute)attribute[j];
								ForeignFactTable = foreignKeyAttribute.TableName;
								ForeignMapTable = fieldInfo[i].Name;
								ForeignDisplayField = foreignKeyAttribute.DisplayName;
								ForeignMapField = foreignKeyAttribute.MappingName;
								select.Append(ForeignMapTable + "." + ForeignDisplayField +" AS " + ForeignMapField + ",");
							}
						}
					}
					if (into == 0)
						select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
				}
				else
					select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
			}
			if (!BO.Where.Equals(string.Empty))
				where.Append(" " + BO.Where); 
			sql = select.ToString().Substring(0,select.ToString().Length - 1) + " " + from.ToString() +" " + join.ToString() + " " + where.ToString() + orderby ;
			select.Remove(0,select.Length);
			from.Remove(0,from.Length);
			where.Remove(0,where.Length);
			join.Remove(0, join.Length);
			return sql;
		}


//		public static string  GetSelectSQL(BusinessObject BO)
//		{
//			string primaryTable;
//			string sql;
//			string orderby ;
//			System.Text.StringBuilder select = new System.Text.StringBuilder();
//			System.Text.StringBuilder from = new System.Text.StringBuilder();
//			System.Text.StringBuilder where = new System.Text.StringBuilder();
//			
//			primaryTable = BO.TableName;
//			select.Append(" SELECT  ");
//			from.Append(" FROM  " + primaryTable);
//			where.Append(" WHERE 1 = 1 ");
//			orderby = BO.OrderBy;
//			System.Reflection.FieldInfo[] fieldInfo = BO.GetType().GetFields();
//			for(int i = 0; i < fieldInfo.Length; i++)
//			{
//				System.Attribute[] attribute = System.Attribute.GetCustomAttributes(fieldInfo[i]);
//				
//				//处理有外键的情况
//				if (attribute.Length>0)
//				{
//					string ForeignFactTable			= string.Empty;
//					string ForeignMapTable			= string.Empty;
//
//					string ForeignDisplayField		= string.Empty;
//					string ForeignKeyField			= string.Empty;
//					string ForeignMapField			= string.Empty;
//
//					int into  =0  ;
//					int first = 0 ;
//					for( int j = 0 ;j <attribute.Length ; j++)
//					{
//						if (attribute[j].ToString() == "Wicresoft.BusinessObject.ForeignKeyAttribute")
//						{
//							into = 1;
//							if (first == 0)
//							{
//								ForeignKeyAttribute foreignKeyAttribute = (ForeignKeyAttribute)attribute[j];
//								ForeignFactTable = foreignKeyAttribute.TableName;
//								ForeignMapTable = fieldInfo[i].Name;
//
//								ForeignKeyField = foreignKeyAttribute.PKID;
//								ForeignDisplayField = foreignKeyAttribute.DisplayName;
//								ForeignMapField = foreignKeyAttribute.MappingName;
//
//
//								select.Append(ForeignMapTable + "." + ForeignKeyField + " AS  " +  fieldInfo[i].Name + ",");
//								//2005-10-13，Tony，修改外键AS的名称
//								select.Append(ForeignMapTable + "." + ForeignDisplayField +" AS " + ForeignMapField + ",");
//								
//								//2005-10-13，Tony，添加条件：!foreignTableList.Contains(foreignTableName)
//								if (!from.Equals(string.Empty))
//								{
//									from.Append(" , " + ForeignFactTable+" AS " + ForeignMapTable); 
//								}
//								where.Append(" AND " + primaryTable + "." + InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " = " + ForeignMapTable + "." + ForeignKeyField);
//								first = 1;
//							}
//							else
//							{
//								ForeignKeyAttribute foreignKeyAttribute = (ForeignKeyAttribute)attribute[j];
//								ForeignFactTable = foreignKeyAttribute.TableName;
//								ForeignMapTable = fieldInfo[i].Name;
//								ForeignDisplayField = foreignKeyAttribute.DisplayName;
//								ForeignMapField = foreignKeyAttribute.MappingName;
//								select.Append(ForeignMapTable + "." + ForeignDisplayField +" AS " + ForeignMapField + ",");
//							}
//						}
//					}
//					if (into == 0)
//						select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
//				}
//				else
//					select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
//			}
//			if (!BO.Where.Equals(string.Empty))
//				where.Append(" " + BO.Where); 
//			sql = select.ToString().Substring(0,select.ToString().Length - 1) + " " + from.ToString() +" " + where.ToString() + orderby ;
//			select.Remove(0,select.Length);
//			from.Remove(0,from.Length);
//			where.Remove(0,where.Length);
//			return sql;
//		}

		/// <summary>
		/// 获取带分页功能的SQL
		/// </summary>
		/// <param name="BO"></param>
		/// <param name="pageNumber">页码（1开始）</param>
		/// <param name="pageSize">页大小</param>
		/// <param name="idColumnName">PKID列名</param>
		/// <param name="asc">升序 或 降序</param>
		/// <returns></returns>
		public static string  GetPagingSelectSQL(BusinessObject BO, int pageNumber, int pageSize, string idColumnName, bool asc)
		{
			/*
			select top 20 *  
			from [SysUser] 
			where [PKID] > (
			select max([PKID]) 
			from (	select top 20 [PKID] 
				from [SysUser] 
				order by [PKID] asc) as tblTmp) 
			order by [PKID] asc
			*/

			string sqlPrefix;
			string primaryTable;
			string sql;
			string orderby ;
			System.Text.StringBuilder select = new System.Text.StringBuilder();
			System.Text.StringBuilder from = new System.Text.StringBuilder();
			System.Text.StringBuilder where = new System.Text.StringBuilder();
			System.Text.StringBuilder join = new System.Text.StringBuilder();

			primaryTable = BO.TableName;
			//			select.AppendFormat(" SELECT TOP {0} ", pageSize*(pageNumber-1));
			from.Append(" FROM  " + primaryTable);
			where.Append(" WHERE 1 = 1 ");
			orderby = BO.OrderBy;
			System.Reflection.FieldInfo[] fieldInfo = BO.GetType().GetFields();
			for(int i = 0; i < fieldInfo.Length; i++)
			{
				System.Attribute[] attribute = System.Attribute.GetCustomAttributes(fieldInfo[i]);
				
				//处理有外键的情况
				if (attribute.Length>0)
				{
					string ForeignFactTable			= string.Empty;
					string ForeignMapTable			= string.Empty;

					string ForeignDisplayField		= string.Empty;
					string ForeignKeyField			= string.Empty;
					string ForeignMapField			= string.Empty;

					int into  =0  ;
					int first = 0;
					for( int j = 0 ;j <attribute.Length ; j++)
					{
						if (attribute[j].ToString() == "Wicresoft.BusinessObject.ForeignKeyAttribute")
						{
							into = 1;
							if (first == 0)
							{
								ForeignKeyAttribute foreignKeyAttribute = (ForeignKeyAttribute)attribute[j];
								ForeignFactTable = foreignKeyAttribute.TableName;
								ForeignMapTable = fieldInfo[i].Name;

								ForeignKeyField = foreignKeyAttribute.PKID;
								ForeignDisplayField = foreignKeyAttribute.DisplayName;
								ForeignMapField = foreignKeyAttribute.MappingName;


								select.Append(ForeignMapTable + "." + ForeignKeyField + " AS  " +  fieldInfo[i].Name + ",");
								//2005-10-13，Tony，修改外键AS的名称
								select.Append(ForeignMapTable + "." + ForeignDisplayField +" AS " + ForeignMapField + ",");
								
//								//2005-10-13，Tony，添加条件：!foreignTableList.Contains(foreignTableName)
//								if (!from.Equals(string.Empty))
//								{
//									from.Append(" , " + ForeignFactTable+" AS " + ForeignMapTable); 
//								}
//								where.Append(" AND " + primaryTable + "." + InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " = " + ForeignMapTable + "." + ForeignKeyField);
								
								join.AppendFormat(" LEFT JOIN {0} AS {1} ON {1}.{2} = {3}.{4} ", ForeignFactTable, ForeignMapTable, ForeignKeyField, primaryTable, InvokeMethod(BO,fieldInfo[i],"GetFieldName"));
								
								first = 1;
							}
							else
							{
								ForeignKeyAttribute foreignKeyAttribute = (ForeignKeyAttribute)attribute[j];
								ForeignMapTable = fieldInfo[i].Name;
								ForeignDisplayField = foreignKeyAttribute.DisplayName;
								ForeignMapField = foreignKeyAttribute.MappingName;
								select.Append(ForeignMapTable + "." + ForeignDisplayField +" AS " + ForeignMapField + ",");
							}
						}
					}
					if (into == 0)
						select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
					
				}
				else
					select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
			}
			if (!BO.Where.Equals(string.Empty))
				where.Append(" " + BO.Where); 
			sql = "SELECT TOP " + Convert.ToString(pageSize*(pageNumber-1)) + " " + select.ToString().Substring(0,select.ToString().Length - 1) + " " + from.ToString() +" " + join.ToString() + " " + where.ToString();// + orderby ;
			
			// 第一页
			if(pageNumber == 1)
			{
				sqlPrefix = string.Format("SELECT COUNT(*) {3} {6} {4};SELECT TOP {0} {5} {3} {6} {4} ORDER BY {1} {2}", 
					pageSize, 
					primaryTable + "." + idColumnName, 
					asc?"ASC":"DESC", 
					from.ToString(), 
					where.ToString(),
					select.ToString().Substring(0,select.ToString().Length - 1),
					join.ToString());
			}
			else
			{
				sqlPrefix = string.Format("SELECT COUNT(*) {7} {10} {8};SELECT TOP {0} {9} {7} {10} {8} AND {2} {3}([{1}]) FROM ({4} ORDER BY {2} {5}) AS TBLTMP){6} ORDER BY {2} {5}", 
					pageSize, 
					idColumnName, 
					primaryTable + "." + idColumnName, 
					asc?">(select max":"<(select min", 
					sql, 
					asc?"ASC":"DESC", 
					"",//asc?0:int.MaxValue, 
					from.ToString(), 
					where.ToString(),
					select.ToString().Substring(0,select.ToString().Length - 1),
					join.ToString());
			}

			select.Remove(0,select.Length);
			from.Remove(0,from.Length);
			where.Remove(0,where.Length);
			join.Remove(0, join.Length);
			return sqlPrefix;
		}


		/// <summary>
		/// 获取带分页功能的SQL
		/// </summary>
		/// <param name="BO"></param>
		/// <param name="pageNumber">页码（1开始）</param>
		/// <param name="pageSize">页大小</param>
		/// <param name="idColumnName">PKID列名</param>
		/// <param name="asc">升序 或 降序</param>
		/// <returns></returns>
		public static string  GetPagingSelectSQL(BusinessObject BO, int pageNumber, int pageSize, string idColumnName, bool asc, string finalOrder)
		{
			/*
			select top 20 *  
			from [SysUser] 
			where [PKID] > (
			select max([PKID]) 
			from (	select top 20 [PKID] 
				from [SysUser] 
				order by [PKID] asc) as tblTmp) 
			order by [PKID] asc
			*/

			string sqlPrefix;
			string primaryTable;
			string sql;
			string orderby ;
			System.Text.StringBuilder select = new System.Text.StringBuilder();
			System.Text.StringBuilder from = new System.Text.StringBuilder();
			System.Text.StringBuilder where = new System.Text.StringBuilder();
			System.Text.StringBuilder join = new System.Text.StringBuilder();

			primaryTable = BO.TableName;
			//			select.AppendFormat(" SELECT TOP {0} ", pageSize*(pageNumber-1));
			from.Append(" FROM  " + primaryTable);
			where.Append(" WHERE 1 = 1 ");
			orderby = BO.OrderBy;
			System.Reflection.FieldInfo[] fieldInfo = BO.GetType().GetFields();
			for(int i = 0; i < fieldInfo.Length; i++)
			{
				System.Attribute[] attribute = System.Attribute.GetCustomAttributes(fieldInfo[i]);
				
				//处理有外键的情况
				if (attribute.Length>0)
				{
					string ForeignFactTable			= string.Empty;
					string ForeignMapTable			= string.Empty;

					string ForeignDisplayField		= string.Empty;
					string ForeignKeyField			= string.Empty;
					string ForeignMapField			= string.Empty;

					int into  =0  ;
					int first = 0;
					for( int j = 0 ;j <attribute.Length ; j++)
					{
						if (attribute[j].ToString() == "Wicresoft.BusinessObject.ForeignKeyAttribute")
						{
							into = 1;
							if (first == 0)
							{
								ForeignKeyAttribute foreignKeyAttribute = (ForeignKeyAttribute)attribute[j];
								ForeignFactTable = foreignKeyAttribute.TableName;
								ForeignMapTable = fieldInfo[i].Name;

								ForeignKeyField = foreignKeyAttribute.PKID;
								ForeignDisplayField = foreignKeyAttribute.DisplayName;
								ForeignMapField = foreignKeyAttribute.MappingName;


								select.Append(ForeignMapTable + "." + ForeignKeyField + " AS  " +  fieldInfo[i].Name + ",");
								//2005-10-13，Tony，修改外键AS的名称
								select.Append(ForeignMapTable + "." + ForeignDisplayField +" AS " + ForeignMapField + ",");
								
								//								//2005-10-13，Tony，添加条件：!foreignTableList.Contains(foreignTableName)
								//								if (!from.Equals(string.Empty))
								//								{
								//									from.Append(" , " + ForeignFactTable+" AS " + ForeignMapTable); 
								//								}
								//								where.Append(" AND " + primaryTable + "." + InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " = " + ForeignMapTable + "." + ForeignKeyField);
								
								join.AppendFormat(" LEFT JOIN {0} AS {1} ON {1}.{2} = {3}.{4} ", ForeignFactTable, ForeignMapTable, ForeignKeyField, primaryTable, InvokeMethod(BO,fieldInfo[i],"GetFieldName"));
								
								first = 1;
							}
							else
							{
								ForeignKeyAttribute foreignKeyAttribute = (ForeignKeyAttribute)attribute[j];
								ForeignMapTable = fieldInfo[i].Name;
								ForeignDisplayField = foreignKeyAttribute.DisplayName;
								ForeignMapField = foreignKeyAttribute.MappingName;
								select.Append(ForeignMapTable + "." + ForeignDisplayField +" AS " + ForeignMapField + ",");
							}
						}
					}
					if (into == 0)
						select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
					
				}
				else
					select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
			}
			if (!BO.Where.Equals(string.Empty))
				where.Append(" " + BO.Where); 

			sql = "SELECT TOP " + Convert.ToString(pageSize*(pageNumber-1)) + " " + select.ToString().Substring(0,select.ToString().Length - 1) + " " + from.ToString() +" " + where.ToString();// + orderby ;
			
			finalOrder = (finalOrder == null || finalOrder.Trim() == string.Empty)?"":finalOrder + ",";

			// 第一页
			if(pageNumber == 1)
			{
				sqlPrefix = string.Format("SELECT COUNT(*) {3} {6} {4};SELECT TOP {0} {5} {3} {6} {4} ORDER BY {1} {2}", 
					pageSize, 
					primaryTable + "." + idColumnName, 
					asc?"ASC":"DESC", 
					from.ToString(), 
					where.ToString(),
					select.ToString().Substring(0,select.ToString().Length - 1),
					join.ToString());
			}
			else
			{

				sqlPrefix = string.Format("SELECT COUNT(*) {7} {10} {8};SELECT TOP {0} {9} {7} {10} {8} AND {2} {3}([{1}]) FROM ({4} ORDER BY {11} {2} {5}) AS TBLTMP) ORDER BY {11} {2} {5}", 
					pageSize, 
					idColumnName, 
					primaryTable + "." + idColumnName, 
					asc?">(select max":"<(select min", 
					sql, 
					asc?"ASC":"DESC", 
					"", 
					from.ToString(), 
					where.ToString(),
					select.ToString().Substring(0,select.ToString().Length - 1),
					join.ToString(),
					"");//finalOrder);
			}
			select.Remove(0,select.Length);
			from.Remove(0,from.Length);
			where.Remove(0,where.Length);
			join.Remove(0, join.Length);
			return sqlPrefix;
		}

//		/// <summary>
//		/// 获取带分页功能的SQL
//		/// </summary>
//		/// <param name="BO"></param>
//		/// <param name="pageNumber">页码（1开始）</param>
//		/// <param name="pageSize">页大小</param>
//		/// <param name="idColumnName">PKID列名</param>
//		/// <param name="asc">升序 或 降序</param>
//		/// <returns></returns>
//		public static string  GetPagingSelectSQL(BusinessObject BO, int pageNumber, int pageSize, string idColumnName, bool asc)
//		{
//			/*
//			select top 20 *  
//			from [SysUser] 
//			where [PKID] > (
//			select max([PKID]) 
//			from (	select top 20 [PKID] 
//				from [SysUser] 
//				order by [PKID] asc) as tblTmp) 
//			order by [PKID] asc
//			*/
//
//			string sqlPrefix;
//			string primaryTable;
//			string sql;
//			string orderby ;
//			System.Text.StringBuilder select = new System.Text.StringBuilder();
//			System.Text.StringBuilder from = new System.Text.StringBuilder();
//			System.Text.StringBuilder where = new System.Text.StringBuilder();
//
//			primaryTable = BO.TableName;
//			//			select.AppendFormat(" SELECT TOP {0} ", pageSize*(pageNumber-1));
//			from.Append(" FROM  " + primaryTable);
//			where.Append(" WHERE 1 = 1 ");
//			orderby = BO.OrderBy;
//			System.Reflection.FieldInfo[] fieldInfo = BO.GetType().GetFields();
//			for(int i = 0; i < fieldInfo.Length; i++)
//			{
//				System.Attribute[] attribute = System.Attribute.GetCustomAttributes(fieldInfo[i]);
//				
//				//处理有外键的情况
//				if (attribute.Length>0)
//				{
//					string ForeignFactTable			= string.Empty;
//					string ForeignMapTable			= string.Empty;
//
//					string ForeignDisplayField		= string.Empty;
//					string ForeignKeyField			= string.Empty;
//					string ForeignMapField			= string.Empty;
//
//					int into  =0  ;
//					int first = 0;
//					for( int j = 0 ;j <attribute.Length ; j++)
//					{
//						if (attribute[j].ToString() == "Wicresoft.BusinessObject.ForeignKeyAttribute")
//						{
//							into = 1;
//							if (first == 0)
//							{
//								ForeignKeyAttribute foreignKeyAttribute = (ForeignKeyAttribute)attribute[j];
//								ForeignFactTable = foreignKeyAttribute.TableName;
//								ForeignMapTable = fieldInfo[i].Name;
//
//								ForeignKeyField = foreignKeyAttribute.PKID;
//								ForeignDisplayField = foreignKeyAttribute.DisplayName;
//								ForeignMapField = foreignKeyAttribute.MappingName;
//
//
//								select.Append(ForeignMapTable + "." + ForeignKeyField + " AS  " +  fieldInfo[i].Name + ",");
//								//2005-10-13，Tony，修改外键AS的名称
//								select.Append(ForeignMapTable + "." + ForeignDisplayField +" AS " + ForeignMapField + ",");
//								
//								//2005-10-13，Tony，添加条件：!foreignTableList.Contains(foreignTableName)
//								if (!from.Equals(string.Empty))
//								{
//									from.Append(" , " + ForeignFactTable+" AS " + ForeignMapTable); 
//								}
//								where.Append(" AND " + primaryTable + "." + InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " = " + ForeignMapTable + "." + ForeignKeyField);
//								first = 1;
//							}
//							else
//							{
//								ForeignKeyAttribute foreignKeyAttribute = (ForeignKeyAttribute)attribute[j];
//								ForeignMapTable = fieldInfo[i].Name;
//								ForeignDisplayField = foreignKeyAttribute.DisplayName;
//								ForeignMapField = foreignKeyAttribute.MappingName;
//								select.Append(ForeignMapTable + "." + ForeignDisplayField +" AS " + ForeignMapField + ",");
//							}
//						}
//					}
//					if (into == 0)
//						select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
//					
//				}
//				else
//					select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
//			}
//			if (!BO.Where.Equals(string.Empty))
//				where.Append(" " + BO.Where); 
//			sql = "SELECT TOP " + Convert.ToString(pageSize*(pageNumber-1)) + " " + select.ToString().Substring(0,select.ToString().Length - 1) + " " + from.ToString() +" " + where.ToString();// + orderby ;
//			sqlPrefix = string.Format("SELECT COUNT(*) {7} {8};SELECT TOP {0} {9} {7} {8} AND {2} {3}([{1}]) FROM ({4} ORDER BY {2} {5}) AS TBLTMP),{6}) ORDER BY {2} {5}", 
//				pageSize, idColumnName, primaryTable + "." + idColumnName, asc?">isnull((select max":"<isnull((select min", sql, asc?"ASC":"DESC", asc?0:int.MaxValue, from.ToString(), where.ToString(),select.ToString().Substring(0,select.ToString().Length - 1) );
//
//			select.Remove(0,select.Length);
//			from.Remove(0,from.Length);
//			where.Remove(0,where.Length);
//			return sqlPrefix;
//		}

		public static string  GetSingleSelectSQL(BusinessObject BO)
		{
			string primaryTable;
			string sql;
			string orderby ;
			System.Text.StringBuilder select = new System.Text.StringBuilder();
			System.Text.StringBuilder from = new System.Text.StringBuilder();
			System.Text.StringBuilder where = new System.Text.StringBuilder();
			
			primaryTable = BO.TableName;
			select.Append(" SELECT  ");
			from.Append(" FROM  " + primaryTable);
			where.Append(" WHERE 1 = 1 ");
			orderby = BO.OrderBy;
			System.Reflection.FieldInfo[] fieldInfo = BO.GetType().GetFields();
			for(int i = 0; i < fieldInfo.Length; i++)
			{
				System.Attribute[] attribute = System.Attribute.GetCustomAttributes(fieldInfo[i]);
				
				select.Append(primaryTable + "." +  InvokeMethod(BO,fieldInfo[i],"GetFieldName") + " AS " +   fieldInfo[i].Name + ",");
			}
			if (!BO.Where.Equals(string.Empty))
				where.Append(" " + BO.Where); 
			sql = select.ToString().Substring(0,select.ToString().Length - 1) + " " + from.ToString() +" " + where.ToString() + orderby ;
			select.Remove(0,select.Length);
			from.Remove(0,from.Length);
			where.Remove(0,where.Length);
			return sql;
		}
		#endregion

		#region GetInsertSQL
		public static  string GetInsertSQL(BusinessObject BO,out bool  haveIdentity,out FieldInfo mfieldinfo )
		{
			string tableName;
			string sql;
			System.Text.StringBuilder insert = new System.Text.StringBuilder();
			System.Text.StringBuilder fields = new System.Text.StringBuilder();
			System.Text.StringBuilder values = new System.Text.StringBuilder();

			haveIdentity = false;
			mfieldinfo = null;
			tableName = BO.TableName;
			insert.Append(" Insert Into " + tableName);
			fields.Append( " (" );
			values.Append( " Values( ");
			
			FieldInfo[] fieldInfo = BO.GetType().GetFields();
			for (int i = 0;i < fieldInfo.Length;i++)
			{
				string insertValue;
				bool into =false;
				System.Attribute[] attribute = Attribute.GetCustomAttributes(fieldInfo[i]);
				if (attribute.Length >0 )
				{
					into = false;
					for (int j = 0 ; j < attribute.Length ; j++)
					{
						if(attribute[j].ToString() == "Wicresoft.BusinessObject.PrimaryKeyAttribute")
						{
							PrimaryKeyAttribute keyattribute = (PrimaryKeyAttribute) attribute[j];
							if (keyattribute.Policy == PrimaryKeyPolicy.Auto)
							{
								haveIdentity = true;
								into =true;
								mfieldinfo = fieldInfo[i];
							}
						}
						else if(attribute[j].ToString() == "Wicresoft.BusinessObject.CalculationFieldAttribute")	// tony, 2008-07-25
						{
							into = true;
						}
					}
				}


				if ( into == false)
				{
					insertValue = InvokeMethod(BO,fieldInfo[i],"GetInsertValues");
					if (insertValue != null)
					{
						fields.Append( InvokeMethod(BO,fieldInfo[i],"GetFieldName") + ",");
						values.Append( insertValue + ",");
					}
				}
			}
			sql = insert + fields.ToString().Substring(0,fields.ToString().Length - 1 ) + ") " + values.ToString().Substring(0,values.ToString().Length - 1) + " )";
			insert.Remove(0,insert.Length );
			fields.Remove(0,fields.Length );
			values.Remove(0,values.Length );
			return sql;
		}
		#endregion

		#region GetUpdateSQL
		public static string  GetUpdateSQL(BusinessObject BO)
		{
			string update;
			string where;
			string tableName;
			string sql; 
			bool into = false;
			System.Text.StringBuilder Set = new System.Text.StringBuilder();
			Set.Append(" SET ");
			where = " WHERE 1=1 ";
			tableName = BO.TableName;
			update = " UPDATE  " + tableName + " ";
			FieldInfo[] fieldInfo = BO.GetType().GetFields();
			
			for (int i = 0 ; i < fieldInfo.Length; i++)
			{
				into = false;
				System.Attribute[] attribute = System.Attribute.GetCustomAttributes(fieldInfo[i]);
				if (attribute.Length>0)
				{
					for(int j = 0 ; j<attribute.Length ; j++)
					{
						if (attribute[j].ToString() == "Wicresoft.BusinessObject.PrimaryKeyAttribute")
						{
							where = where + " AND  " + InvokeMethod(BO,fieldInfo[i],"GetUpdateOrDeleteWhere");
							PrimaryKeyAttribute keyattribute = (PrimaryKeyAttribute) attribute[j];
							if (keyattribute.Policy == PrimaryKeyPolicy.Auto)
								into =true;
						}
						else if(attribute[j].ToString() == "Wicresoft.BusinessObject.CalculationFieldAttribute")	// tony, 2008-07-25
						{
							into = true;
						}
					}
				}
				if (into == false)
				{
					string fieldValue = InvokeMethod(BO,fieldInfo[i],"GetUpdateSet");
					if ( fieldValue != null )
					{
						Set.Append( fieldValue + ",");
					}
				}
			}
			sql = update + Set.ToString().Substring(0,Set.ToString().Length - 1) + where;
			Set.Remove(0,Set.Length);
			return sql;
		}

		public static string  GetUpdateFilterSQL(BusinessObject BO)
		{
			string update;
			string where;
			string tableName;
			string sql; 
			System.Text.StringBuilder Set = new System.Text.StringBuilder();
			Set.Append(" SET ");
			where = " WHERE 1=1 " + BO.Where;
			tableName = BO.TableName;
			update = " UPDATE  " + tableName + " ";
			FieldInfo[] fieldInfo = BO.GetType().GetFields();
			
			for (int i = 0 ; i < fieldInfo.Length; i++)
			{
				System.Attribute[] attribute = System.Attribute.GetCustomAttributes(fieldInfo[i]);
				bool into = false;
				for (int j = 0 ; j<attribute.Length ; j++)
				{
					if (attribute[j].ToString() == "Wicresoft.BusinessObject.PrimaryKeyAttribute")
					{
						PrimaryKeyAttribute auto = (PrimaryKeyAttribute)attribute[j];
						if (auto.Policy == PrimaryKeyPolicy.Auto)
						{
							into = true;
						}
					}
				}
				if (into == false)
				{
					string fieldValue = InvokeMethod(BO,fieldInfo[i],"GetUpdateSet");
					if ( fieldValue != null )
					{
						Set.Append( fieldValue + ",");
					}
				}
				
			}
			sql = update + Set.ToString().Substring(0,Set.ToString().Length - 1) + where;
			Set.Remove(0,Set.Length);
			return sql;
		}
		#endregion

		#region GetDeleteSQL
		public static string GetDeleteSQL(BusinessObject BO)
		{
			string tableName;
			string where;
			string delete;

			tableName = BO.TableName;
			where = "  Where 1=1 ";
			
			FieldInfo[] fieldInfo = BO.GetType().GetFields();
			for (int i = 0 ; i <fieldInfo.Length ; i++)
			{
				System.Attribute[] attribute = System.Attribute.GetCustomAttributes(fieldInfo[i]);
				if (attribute.Length>0)
				{
					for (int j = 0 ; j<attribute.Length ; j++)
					{
						if (attribute[j].ToString() == "Wicresoft.BusinessObject.PrimaryKeyAttribute")
							where = where + " AND  " + InvokeMethod(BO,fieldInfo[i],"GetUpdateOrDeleteWhere");
					}
				}
			}
			delete = " DELETE " + tableName + where ;
			return delete;
		}

		public static string GetDeleteFilterSQL(BusinessObject BO)
		{
			string tableName;
			string where;
			string delete;

			tableName = BO.TableName;
			where = "  Where 1=1 ";
			
			if (!BO.Where.Equals(string.Empty))
				where = where + "  " + BO.Where;
			
			delete = " DELETE " + tableName + where ;
			return delete;
		}
		#endregion

	}
}
