using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for DecimalField.
	/// </summary>
	public class DecimalField:Field,FieldInterface
	{

		private decimal _value;
		public decimal Value
		{
			get
			{
				return _value;
			}
			set
			{
				this.SetValue = 1 ;
				_value = value;
			}
		}
		public decimal OldValue;

		public DecimalField(string mfieldname, string fieldDesc):base(mfieldname, fieldDesc)
		{
			this._value = 0;
			this.OldValue = 0;
		}

		public DecimalField(string mfieldname):base(mfieldname)
		{
			this._value = 0;
			this.OldValue = 0;
		}

		public DecimalField()
		{
			this._value = 0;
			this.OldValue = 0;
			this.SetValue = 0;
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
			if (this.SetValue == 0 )
				return null;
			if (this._value.Equals(string.Empty))
				return null;
			
			return string.Format(" {0} " , this.Value );
		}

		/*为Update的Set服务*/
		public string GetUpdateSet()
		{
			if(this.SetValue == 0)
				return null;
			if (this._value.Equals(string.Empty))
				return null;
			return string.Format("{0} =  {1}",this.GetFieldName(),this.Value);
		}

		/*为Update的Where服务*/

		public string GetUpdateOrDeleteWhere()
		{
			if (this._value.Equals(string.Empty))
				return null;
			return string.Format(" {0} =  {1} ",this.GetFieldName(),this.Value);
		}
	}
}
