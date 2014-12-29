using System;
using System.Reflection;
using System.Collections;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Abstract class for BusinessObjectView
	/// </summary>
	/// <author>
	/// Tony Zhang
	/// </author>
	/// <date>
	/// 2006-3-14
	/// </date>
	public abstract class BusinessObjectView
	{
		#region Constructor
		public BusinessObjectView()
		{
		}

		public BusinessObjectView(string objectName, string displayName)
		{
			this.businessObjectName = objectName;
			this.viewDisplayName = displayName;
		}
		#endregion

		#region Properties & Fields
		/// <summary>
		/// View���������֣��������ð󶨸�View��ҳ�����
		/// </summary>
		public string ViewDisplayName
		{
			get { return this.viewDisplayName; }
			set { this.viewDisplayName = value; }
		}
		private string viewDisplayName = "Default";


		/// <summary>
		/// ҵ�������
		/// </summary>
		public string BusinessObjectName
		{
			get { return this.businessObjectName; }
			set { this.businessObjectName = value; }
		}
		private string businessObjectName = string.Empty;


		/// <summary>
		/// ������
		/// </summary>
		public ViewItem PKField
		{
			get { return this.pkField; }
			set { SetValidPKIDField(value); }
		}
		private ViewItem pkField = null;

		/// <summary>
		/// ��ʾ��
		/// </summary>
		public ViewItem DisplayField
		{
			get { return this.displayField; }
			set	{ SetValidDisplayField(value); }
		}
		private ViewItem displayField = null;


		/// <summary>
		/// ������Ҫ��ʾ���еļ���
		/// </summary>
		public ViewItemCollection VisibleColumnCollection
		{
			get { return GetVisibleColumnCollection(); }
			set { SetVisibleColumnCollection(value); }
		}
		private ViewItemCollection visibleColumnCollection = new ViewItemCollection();


		/// <summary>
		/// View���󶨵Ķ���
		/// </summary>
		public BusinessObject BusinessObject
		{
			get { return GetBindingObject(); }
		}
		private BusinessObject bindingObject = null;


		/// <summary>
		/// ��ͼ�������ļ�¼��
		/// </summary>
		public System.Data.DataTable tblSchema;


		/// <summary>
		/// ��ȡFilter���󣬽�Ӱ��ȡ�õĽ����
		/// </summary>
		public BusinessFilter CurrentFilter = null;


		/// <summary>
		/// ��ʼ��������
		/// </summary>
		public BusinessFilter InitialFilter = null;
		#endregion

		#region Public Methods
		/// <summary>
		/// ����ҳ�롢ҳ��С����ȡ���ݣ������ͼ
		/// </summary>
		/// <param name="pageNumber">ҳ�루1��ʼ��</param>
		/// <param name="pageSize">ҳ��С</param>
		/// <returns>��¼������</returns>
		public abstract int LoadData(int pageNumber, int pageSize);


		/// <summary>
		/// ͨ������ֵ����ȡ������ʾ���ֶ�ֵ
		/// </summary>
		/// <param name="pkid">����ֵ</param>
		/// <returns></returns>
		/// <remarks>��Ҫ��������SelectedValue���Զ�����SelectedText</remarks>
		public string GetDisplayValueFromPKID(string pkid)
		{
			if(pkid == null || pkid == string.Empty)
				pkid = "-1";

			BusinessFilter filter = new BusinessFilter(this.BusinessObjectName);
			filter.AddFilterItem(this.PKField.FieldName, pkid, Operation.Equal, FilterType.NumberType, AndOr.AND);
			
			this.BusinessObject.SessionInstance = new Wicresoft.Session.Session();
			this.BusinessObject.ClearFilter();
			this.BusinessObject.AddFilter(filter);
			this.BusinessObject.Load();

			if(this.BusinessObject.HaveRecord)
			{
				FieldInfo fldInfo = this.BusinessObject.GetType().GetField(this.DisplayField.FieldName);
				Field field = fldInfo.GetValue(this.BusinessObject) as Field;
				PropertyInfo proInfo = fldInfo.FieldType.GetProperty("Value");

				return proInfo.GetValue(field, null).ToString();
			}
			return string.Empty;
		}


		/// <summary>
		/// Test Version 2006-5-17 Tony Zhang
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public BusinessObject GetBindingObject(string key, string value)
		{
			BusinessFilter filter = new BusinessFilter(this.BusinessObjectName);
			filter.AddFilterItem(key, value, Operation.Equal, FilterType.StringType, AndOr.AND);
			
			this.BusinessObject.SessionInstance = new Wicresoft.Session.Session();
			this.BusinessObject.ClearFilter();
			this.BusinessObject.AddFilter(filter);
			this.BusinessObject.Load();

			return (this.BusinessObject.HaveRecord)?this.BusinessObject:null;
		}
		#endregion

		#region Private Methods
		private void SetValidPKIDField(ViewItem vi)
		{
			if(this.IsPKIDField(vi))
			{
				this.pkField = vi;

				// PKID����Ϊ�ü��ϵĵ�һ����
				this.visibleColumnCollection.Insert(0, vi);
			}
			else
				throw new Exception("Invalid PK Field!");
		}


		private void SetValidDisplayField(ViewItem vi)
		{
			if(this.IsValidField(vi))
			{
				this.displayField = vi;

				// DisplayField����Ϊ�ü��ϵĵڶ�����
				this.visibleColumnCollection.Insert(1, vi);
			}
			else
				throw new Exception("Invalid Display Field");
		}


		private ViewItemCollection GetVisibleColumnCollection()
		{
			DoValidation();
			return this.visibleColumnCollection; 
		}


		private void SetVisibleColumnCollection(ViewItemCollection vic)
		{
			if(IsEmptyVisibleColumnCollection())
				this.visibleColumnCollection = vic;
			else
				MergeVisibleColumnCollection(vic);
		}


		private bool IsEmptyVisibleColumnCollection()
		{
			return this.visibleColumnCollection.Count == 0;
		}


		private void MergeVisibleColumnCollection(ViewItemCollection vic)
		{
			for(int i = 0; i < vic.Count; i++)
			{
				if(! this.visibleColumnCollection.Contains(vic[i]))
					this.visibleColumnCollection.Add(vic[i]);
			}
		}


		private BusinessObject GetBindingObject()
		{
			if(this.bindingObject == null) 
			{
				if(CannotFindBusinessObject())
					throw new Exception("Invalid BusinessObject Name!");
			}
			return this.bindingObject;
		}


		private bool CannotFindBusinessObject()
		{
			return (this.bindingObject = GetBusinessObjectByName(this.businessObjectName)) == null;
		}


		private BusinessObject GetBusinessObjectByName(string objectName)
		{
			if(objectName != string.Empty)
			{
				return (BusinessObject)Global.GetBusinessLogicAssembly().CreateInstance(
					Configuration.GetKeyValue(Configuration.BusinessLogic) + "." + objectName);
			}
			else
			{
				throw new Exception("Need BusinessObject Name!");
			}
		}


		private void DoValidation()
		{
			ViewItemCollection vic = new ViewItemCollection();

			for(int i = 0; i < this.visibleColumnCollection.Count; i++)
			{
				if(vic.Contains(visibleColumnCollection[i]))
					continue;

				if(IsValidField(visibleColumnCollection[i]))
				{
					ReflectFieldType(visibleColumnCollection[i], vic);
				}
			}
			this.visibleColumnCollection = vic;
		}


		private void ReflectFieldType(ViewItem vi, ViewItemCollection vic)
		{
			if(! vi.HasValidated)
			{
				if(vi.IsVirtual)
					HandleOtherField(vi);
				else
				{
					switch(this.BusinessObject.GetType().GetField(vi.FieldName).FieldType.Name)
					{
						case "BoolField":
							vi.SetFieldType(ViewItemDisplayType.CheckBox);
							break;
						case "DateField":
							vi.SetFieldType(ViewItemDisplayType.DateTime);
							break;
						default:
							HandleOtherField(vi);
							break;
					}
				}
				vi.HasValidated = true;
			}
            
			vic.Add(vi);
		}

		private void HandleOtherField(ViewItem vi)
		{
			// Check FK
			if(vi.IsVirtual)
			{
				//				vi.SetFieldType(ViewItemDisplayType.SingleObject);
				//				vi.FKFieldName = vi.FieldName;
			}
			else
			{
				object[]  fks = this.BusinessObject.GetType().GetField(vi.FieldName).GetCustomAttributes(typeof(ForeignKeyAttribute), false);
				if(fks.Length > 0)
				{
					if((fks as ForeignKeyAttribute[])[0].TableName == "Dictionary" && vi.TreeObjectName != string.Empty)
					{
						// Use TreePicker
						vi.SetFieldType(ViewItemDisplayType.TreeObject);
						vi.FKFieldName = (fks as ForeignKeyAttribute[])[0].MappingName;
					}
					else
					{
						// Use GridPicker
						vi.SetFieldType(ViewItemDisplayType.SingleObject);
						vi.FKFieldName = (fks as ForeignKeyAttribute[])[0].MappingName;
					}
				}
				else
				{
					// ��Щ����������δȷ����û��ForeignKeyAttribute
					// ����BusinessReceiptData��FK_Project������ÿ�չ����㱨���߲������г�����
					// ���������ȷ��������FKFieldName����ֵ
					// 2006-5-17 Tony Zhang
					if(vi.FKDefaultViewName != string.Empty)
					{
						// Use GridPicker
						vi.SetFieldType(ViewItemDisplayType.SingleObject);
						vi.FKFieldName = string.Empty;
					}
					else
						vi.SetFieldType(ViewItemDisplayType.Literal);
				}
			}
		}


		private bool IsValidField(ViewItem vi)
		{
			return (vi.IsVirtual || this.BusinessObject.GetType().GetField(vi.FieldName) != null);
		}


		private bool IsPKIDField(ViewItem vi)
		{
			if(this.IsValidField(vi))
				return this.BusinessObject.GetType().GetField(vi.FieldName).IsDefined(typeof(PrimaryKeyAttribute), false);
			else
				throw new Exception("Invalid PKID Field Name!");
		}
		#endregion
	}

	
	/// <summary>
	/// Describe the ViewItem's display type
	/// </summary>
	/// <author>
	/// Tony Zhang
	/// </author>
	/// <date>
	/// 2006-3-14
	/// </date>
	public enum ViewItemDisplayType
	{
		/// <summary>
		/// In DataGrid, it will be shown as text.
		/// In QueryProvider, it will be shown as textbox.
		/// </summary>
		Literal,
		/// <summary>
		/// In DataGrid/QueryProvider, it will be shown as checkbox.
		/// </summary>
		CheckBox,
		/// <summary>
		/// In DataGrid, it will be shown as formated text(yyyy-mm-dd).
		/// In QueryProvider, it will be shown as two DatePicker
		/// </summary>
		DateTime,
		/// <summary>
		/// In DataGrid, it will be shown as text.
		/// In QueryProvider, it will be shown as GridPicker.
		/// </summary>
		SingleObject,
		/// <summary>
		/// In DataGrid, it will be shown as text.
		/// In QueryProvider, it will be shown as TreePicker.
		/// </summary>
		TreeObject
	}


	/// <summary>
	/// Describe a field in the BusinessObjectView
	/// </summary>
	/// <remarks>
	/// Equal() & GetHashCode() have been overrided
	/// </remarks>
	/// <author>
	/// Tony Zhang
	/// </author>
	/// <date>
	/// 2006-3-14
	/// </date>
	public class ViewItem
	{
		#region Constructor
		public ViewItem()
		{
		}
		public ViewItem(string fieldName, string displayName)
		{
			this.fieldName = fieldName;
			this.displayName = displayName;
		}

		public ViewItem(string fieldName, string displayName, bool hasFilter)
		{
			this.fieldName = fieldName;
			this.displayName = displayName;
			this.hasFilter = hasFilter;
		}

        /* Justin Modify 2014-02-19 ����������ʾ��ʽ  */
        public ViewItem(string fieldName, string displayName, bool hasFilter, int dateType)
        {
            this.fieldName = fieldName;
            this.displayName = displayName;
            this.hasFilter = hasFilter;
            this.dateType = dateType;
        }

		public ViewItem(string fieldName, string displayName, string treeObjectName, bool hasFilter)
		{
			this.fieldName = fieldName;
			this.displayName = displayName;
			this.treeObjectName = treeObjectName;
			this.hasFilter = hasFilter;
		}

		public ViewItem(string fieldName, string displayName, bool hasFilter, string fkViewName)
		{
			this.fieldName = fieldName;
			this.DisplayName = displayName;
			this.fkDefaultViewName = fkViewName;
			this.hasFilter = hasFilter;
		}

		// Andy Add 2008-11-21		
		public ViewItem(string fieldName, string displayName, bool hasFilter, bool fuzzyEnquiry)
		{
			this.fieldName = fieldName;
			this.displayName = displayName;
			this.hasFilter = hasFilter;
			this.fuzzyEnquiry = fuzzyEnquiry;
		}
		#endregion

		#region Properties & Fields
		/// <summary>
		/// �ֶ���
		/// </summary>
		public string FieldName
		{
			get{ return this.fieldName; }
			set{ this.fieldName = value; }
		}
		private string fieldName = string.Empty;

		/// <summary>
		/// �ֶ�����[IntField\StringField\BoolField]
		/// </summary>
		/// <remarks>Andy Add 2009-01-21 �����Ż�</remarks>
		public string FieldType
		{
			get{ return this.fieldType; }
			set{ this.fieldType = value; }
		}
		private string fieldType = string.Empty;

		/// <summary>
		/// ����ֶ���
		/// </summary>
		public string FKFieldName
		{
			get { return this.fkFieldName; }
			set { this.fkFieldName = value; }
		}
		private string fkFieldName = string.Empty;


		/// <summary>
		/// �������Ӧ���Default View����
		/// </summary>
		public string FKDefaultViewName
		{
			get 
			{ 
				//				if(this.hasFilter && this.fkDefaultViewName == string.Empty)
				//					throw new Exception(string.Format("���{0}ȱ��Ĭ����ͼ��", this.fkFieldName));
				return this.fkDefaultViewName; 
			}
			set { this.fkDefaultViewName = value; }
		}
		private string fkDefaultViewName = string.Empty;

		
		/// <summary>
		/// ���ζ��������
		/// </summary>
		public string TreeObjectName
		{
			get { return this.treeObjectName; }
			set { this.treeObjectName = value; }
		}
		private string treeObjectName = string.Empty;

		/// <summary>
		/// ��ʾ������
		/// </summary>
		public string DisplayName
		{
			get{ return this.displayName; }
			set{ this.displayName = value; }
		}
		private string displayName = string.Empty;


		/// <summary>
		/// �ֶ�����
		/// </summary>
		public ViewItemDisplayType DisplayType
		{
			get{ return this.displayType; }
			set { this.displayType = value; }
		}
		private ViewItemDisplayType displayType;
		internal void SetFieldType(ViewItemDisplayType displayType)
		{
			this.displayType = displayType;
		}


		/// <summary>
		/// �Ƿ���Ϊ��ѯ����
		/// </summary>
		public bool HasFilter
		{
			get { return this.hasFilter; }
			set { this.hasFilter = value; }
		}
		private bool hasFilter = false;

        /// <summary>
        /// ������ʾ��ʽ��0������ʾʱ���룬1������ʾʱ����
        /// </summary>
        public int DateType
        {
            get { return this.dateType; }
            set { this.dateType = value; }
        }
        private int dateType = 0;

		
		/// <summary>
		/// �Ƿ�ģ����ѯ
		/// </summary>
		/// <remarks>Andy Add 2008-11-21</remarks>
		private bool fuzzyEnquiry = false;
		public bool FuzzyEnquiry
		{
			get { return this.fuzzyEnquiry; }
			set { this.fuzzyEnquiry = value; }
		}

		/// <summary>
		/// �Ƿ��Ѿ��������
		/// </summary>
		private bool hasValidated = false;
		public bool HasValidated
		{
			get { return this.hasValidated; }
			set { this.hasValidated = value; }
		}

		/// <summary>
		/// �Ƿ��������ֶ�
		/// </summary>
		private bool isVirtual = false;
		public bool IsVirtual
		{
			get { return this.isVirtual; }
			set { this.isVirtual = value; }
		}
		#endregion

		#region Override Methods
		public override bool Equals(object obj)
		{
			if(object.ReferenceEquals(this, obj))
				return true;
			else
			{
				ViewItem vi = obj as ViewItem;
				if(vi == null)
					return false;

				return this.fieldName == vi.fieldName;
			}
		}


		public override int GetHashCode()
		{
			return this.fieldName.GetHashCode();
		}
		#endregion
	}


	/// <summary>
	/// Describe a collection which contain ViewItem objects
	/// </summary>
	/// <author>
	/// Tony Zhang
	/// </author>
	/// <date>
	/// 2006-3-14
	/// </date>
	public class ViewItemCollection: System.Collections.CollectionBase
	{
		public ViewItemCollection()
		{}

		public void Add(ViewItem vi)
		{
			this.List.Add(vi);
		}

		public void Remove(ViewItem vi)
		{
			if(this.List.Contains(vi))
				this.List.Remove(vi);
		}

		public void Insert(int index, ViewItem vi)
		{
			if(this.List.Contains(vi))
				this.List.Remove(vi);
			this.List.Insert(index, vi);
		}

		public bool Contains(ViewItem vi)
		{
			return this.List.Contains(vi);
		}

		public ViewItem this[int index]
		{
			get{ return this.List[index] as ViewItem; }
			set{ this.List[index] = value; }
		}

		public ViewItem this[string fieldName]
		{
			get
			{
				int index = this.IndexOf(new ViewItem(fieldName, fieldName));
				if(index >= 0 && index < this.List.Count)
					return this.List[index] as ViewItem;
				else
					return null;
			}
		}

		protected int IndexOf(ViewItem vi)
		{
			return this.List.IndexOf(vi);
		}
	}
}
