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
		/// View的描述文字，用于设置绑定该View的页面标题
		/// </summary>
		public string ViewDisplayName
		{
			get { return this.viewDisplayName; }
			set { this.viewDisplayName = value; }
		}
		private string viewDisplayName = "Default";


		/// <summary>
		/// 业务对象名
		/// </summary>
		public string BusinessObjectName
		{
			get { return this.businessObjectName; }
			set { this.businessObjectName = value; }
		}
		private string businessObjectName = string.Empty;


		/// <summary>
		/// 主键列
		/// </summary>
		public ViewItem PKField
		{
			get { return this.pkField; }
			set { SetValidPKIDField(value); }
		}
		private ViewItem pkField = null;

		/// <summary>
		/// 显示列
		/// </summary>
		public ViewItem DisplayField
		{
			get { return this.displayField; }
			set	{ SetValidDisplayField(value); }
		}
		private ViewItem displayField = null;


		/// <summary>
		/// 所有需要显示的列的集合
		/// </summary>
		public ViewItemCollection VisibleColumnCollection
		{
			get { return GetVisibleColumnCollection(); }
			set { SetVisibleColumnCollection(value); }
		}
		private ViewItemCollection visibleColumnCollection = new ViewItemCollection();


		/// <summary>
		/// View所绑定的对象
		/// </summary>
		public BusinessObject BusinessObject
		{
			get { return GetBindingObject(); }
		}
		private BusinessObject bindingObject = null;


		/// <summary>
		/// 视图所包含的记录集
		/// </summary>
		public System.Data.DataTable tblSchema;


		/// <summary>
		/// 获取Filter对象，将影响取得的结果集
		/// </summary>
		public BusinessFilter CurrentFilter = null;


		/// <summary>
		/// 初始化过滤用
		/// </summary>
		public BusinessFilter InitialFilter = null;
		#endregion

		#region Public Methods
		/// <summary>
		/// 根据页码、页大小，获取数据，填充视图
		/// </summary>
		/// <param name="pageNumber">页码（1开始）</param>
		/// <param name="pageSize">页大小</param>
		/// <returns>记录总条数</returns>
		public abstract int LoadData(int pageNumber, int pageSize);


		/// <summary>
		/// 通过主键值，获取用于显示的字段值
		/// </summary>
		/// <param name="pkid">主键值</param>
		/// <returns></returns>
		/// <remarks>主要用于设置SelectedValue后，自动带出SelectedText</remarks>
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

				// PKID列作为该集合的第一个列
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

				// DisplayField列作为该集合的第二个列
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
					// 有些表的外键可能未确定，没有ForeignKeyAttribute
					// 例如BusinessReceiptData表，FK_Project可能是每日工作汇报或者不定期市场调查
					// 由于外键表不确定，所以FKFieldName不赋值
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

        /* Justin Modify 2014-02-19 增加日期显示方式  */
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
		/// 字段名
		/// </summary>
		public string FieldName
		{
			get{ return this.fieldName; }
			set{ this.fieldName = value; }
		}
		private string fieldName = string.Empty;

		/// <summary>
		/// 字段类型[IntField\StringField\BoolField]
		/// </summary>
		/// <remarks>Andy Add 2009-01-21 性能优化</remarks>
		public string FieldType
		{
			get{ return this.fieldType; }
			set{ this.fieldType = value; }
		}
		private string fieldType = string.Empty;

		/// <summary>
		/// 外键字段名
		/// </summary>
		public string FKFieldName
		{
			get { return this.fkFieldName; }
			set { this.fkFieldName = value; }
		}
		private string fkFieldName = string.Empty;


		/// <summary>
		/// 外键所对应表的Default View名称
		/// </summary>
		public string FKDefaultViewName
		{
			get 
			{ 
				//				if(this.hasFilter && this.fkDefaultViewName == string.Empty)
				//					throw new Exception(string.Format("外键{0}缺少默认视图！", this.fkFieldName));
				return this.fkDefaultViewName; 
			}
			set { this.fkDefaultViewName = value; }
		}
		private string fkDefaultViewName = string.Empty;

		
		/// <summary>
		/// 树形对象的名称
		/// </summary>
		public string TreeObjectName
		{
			get { return this.treeObjectName; }
			set { this.treeObjectName = value; }
		}
		private string treeObjectName = string.Empty;

		/// <summary>
		/// 显示的文字
		/// </summary>
		public string DisplayName
		{
			get{ return this.displayName; }
			set{ this.displayName = value; }
		}
		private string displayName = string.Empty;


		/// <summary>
		/// 字段类型
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
		/// 是否作为查询条件
		/// </summary>
		public bool HasFilter
		{
			get { return this.hasFilter; }
			set { this.hasFilter = value; }
		}
		private bool hasFilter = false;

        /// <summary>
        /// 日期显示方式，0代表不显示时分秒，1代表显示时分秒
        /// </summary>
        public int DateType
        {
            get { return this.dateType; }
            set { this.dateType = value; }
        }
        private int dateType = 0;

		
		/// <summary>
		/// 是否模糊查询
		/// </summary>
		/// <remarks>Andy Add 2008-11-21</remarks>
		private bool fuzzyEnquiry = false;
		public bool FuzzyEnquiry
		{
			get { return this.fuzzyEnquiry; }
			set { this.fuzzyEnquiry = value; }
		}

		/// <summary>
		/// 是否已经被检验过
		/// </summary>
		private bool hasValidated = false;
		public bool HasValidated
		{
			get { return this.hasValidated; }
			set { this.hasValidated = value; }
		}

		/// <summary>
		/// 是否是虚拟字段
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
