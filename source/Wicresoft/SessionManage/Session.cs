using System;


using Wicresoft.DataAccess;
namespace Wicresoft.Session
{
	/// <summary>
	/// Summary description for Transaction.
	/// </summary>
	public sealed  class Session
	{
		
		public SQLServer SqlHelper ;
		
		public  Session()
		{
			SqlHelper = new SQLServer();
			this.SqlHelper.ExecuteNonQuery(" SET transaction isolation level read uncommitted ", System.Data.CommandType.Text);
		}		

		public  void  Commit()
		{
			SqlHelper.Commit();
			
		}

		public  void  Rollback()
		{
			SqlHelper.Rollback();

		}

		public  void  BeginTransaction()
		{
			SqlHelper.BeginTransaction();
		}

	}
}
