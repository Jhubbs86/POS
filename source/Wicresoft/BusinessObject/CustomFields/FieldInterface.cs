using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for FieldInterface.
	/// </summary>
	public interface FieldInterface
	{
		string GetUpdateSet();
		string GetInsertValues();
		string GetDisplayValue();
		RowStatus GetRowStatus();
	}
}
