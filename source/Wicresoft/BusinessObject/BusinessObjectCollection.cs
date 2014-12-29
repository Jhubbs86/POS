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
					throw new System.Exception("����Խ��");
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
		 *  ����filter��������װ�ض��󵽼����У�����ͨ������������ÿ������
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
		 * ���漯���е����ж������ݿ���
		 * ʹ��Ҫ��
		 * ����Ҫ�޸�һ������ʱ��������ö����ModifyObject����
		 * ����Ҫɾ��һ������ʱ��������ö����DeleteObject����
		 * ���������󣬲���Ҫ�����κζ���Ĭ��Ϊ��������
		 * */
		public void Save()
		{
			BusinessObjectProxy.SaveCollection(this);
		}



		/*
		 * ��������
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
		 * ��������
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

		/* ���������󼯺ϵ�һ��DataTable
		 * ʹ�ó��ϣ���Ҫ���һ��DataTable�󶨵�DataGrid��
		 * 
		 * ���̴���
		 * BusinessObjectCollection Products = new BusinessObjectCollection("Product");
		 * BusinessFilter filter = new BusinessFilter("Product");
		 * filter.AddFilterItem();
		 * Products.GetDataTable();
		 * 
		 * ֧�ֶ���filter
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
		/// ��ԭDataTable�ϲ���������
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
		/// ��ȡ��ҳ��¼��
		/// </summary>
		/// <param name="pageNumber">ҳ�루1��ʼ��</param>
		/// <param name="pageSize">ҳ��С</param>
		/// <param name="idColumnName">PKID����</param>
		/// <param name="IsAsc">���� �� ����</param>
		/// <returns>��¼����������DataTable����һ�����ؼ�¼���������ڶ������ط�ҳ��ļ�¼��һҳ��</returns>
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
		/// ��ȡ��ҳ��¼��
		/// </summary>
		/// <param name="pageNumber">ҳ�루1��ʼ��</param>
		/// <param name="pageSize">ҳ��С</param>
		/// <param name="idColumnName">PKID����</param>
		/// <param name="IsAsc">���� �� ����</param>
		/// <returns>��¼����������DataTable����һ�����ؼ�¼���������ڶ������ط�ҳ��ļ�¼��һҳ��</returns>
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
