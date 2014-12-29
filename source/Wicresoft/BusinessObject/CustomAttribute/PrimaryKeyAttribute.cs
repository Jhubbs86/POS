using System;

namespace  Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for PrimaryKeyAttribute.
	/// </summary>
	public class PrimaryKeyAttribute:System.Attribute
	{
		public PrimaryKeyAttribute(PrimaryKeyPolicy policy)
		{
			Policy = policy;
		}
		public PrimaryKeyPolicy Policy ; 


	}
}
