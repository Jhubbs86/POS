using System;


using Wicresoft.BusinessObject;

namespace BusinessView
{
	/// <summary>
	/// Summary description for Common.
	/// </summary>
	public class Common
	{
		public BusinessObjectView GetBusinessObjectViewFromName(string viewName)
		{
			return this.GetType().Assembly.CreateInstance("BusinessView." + viewName) as BusinessObjectView;
		}
	}
}
