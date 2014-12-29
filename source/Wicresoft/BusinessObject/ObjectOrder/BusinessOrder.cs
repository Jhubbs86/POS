using System;
using System.Reflection;


namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for BusinessOrder.
	/// </summary>
	public class BusinessOrder
	{

		#region constructor
		public BusinessOrder(string Object)
		{
			order = string.Empty;
//			System.Reflection.Assembly assembly = Assembly.LoadFrom(Configuration.GetKeyValue(Configuration.BusinessLogic)+".dll");
			businessobject = (BusinessObject)Global.GetBusinessLogicAssembly().CreateInstance(Configuration.GetKeyValue(Configuration.BusinessLogic)+"."+Object);
		
		}
		#endregion

		#region Member
		private BusinessObject businessobject = null ;
		private string order = string.Empty;
		public string Order
		{
			get{ return order;}
		}
		#endregion

		#region AddOrder
		public void AddOrder(string  field,Order enumOrder)
		{
			string tableName;
			string fieldName;

			tableName = businessobject.TableName;
			fieldName = field;

			if (order.Equals(string.Empty))
			{
				order = tableName + "." + fieldName + " " + enumOrder.ToString();
			}
			else
			{
				order = order + "," + tableName + "." + fieldName + " " + enumOrder.ToString();
			}
		}
		#endregion

	}
}
