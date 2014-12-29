using System;
using System.Reflection;

namespace Wicresoft.BusinessObject
{
	/// <summary>
	/// Summary description for Filter.
	/// </summary>
	public class BusinessFilter
	{
		private string businessobject;
		

		public string Object
		{
			get { return businessobject ; }
			set { businessobject = value ; }
		}


		#region constructor
		public  BusinessFilter(string Object)
		{
			filter = string.Empty;
//			System.Reflection.Assembly assembly = Assembly.LoadFrom(Configuration.GetKeyValue(Configuration.BusinessLogic)+".dll");
			
			BusinessObject Businessobject = (BusinessObject)Global.GetBusinessLogicAssembly().CreateInstance(Configuration.GetKeyValue(Configuration.BusinessLogic)+"."+Object);
			businessobject = Businessobject.TableName;		
		}
		#endregion
		
		#region filter
		private string filter;
		public string Filter
		{
			get{ return filter; }
		}

		private string customFilter = string.Empty;
		public string CustomFilter
		{
			get { return this.customFilter; }
			set { this.customFilter = value; }
		}
		#endregion

		#region AddFilterItem
		public void AddFilterItem(string field,string Value,string operation,FilterType filterType,AndOr andor)
		{
			if (filterType == FilterType.StringType)
			{
				if (operation.ToLower().Trim().IndexOf("like") == -1)
				{
					if (!filter.Equals(string.Empty))
					{
						filter = filter + string.Format(" {0} {1}.{2}  {3} '{4}'",andor.ToString(),businessobject,field,operation.ToString(),Value);
					}
					else
					{
						filter =" " + andor.ToString()  +  " ( " +string.Format(" {0}.{1} {2} '{3}' ",businessobject,field,operation.ToString(),Value);
					}
				}
				else if(operation.ToLower().Trim() == "like") /* Andy Modify 2008-12-30 性能优化 */
				{
					if (!filter.Equals(string.Empty))
					{
						filter = filter + string.Format(" {0}  {1}.{2}  {3}  '%{4}%' ",andor.ToString(),businessobject,field,Operation.Like,Value);
					}
					else
					{
						filter = " " + andor.ToString()  +  " (" +string.Format(" {0}.{1}   {2}  '%{3}%'  ",businessobject,field,Operation.Like,Value);
					}
				}


//					/* Andy Modify 2008-07-30 只有Mobile、TelePhone、ChineseName、EnglishName用前匹配模糊查询 */
//					if(operation.ToLower().Trim() == "like")
//					{
//						if(this.businessobject.ToLower() == "client")
//						{
//							if( field.ToLower().Trim().IndexOf("mobile") == -1 && 
//								field.ToLower().Trim().IndexOf("telephone") == -1 && 
//								field.ToLower().Trim().IndexOf("chinesename") == -1 && 
//								field.ToLower().Trim().IndexOf("englishname") == -1)
//							{
//								if (!filter.Equals(string.Empty))
//								{
//									filter = filter + string.Format(" {0}  {1}.{2}  {3}  '%{4}%' ",andor.ToString(),businessobject,field,Operation.Like,Value);
//								}
//								else
//								{
//									filter = " " + andor.ToString()  +  " (" +string.Format(" {0}.{1}   {2}  '%{3}%'  ",businessobject,field,Operation.Like,Value);
//								}
//							}
//							else
//							{
//								if (!filter.Equals(string.Empty))
//								{
//									filter = filter + string.Format(" {0}  {1}.{2}  {3}  '{4}%' ",andor.ToString(),businessobject,field,Operation.Like,Value);
//								}
//								else
//								{
//									filter = " " + andor.ToString()  +  " (" +string.Format(" {0}.{1}   {2}  '{3}%'  ",businessobject,field,Operation.Like,Value);
//								}
//							}
//						}
//						else
//						{
//							if (!filter.Equals(string.Empty))
//							{
//								filter = filter + string.Format(" {0}  {1}.{2}  {3}  '%{4}%' ",andor.ToString(),businessobject,field,Operation.Like,Value);
//							}
//							else
//							{
//								filter = " " + andor.ToString()  +  " (" +string.Format(" {0}.{1}   {2}  '%{3}%'  ",businessobject,field,Operation.Like,Value);
//							}
//						}
//					}


//					if(operation.ToLower().Trim() == "like")
//					{
//
//						if (!filter.Equals(string.Empty))
//						{
//							//							/* Andy Modify 2008-07-25 */
//							//							filter = filter + string.Format(" {0}  {1}.{2}  {3}  '{4}%' ",andor.ToString(),businessobject,field,operation.ToString(),Value);
//							filter = filter + string.Format(" {0}  {1}.{2}  {3}  '%{4}%' ",andor.ToString(),businessobject,field,Operation.Like,Value);
//						}
//						else
//						{
//							//							/* Andy Modify 2008-07-25 */
//							//							filter = " " + andor.ToString()  +  " (" +string.Format(" {0}.{1}   {2}  '{3}%'  ",businessobject,field,operation.ToString(),Value);
//							filter = " " + andor.ToString()  +  " (" +string.Format(" {0}.{1}   {2}  '%{3}%'  ",businessobject,field,Operation.Like,Value);
//						}
//					}
//					else if(operation.ToLower().Trim() == "leftlike")
//					{
//						if (!filter.Equals(string.Empty))
//						{
//							/* Andy Modify 2008-07-25 */
//							filter = filter + string.Format(" {0}  {1}.{2}  {3}  '%{4}' ",andor.ToString(),businessobject,field,Operation.LeftLike,Value);
//						}
//						else
//						{
//							/* Andy Modify 2008-07-25 */
//							filter = " " + andor.ToString()  +  " (" +string.Format(" {0}.{1}   {2}  '%{3}'  ",businessobject,field,Operation.LeftLike,Value);
//						}
//					}
//					else if(operation.ToLower().Trim() == "rightlike")
//					{
//						if (!filter.Equals(string.Empty))
//						{
//							/* Andy Modify 2008-07-25 */
//							filter = filter + string.Format(" {0}  {1}.{2}  {3}  '{4}%' ",andor.ToString(),businessobject,field,Operation.RightLike,Value);
//						}
//						else
//						{
//							/* Andy Modify 2008-07-25 */
//							filter = " " + andor.ToString()  +  " (" +string.Format(" {0}.{1}   {2}  '{3}%'  ",businessobject,field,Operation.RightLike,Value);
//						}
//					}
			}
			else if (filterType == FilterType.NumberType)
			{
				if (!filter.Equals(string.Empty))
				{
					filter = filter + string.Format(" {0}  {1}.{2} {3} {4}  ",andor.ToString(),businessobject,field,operation.ToString(),Value);
				}
				else
				{
					filter =  " " + andor.ToString()  +  " (" +string.Format("{0}.{1} {2} {3} ",businessobject,field,operation.ToString(),Value);
				}
			}
		}
		#endregion 

