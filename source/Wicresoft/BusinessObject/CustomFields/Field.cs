using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for Field.
	/// </summary>
	public class Field
	{
		public int SetValue = 0;

		private string displayValue = string.Empty;
		public string DisplayValue
		{
			get { return this.displayValue ; }
			set { this.displayValue = value; }
		}

		private string fieldname = string.Empty;
		public string GetFieldName()
		{
			return fieldname;
		}

		private string fieldDescription = string.Empty;
		public string FieldDescription
		{
			get { return this.fieldDescription; }
			set { this.fieldDescription = value; }
		}

		private RowStatus rowstatus;
		public RowStatus rowStatus
		{
			get { return this.rowstatus; }
			set { this.rowstatus = value ;}
		}

		public Field(string mfieldname, string fieldDesc)
		{
			this.fieldname = mfieldname;
			this.fieldDescription = fieldDesc;
		}

		public Field(string mfieldname)
		{
			this.fieldname = mfieldname;
		}
		public Field()
		{

		}	
	}
}
