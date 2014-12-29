using System;
using System.Data;
using System.Reflection;

using Wicresoft.DataAccess;
using Wicresoft.Session;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for BusinessObjectProxy.
	/// </summary>
	public class BusinessObjectProxy
	{
		public static void Insert(BusinessObject BO)
		{

			string SQL;
			System.Int32 affect ;
		    bool haveIdentity = false;
			FieldInfo fieldinfo = null;
			//获得插入串
			SQL = AssemblyBusinessObject.GetInsertSQL(BO,out haveIdentity,out fieldinfo);
			try
			{
				//如果该对象有自增字段，将获得自增的值，同时保存到对象中
				//该对象没有自增字段，将按照正常处理方式处理
				if(haveIdentity == false)
				{
					if (BO.SessionInstance != null )
						BO.SessionInstance.SqlHelper.ExecuteNonQuery(SQL,CommandType.Text);
					else
						BO.SqlHelper.ExecuteNonQuery(SQL,CommandType.Text);
				}
				else
				{
					object obj ; 
					if (BO.SessionInstance != null )
						obj = BO.SessionInstance.SqlHelper.ExecuteScalar(SQL +"; select @@Identity",CommandType.Text).ToString();
					else
						obj = BO.SqlHelper.ExecuteScalar(SQL +"; select @@Identity",CommandType.Text).ToString();
					affect = Convert.ToInt32(obj);
					Field field = (Field)fieldinfo.GetValue(BO);
					
					System.Reflection.PropertyInfo subfieldinfo = field.GetType().GetProperty("Value");
					subfieldinfo.SetValue(field,affect,BindingFlags.SetProperty,null,null,null);
				}
			}
			catch(System.Exception ex)
			{
				throw ex;
			}
		}


		public static void Update(BusinessObject BO)
		{
			string SQL;
			string connectionstring;
			connectionstring = string.Empty;
			SQL = AssemblyBusinessObject.GetUpdateSQL(BO);
			try
			{
				if (BO.SessionInstance != null )
					BO.SessionInstance.SqlHelper.ExecuteNonQuery(SQL,CommandType.Text);
				else
					BO.SqlHelper.ExecuteNonQuery(SQL,CommandType.Text);
			}
			catch(System.Exception ex)
			{
				throw ex;
			}
		}


		public static void Delete(BusinessObject BO)
		{
			string SQL;
			string connectionstring;
			connectionstring = string.Empty;
			SQL = AssemblyBusinessObject.GetDeleteSQL(BO);
			try
			{
				if (BO.SessionInstance != null )
					BO.SessionInstance.SqlHelper.ExecuteNonQuery(SQL,CommandType.Text);
				else
					BO.SqlHelper.ExecuteNonQuery(SQL,CommandType.Text);
			}
			catch(System.Exception ex)
			{
				throw ex;
			}
		}
		public static bool HaveRecord(BusinessObject BO)
		{
			string sql ;
			sql = AssemblyBusinessObject.GetSelectSQL(BO);

			DataSet ds ;
			DataTable dt;
			ds = null;
			if (BO.SessionInstance != null)
				ds = BO.SessionInstance.SqlHelper.ExecuteDataSet(sql,CommandType.Text);
			else
				ds = BO.SqlHelper.ExecuteDataSet(sql,CommandType.Text);
			dt = ds.Tables[0];
			if (dt.Rows.Count <= 0 )
				return false ;
			else
				return true ;
		}

		public static void Load(BusinessObject BO)
		{
			try
			{
				string sql ;
				string connectionstring;
				sql = AssemblyBusinessObject.GetSelectSQL(BO);
				connectionstring = string.Empty;

				DataSet ds ;
				DataTable dt;
				string [] tablename = new string[1];
				string mappingName;
				ds = null;
				if (BO.SessionInstance != null)
					ds = BO.SessionInstance.SqlHelper.ExecuteDataSet(sql,CommandType.Text);
				else
					ds = BO.SqlHelper.ExecuteDataSet(sql,CommandType.Text);
				dt = ds.Tables[0];
				if (dt.Rows.Count <= 0 )
				{
					BO.HaveRecord = false ;
					return ;
				}
				else
					BO.HaveRecord = true;

				FieldInfo [] fieldinfo = BO.GetType().GetFields();
				for (int i = 0 ; i < fieldinfo.Length ; i++ )
				{
					System.Attribute [] attribute = System.Attribute.GetCustomAttributes(fieldinfo[i]);
					Field field = (Field)fieldinfo[i].GetValue(BO);
					//为外键的Display字段赋值
					if (attribute.Length > 0)
					{
						for (int j = 0 ; j < 1 ; j++)
						{
							if (attribute[j].ToString() == "Wicresoft.BusinessObject.ForeignKeyAttribute")
							{
								mappingName = ((ForeignKeyAttribute)attribute[0]).MappingName;

								if (dt.Rows[0][fieldinfo[i].Name] == System.DBNull.Value)
								{
									if (dt.Rows[0][mappingName] != System.DBNull.Value)
									{
										field.DisplayValue = dt.Rows[0][mappingName].ToString();
									}
								}
								else
								{
									field.DisplayValue = dt.Rows[0][mappingName].ToString();
								}
							}
						}
					}
					//为每个字段的Value赋值
					System.Reflection.PropertyInfo subfieldinfo = field.GetType().GetProperty("Value");
					if (dt.Rows[0][fieldinfo[i].Name] != System.DBNull.Value)
					{
						subfieldinfo.SetValue(field,dt.Rows[0][fieldinfo[i].Name],BindingFlags.SetProperty,null,null,null);
					}
				}
			}
			catch(System.Exception ex)
			{
				throw ex;
			}
		}
	

		public static void Query(BusinessObject BO,BusinessObjectCollection collection)
		{
			try
			{
				string sql ;
				string connectionstring;
				sql = AssemblyBusinessObject.GetSelectSQL(BO);
				collection.RemoveAllObject();
				connectionstring = string.Empty;

				DataSet ds ;
				DataTable dt;
				string [] tablename = new string[1];
				string displayname ;

				ds = null;
				if (BO.SessionInstance != null)
					ds = BO.SessionInstance.SqlHelper.ExecuteDataSet(sql,CommandType.Text);
				else
					ds = BO.SqlHelper.ExecuteDataSet(sql,CommandType.Text);

				//ds = DBFactory.GetInstance().GetSqlHelper().ExecuteDataSet(sql,CommandType.Text);
				dt = ds.Tables[0];
				if (dt.Rows.Count <= 0 )
					return ;
				BusinessObject businessobject ;
				
				for( int rows = 0 ;  rows <dt.Rows.Count; rows ++  )
				{
					businessobject = BO.Clone();
					FieldInfo [] fieldinfo = businessobject.GetType().GetFields();
					
					for (int i = 0 ; i < fieldinfo.Length ; i++ )
					{
						System.Attribute [] attribute = System.Attribute.GetCustomAttributes(fieldinfo[i]);
						Field field = (Field)fieldinfo[i].GetValue(businessobject);
						//为外键的Display字段赋值
						if (attribute.Length > 0)
						{
							for( int j = 0 ; j <attribute.Length ; j++)
							{
								if (attribute[j].ToString() == "Wicresoft.BusinessObject.ForeignKeyAttribute")
								{
									displayname = ((ForeignKeyAttribute)attribute[0]).MappingName;
									if (dt.Rows[rows][fieldinfo[i].Name] == System.DBNull.Value)
									{
										if (dt.Rows[rows][displayname] != System.DBNull.Value)
											field.DisplayValue = dt.Rows[rows][displayname].ToString();
									}
									else
										field.DisplayValue = dt.Rows[rows][displayname].ToString();
								}
							}
						}
						//为每个字段的Value赋值
						System.Reflection.PropertyInfo subfieldinfo = field.GetType().GetProperty("Value");
						if (dt.Rows[rows][fieldinfo[i].Name] != System.DBNull.Value)
						{
							subfieldinfo.SetValue(field,dt.Rows[rows][fieldinfo[i].Name],BindingFlags.SetProperty,null,null,null);
						}
					}
					businessobject.Rowstatus = RowStatus.Old;
					collection.Add(businessobject);
				}
			}
			catch(System.Exception ex)
			{
				throw ex;
			}
		}


		public static void SaveCollection(BusinessObjectCollection collection)
		{
			int count;
			count = collection.Count;
			for (int i = 0 ; i<count; i ++)
			{
				BusinessObject businessobject = collection[i];
				if (collection.SessionInstance != null)
					businessobject.SessionInstance = collection.SessionInstance;
				else if (collection.SqlHelper != null)
					businessobject.SqlHelper = collection.SqlHelper ;
				else
					return ;
				RowStatus rowstatus = businessobject.Rowstatus;
				if (rowstatus == RowStatus.New)
					businessobject.Insert();
				if (rowstatus == RowStatus.Modify)
					businessobject.Update();
				if( rowstatus == RowStatus.Delete)
					businessobject.Delete();
			}
		}
	}
}
