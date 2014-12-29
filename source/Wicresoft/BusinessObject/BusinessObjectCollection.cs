using System;
using System.Reflection;
using System.Data;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for BusinessObjectCollection.
	/// </summary>
	/// 
	using Wicresoft.Session;
	using Wicresoft.DataAccess;


	public  class  BusinessObjectCollection:ObjectCollectionInterface
	{
		private System.Collections.ArrayList objectlist = new System.Collections.ArrayList();
		
		private Wicresoft.Session.Session session ;
		public Wicresoft.Session.Session SessionInstance 
		{
			get
			{
				return session ; 
			}
			set
			{
				this.businessobject.SessionInstance = value;
				session = value ;
			}
		}

		private Wicresoft.DataAccess.SQLServer sqlhelper ; 
		public Wicresoft.DataAccess.SQLServer SqlHelper
		{
			get
			{
				return sqlhelper;
			}
			set
			{
				this.Businessobject.SqlHelper = value;
				sqlhelper = value;
			}
		}

		private BusinessObject businessobject = null;
		public BusinessObject Businessobject 
		{
			get
			{
				return businessobject;
			}
			set
			{
				businessobject = value;
			}
		}

		private BusinessFilter businessfilter = null;
		

		public void RemoveAllObject()
		{
			this.objectlist.Clear();
		}
		public void AddFilter(BusinessFilter filter)
		{
			if (filter == null ||filter.Filter == null ||filter.Filter.Equals(string.Empty))
				return ;
			if (filter != null)
			{
				businessfilter = filter;
				this.businessobject.AddFilter(filter);
			}
		}
		
		public int Count
		{
			get 
			{
				return objectlist.Count;
			}
		}

		public   BusinessObjectCollection(string Object )
		{
			try
			{
//				System.Reflection.Assembly assembly = Assembly.LoadFrom(Configuration.GetKeyValue(Configuration.BusinessLogic)+".dll");
				businessobject = (BusinessObject)Global.GetBusinessLogicAssembly().CreateInstance(Configuration.GetKeyValue(Configuration.BusinessLogic)+"."+Object);

			}
			catch(System.Exception ex)
			{
				throw ex;
			}
		}


	
		public BusinessObject this[int index]
		{
			get
			{
				if (index<0 ||index> objectlist.Count)
				{
					throw new System.Exception("数组越界");
				}
				return (BusinessObject)objectlist[index];
			}
		}
		
		public void Add(BusinessObject mbusinessobject)
		{
			if (!objectlist.Contains(mbusinessobject))
				objectlist.Add(mbusinessobject);
		}

		public void Remove(BusinessObject mbusinessobject)
		{
			if (objectlist.Contains(mbusinessobject))
				mbusinessobject.DeleteObject();
		}

		/*
		 *  根据filter的条件，装载对象到集合中，可以通过数组来访问每个对象
		 * 
		 * BusinessObjectCollection Products = new BusinessObjectCollection("Product");
		 * BusinessFilter filter = new BusinessFilter("Product");
		 * filter.AddFilterItem();
		 * Products.Query();
		 * ((Product)Products[i]).ID;
		 * 
		 * 
		 * */
		public void Query()
		{
			BusinessObjectProxy.Query(businessobject,this);
		}

		/*
		 * 保存集合中的所有对象到数据库中
		 * 使用要求
		 * 当需要修改一个对象时，必须调用对象的ModifyObject方法
		 * 当需要删除一个对象时，必须调用对象的DeleteObject方法
		 * 当新增对象，不需要调用任何对象，默认为新增对象
		 * */
		public void Save()
		{
			BusinessObjectProxy.SaveCollection(this);
		}



		/*
		 * 代码例程
		 * BusinessObjectCollection Products = new BusinessObjectCollection("Product");
		 * BusinessFilter filter = new BusinessFilter("Product");
		 * filter.AddFilterItems();
		 * Products.AddFilter(filter);
		 * Products.DeleteFilter(); 
		 * */
		public void DeleteFilter()
		{
			string SQL;
			try
			{
				SQL = AssemblyBusinessObject.GetDeleteFilterSQL(this.businessobject);
				if (this.SessionInstance != null )
					this.SessionInstance.SqlHelper.ExecuteNonQuery(SQL,CommandType.Text);
				else
					this.SqlHelper.ExecuteNonQuery(SQL,CommandType.Text);
			}
			catch(System.Exception ex)
			{
				throw ex;
			}
		}
		/*
		 * 代码例程
		 * BusinessObjectCollection Products = new BusinessObjectCollection("Product");
		 * BusinessFilter filter = new BusinessFilter("Product");
		 * filter.AddFilterItems();
		 * Products.AddFilter(filter);
		 * ((Product)Products.BusinessObject).ID = 100;
		 * Products.UpdateFilter();
		 * 
		 * 
		 * */
		public void UpdateFilter()
		{
			string SQL ; 
			try
			{
				SQL = AssemblyBusinessObject.GetUpdateFilterSQL(this.Businessobject);
				if (this.SessionInstance != null )
					this.SessionInstance.SqlHelper.ExecuteNonQuery(SQL,CommandType.Text);
				else
					this.SqlHelper.ExecuteNonQuery(SQL,CommandType.Text);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		/* 获得这个对象集合的一个DataTable
		 * 使用场合：需要获得一个DataTable绑定到DataGrid中
		 * 
		 * 例程代码
		 * BusinessObjectCollection Products = new BusinessObjectCollection("Product");
		 * BusinessFilter filter = new BusinessFilter("Product");
		 * filter.AddFilterItem();
		 * Products.GetDataTable();
		 * 
		 * 支持多种filter
		 * */
		public DataTable GetDataTable()
		{
			string SQL;
			System.Data.DataSet ds = null;
			try
			{
				SQL = AssemblyBusinessObject.GetSelectSQL(this.businessobject);
				//this.Businessobject.SqlHelper
				if (this.SessionInstance != null)
					ds = this.SessionInstance.SqlHelper.ExecuteDataSet(SQL,CommandType.Text);
				else
					ds = this.SqlHelper.ExecuteDataSet(SQL,CommandType.Text);
				ds.Tables[0].TableName = this.Businessobject.GetType().Name;
				return ds.Tables[0];
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		
		/// <summary>
		/// 在原DataTable上插入新数据
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		/// <remarks>2006-11-27, Tony Zhang</remarks>
		public DataTable GetDataTable(DataTable table)
		{
			string SQL;
			System.Data.DataTable dt = null;
			try
			{
				SQL = AssemblyBusinessObject.GetSelectSQL(this.businessobject);
				//this.Businessobject.SqlHelper
				if (this.SessionInstance != null)
					dt = this.SessionInstance.SqlHelper.ExcuteDataTable(table, SQL,CommandType.Text);
				else
					dt = this.SqlHelper.ExcuteDataTable(table, SQL,CommandType.Text);
			
				return dt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public DataTable GetDataTable(string fields,string where)
		{
			string SQL;
			System.Data.DataSet ds = null;

			if (fields.Equals(string.Empty))
				return null;
			if (where.Equals(string.Empty))
			{
				SQL = string.Format("SELECT {0}  FROM {1} " ,fields,this.Businessobject.TableName);
			}
			else
			{
				SQL = string.Format("SELECT {0} FROM {1} WHERE {2}",fields,this.businessobject.TableName,where);
			}
			try
			{
				if (this.SessionInstance!= null)
					ds = this.SessionInstance.SqlHelper.ExecuteDataSet(SQL,CommandType.Text);
				else
					ds = this.SqlHelper.ExecuteDataSet(SQL,CommandType.Text);
				ds.Tables[0].TableName = this.Businessobject.GetType().Name;
				return ds.Tables[0];
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 获取分页记录集
		/// </summary>
		/// <param name="pageNumber">页码（1开始）</param>
		/// <param name="pageSize">页大小</param>
		/// <param name="idColumnName">PKID列名</param>
		/// <param name="IsAsc">升序 或 降序</param>
		/// <returns>记录集包括两个DataTable，第一个返回记录总条数，第二个返回分页后的记录（一页）</returns>
		public DataSet GetPagedRecords(int pageNumber, int pageSize, string idColumnName, bool IsAsc )
		{
			string SQL;
			System.Data.DataSet ds = null;
			try
			{
				SQL = AssemblyBusinessObject.GetPagingSelectSQL(this.businessobject, pageNumber, pageSize, idColumnName, IsAsc);
				//this.Businessobject.SqlHelper
				if (this.SessionInstance != null)
					ds = this.SessionInstance.SqlHelper.ExecuteDataSet(SQL,CommandType.Text);
				else
					ds = this.SqlHelper.ExecuteDataSet(SQL,CommandType.Text);
				//				ds.Tables[0].TableName = this.Businessobject.GetType().Name;
				return ds;//.Tables[0];
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		

		/// <summary>
		/// 获取分页记录集
		/// </summary>
		/// <param name="pageNumber">页码（1开始）</param>
		/// <param name="pageSize">页大小</param>
		/// <param name="idColumnName">PKID列名</param>
		/// <param name="IsAsc">升序 或 降序</param>
		/// <returns>记录集包括两个DataTable，第一个返回记录总条数，第二个返回分页后的记录（一页）</returns>
		public DataSet GetPagedRecords(int pageNumber, int pageSize, string idColumnName, bool IsAsc, string finalOrder)
		{
			string SQL;
			System.Data.DataSet ds = null;
			try
			{
				SQL = AssemblyBusinessObject.GetPagingSelectSQL(this.businessobject, pageNumber, pageSize, idColumnName, IsAsc, finalOrder);
				//this.Businessobject.SqlHelper
				if (this.SessionInstance != null)
					ds = this.SessionInstance.SqlHelper.ExecuteDataSet(SQL,CommandType.Text);
				else
					ds = this.SqlHelper.ExecuteDataSet(SQL,CommandType.Text);
				//				ds.Tables[0].TableName = this.Businessobject.GetType().Name;
				return ds;//.Tables[0];
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
