using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for DateField.
	/// </summary>
	public class DateField:Field
	{
		private System.DateTime _value;
		public System.DateTime Value
		{
			get
			{
				return _value;
			}
			set
			{
				this.SetValue  = 1;
				_value = value;
			}
		}
		public System.DateTime OldValue;

		public DateField(string mfieldname, string fieldDesc):base(mfieldname, fieldDesc)
		{
			
		}

		public DateField(string mfieldname):base(mfieldname)
		{
			
		}

		public DateField()
		{
			this.SetValue = 0 ;
		}

		public string GetDisplayValue()
		{
			return this.DisplayValue ;
		}

		public RowStatus GetRowStatus()
		{
			return this.rowStatus;
		}

		/*获得该字段值的拼串,为Insert的Values服务*/
		public string GetInsertValues()
		{
			if ( this.SetValue == 0)
				return null ; 
			if (this._value.Equals(string.Empty))
				return null;
					
			return string.Format(" '{0}' " , this.Value.ToString() );
		}

		/*为Update的Set服务*/
		public string GetUpdateSet()
		{
			if (this.SetValue == 0 )
				return null;
			if (this._value.Equals(string.Empty))
				return null;
			return string.Format("{0} =  '{1}'",this.GetFieldName(),this.Value.ToString());
		}

		/*为Update的Where服务*/

		public string GetUpdateOrDeleteWhere()
		{
			
			if (this._value.Equals(string.Empty))
				return null;
			return string.Format(" {0} =  '{1}' ",this.GetFieldName(),this.Value.ToString());
		}
	}
}
