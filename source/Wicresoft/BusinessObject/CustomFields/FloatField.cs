using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for FloatField.
	/// </summary>
	public class FloatField:Field,FieldInterface
	{
			
		private System.Single _value;
		public System.Single Value
		{
			get
			{
				return _value ; 
			}
			set
			{
				this.SetValue = 1;
				_value = value;
			}
		}
		public System.Single OldValue;

		public FloatField(string mfieldname, string fieldDesc):base(mfieldname, fieldDesc)
		{
			this._value = 0;
			this.OldValue = 0;
		}

		public FloatField(string mfieldname):base(mfieldname)
		{
			this._value = 0;
			this.OldValue = 0;
		}

		public FloatField()
		{
			this._value = 0;
			this.OldValue = 0;
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
			if (this.SetValue ==0)
				return null;
			if (this._value.Equals(string.Empty))
				return null;
					
			return string.Format(" {0} " , this.Value );
		}

		/*ΪUpdate��Set����*/
		public string GetUpdateSet()
		{
			if (this.SetValue ==0)
				return null;
			if (this._value.Equals(string.Empty))
				return null;
			return string.Format(" {0} =  {1}",this.GetFieldName(),this.Value);
		}

		/*ΪUpdate��Where����*/

		public string GetUpdateOrDeleteWhere()
		{
			if (this._value.Equals(string.Empty))
				return null;
			return string.Format(" {0} =  {1}",this.GetFieldName(),this.Value);
		}
	}
}
