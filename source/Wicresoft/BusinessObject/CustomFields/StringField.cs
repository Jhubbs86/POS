using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for StringField.
	/// </summary>
	public class StringField:Field,FieldInterface
	{
		private string _value;
		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				this.SetValue = 1;
				_value = value;
			}
		}
		public string OldValue;

		public StringField(string mfieldname, string fieldDesc):base(mfieldname, fieldDesc)
		{
			this._value = null;
			this.OldValue =	null;
		}

		public StringField(string mfieldname):base(mfieldname)
		{
			this._value = null;
			this.OldValue =	null;
		}

		public StringField()
		{
			this._value = null;
			this.OldValue = null;
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
			if(this.SetValue ==0)
				return null;
			if (this._value == null)
				return null;
			
			return string.Format(" '{0}' " , this.Value.Replace("'", "''") );	// 2006-2-13	Tony
		}

		/*ΪUpdate��Set����*/
		public string GetUpdateSet()
		{
			if (this.SetValue ==0)
				return null;
			if (this._value == null)
				return null;
			return string.Format(" {0} =  '{1}' ",this.GetFieldName(),this.Value.Replace( "'", "''" ));//2005-10-19 ���� ' ��Ϊ '' jacky
		}

		/*ΪUpdate��Where����*/

		public string GetUpdateOrDeleteWhere()
		{
			if (this._value == null)
				return null;
			return string.Format(" {0} =  '{1}' ",this.GetFieldName(),this.Value);
		}
	}
}
