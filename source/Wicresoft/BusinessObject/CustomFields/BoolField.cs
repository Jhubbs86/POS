using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for BoolField.
	/// </summary>
	public class BoolField:Field
	{
		
		private bool _value;
		public bool Value
		{
			get
			{
				return _value;
			}
			set
			{
				this.SetValue = 1 ;
				_value = value ;
			}
		}
		public bool OldValue;

		public BoolField(string mfieldname, string fieldDesc):base(mfieldname, fieldDesc)
		{
			this._value = false;
			this.OldValue = false;
		}

		public BoolField(string mfieldname):base(mfieldname)
		{
			this._value = false;
			this.OldValue = false;
		}

		public BoolField()
		{
			this.Value = false;
			this.OldValue = false;
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
			if (this.SetValue ==0)
				return null;
			if (this._value.Equals(string.Empty))
			return null;
					
			return string.Format(" {0} " ,Convert.ToInt32(this.Value) );
		}

		/*为Update的Set服务*/
		public string GetUpdateSet()
		{
			if (this.SetValue == 0)
				return null;
			if (this._value.Equals(string.Empty))
				return null;
			return string.Format("{0} =  {1}",this.GetFieldName(),Convert.ToInt32(this.Value));
		}

		/*为Update的Where服务*/

		public string GetUpdateOrDeleteWhere()
		{
			if (this._value.Equals(string.Empty))
				return null;
			return string.Format(" {0} =  {1} ",this.GetFieldName(),Convert.ToInt32(this.Value));
		}
	}
}
