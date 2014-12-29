using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for ObjectInterface.
	/// </summary>
	public interface ObjectInterface
	{
		#region Single
		void Load();
		void Insert();
		void Update();
		void Delete();
		#endregion

		#region 

		void DeleteObject();
		void ModifyObject();
		#endregion
	}
}
