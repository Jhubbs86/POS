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

		/*��ø��ֶ�ֵ��ƴ��,ΪInsert��Values����*/
		public string GetInsertValues()
		{
			if ( this.SetValue == 0)
				return null ; 
			if (this._value.Equals(string.Empty))
				return null;
					
			return string.Format(" '{0}' " , this.Value.ToString() );
		}

		/*ΪUpdate��Set����*/
		public string GetUpdateSet()
		{
			if (this.SetValue == 0 )
				return null;
			if (this._value.Equals(string.Empty))
				return null;
			return string.Format("{0} =  '{1}'",this.GetFieldName(),this.Value.ToString());
		}

		/*ΪUpdate��Where����*/

		public string GetUpdateOrDeleteWhere()
		{
			
			if (this._value.Equals(string.Empty))
				return null;
			return string.Format(" {0} =  '{1}' ",this.GetFieldName(),this.Value.ToString());
		}
	}
}