		#region AddFilter
		public void AddFilter(BusinessFilter _filter,AndOr andor)
		{
			string strfilter;


			if (_filter == null || _filter.Filter == null || _filter.Filter.Equals(string.Empty))
				return ;

			strfilter = _filter.Filter.Trim();

			if (strfilter.IndexOf(AndOr.AND.ToString(),0,strfilter.Length) == 0)
				strfilter = strfilter.Substring(4,strfilter.Length - 4);
			else
				strfilter = strfilter.Substring(3,strfilter.Length - 3);

			if (this.filter == null ||this.filter.Equals(string.Empty))
			{
				this.filter = string.Format(" {0}   ( {1} ) ",andor.ToString(),strfilter);
			}
			else
			{
				this.filter = string.Format("{0} {1} {2} )",this.filter,andor.ToString(),strfilter);
			}
		}
		#endregion

		#region AddCustomerFilter
		public void AddCustomerFilter(string where ,AndOr andor)
		{
			if (where.Equals(string.Empty))
				return ;
			if (filter.Equals(string.Empty))
			{
				this.filter = string.Format("{0} ({1} " ,andor.ToString(),where) ;
			}
			else
			{
				this.filter = string.Format("{0} {1}  {2} ",this.filter,andor.ToString(),where);
			}
		}
		#endregion

	}
}
