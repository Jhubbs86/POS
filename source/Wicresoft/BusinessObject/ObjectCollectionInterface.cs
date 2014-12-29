using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for ObjectCollectionInterface.
	/// </summary>
	public interface ObjectCollectionInterface
	{
		#region Collection
		void Add(BusinessObject businessobject);
		void Remove(BusinessObject businessobject);
		void Query();
		void Save();
		void DeleteFilter();
		void UpdateFilter();
		#endregion
	}
}
