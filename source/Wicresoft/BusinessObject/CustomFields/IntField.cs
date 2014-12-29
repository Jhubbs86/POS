using System;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for IntField.
	/// </summary>
	public class IntField:Field,FieldInterface
	{
		private System.Int32 _value;
		public System.Int32 Value
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
		public System.Int32 OldValue;
//		public System.Boolean TrueOrFalse = false;
//
//		
//		public IntField(string mfieldname, string fieldDesc, bool TrueFalse):base(mfieldname, fieldDesc)
//		{
//			this._value = 0;
//			this.OldValue = 0;
//			this.TrueOrFalse = TrueFalse;
//		}

		public IntField(string mfieldname, string fieldDesc):base(mfieldname, fieldDesc)
		{
			this._value = 0;
			this.OldValue = 0;
		}

		public IntField(string mfieldname):base(mfieldname)
		{
			this._value = 0;
			this.OldValue = 0;
		}

		public IntField()
		{
			this._value = 0;
			this.OldValue = 0;
			this.SetValue = 0 ;
		}


		public string GetDisplayValue()
		{
			return this.DisplayValue ;
		}


		/// <summary>
		/// ����PKID��ȡ�������ڻ�ȡ�������
		/// </summary>
		/// <param name="objectName">���������</param>
		/// <returns></returns>
		public BusinessObject GetBusinessObject(string objectName)
		{
			BusinessFilter filter = new BusinessFilter(objectName);
			filter.AddFilterItem("PKID", this.Value.ToString(), Operation.Equal, FilterType.NumberType, AndOr.AND);
			
			BusinessObjectCollection boc = new BusinessObjectCollection(objectName);
			boc.AddFilter(filter);
			boc.SessionInstance = new Wicresoft.Session.Session();
			boc.Query();

			if(boc.Count > 0)
			{
				boc[0].HaveRecord = true;
				return boc[0];
			}
			return null;
		}

		public RowStatus GetRowStatus()
		{
			return this.rowStatus;
		}

		/*��ø��ֶ�ֵ��ƴ��,ΪInsert��Values����*/
		public string GetInsertValues()
		{
			if (this.SetValue == 0)
				return null;
			if (this._value.Equals(string.Empty))
				return null;
			
			return string.Format(" {0} " , this.Value );
		}

		/*ΪUpdate��Set����*/
		public string GetUpdateSet()
		{
			if(this.SetValue == 0)
				return null;
			if (this._value.Equals(string.Empty))
				return null;
//			if(this.TrueOrFalse == false)
//				return null;
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
