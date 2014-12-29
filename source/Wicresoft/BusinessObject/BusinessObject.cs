using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for BusinessObject.
	/// </summary>
	public abstract class BusinessObject:ObjectInterface
	{

		public BusinessObject()
		{
			this.rowstatus = RowStatus.New;
		}
		private Wicresoft.Session.Session session ; 
		public Wicresoft.Session.Session SessionInstance
		{
			get
			{
				return session ; 
			}
			set
			{
				session = value;
			}
		}

		private  Wicresoft.DataAccess.SQLServer sqlhelper ;
		public Wicresoft.DataAccess.SQLServer SqlHelper
		{
			get
			{
				return sqlhelper ; 
			}
			set
			{
				sqlhelper = value;
			}
		}

		#region Field
		private RowStatus rowstatus;
		public RowStatus Rowstatus
		{
			get { return rowstatus ; }
			set { rowstatus = value ; }
		}

		private string tablename = string.Empty;
		public string TableName
		{
			get { return this.tablename; }
			set { this.tablename = value; }
		}

		private string orderby = string.Empty ;
		public string OrderBy
		{
			get { return this.orderby ; }
			set { orderby = value; }
		}

		private string where = string.Empty ;
		public string Where
		{
			get { return where ; }
			set { where = value; }
		}

		private bool haverecord = false;
		public bool HaveRecord
		{
			get
			{
				return haverecord;
			}
			set
			{
				haverecord  = value ;
			}
		}
		#endregion

		#region abstract method

		public abstract  BusinessObject Clone();

		#endregion

		#region Single　主要封装操作单个对象的方法，他将立刻操作数据库

		public void Load()
		{
			BusinessObjectProxy.Load(this);
		}

		public void  Insert()
		{
			BusinessObjectProxy.Insert(this);
		}

		public void Update()
		{
			 BusinessObjectProxy.Update(this);
		}

		public void Delete()
		{
			 BusinessObjectProxy.Delete(this);
		}

		public void DeleteObject()
		{
			this.rowstatus = RowStatus.Delete;
		}

		public void ModifyObject()
		{
			this.rowstatus = RowStatus.Modify;
		}

		
		#endregion Single

		#region AddFilter / ClearFilter
		public void AddFilter(BusinessFilter filter)
		{
			if (!filter.Filter.Equals(string.Empty))
			{
				this.Where = this.Where + filter.Filter + " )";
			}
		}

		public void ClearFilter()
		{
			this.Where = string.Empty;
		}
		#endregion

	}
}
