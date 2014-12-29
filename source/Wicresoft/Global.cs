using System;
using System.Collections;
using System.Reflection;

using Wicresoft.BusinessObject;

namespace Wicresoft
{
	/// <summary>
	/// Summary description for Grobal.
	/// </summary>
	public class Global
	{
//		public static BusinessObjectCollection CreateObjectCollection(string Object)
//		{
//			return new BusinessObjectCollection(Object);
//		}
//
		private static Assembly assembly = null;
		public static Assembly GetBusinessLogicAssembly()
		{
			string ExecutePath ; 
			ExecutePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
			ExecutePath =ExecutePath +"\\"+ Configuration.GetKeyValue(Configuration.BusinessLogic)+".dll";
			ExecutePath = ExecutePath.Substring(6);
			return (assembly == null)?Assembly.LoadFrom(ExecutePath):assembly;
		}

		public static bool IsFieldExists(string objectName, string fieldName)
		{
			Type type = GetBusinessLogicAssembly().CreateInstance(Configuration.GetKeyValue(Configuration.BusinessLogic) + "." + objectName).GetType();
			return (type.GetMember(fieldName) != null);
		}
//
//		public static BusinessObject CreateObject(string Object)
//		{
//			
//		}
//		private string companycode;
//		public string CompanyCode
//		{
//			get
//			{
//				return companycode; 
//			}
//			set
//			{
//				companycode = value;
//			}
//		}
//
//		private string configureDBstring;
//		public string ConfigureDBString
//		{
//			get
//			{
//				return configureDBstring;
//			}
//			set
//			{
//				configureDBstring = value;
//			}
//		}
//
//		private string businessDBstring;
//		public string BusinessDBString
//		{
//			get
//			{
//				return businessDBstring;
//			}
//			set
//			{
//				businessDBstring = value;
//			}
//		}

//		private static System.Collections.Hashtable Companys = new Hashtable();
//
//		public static void AddCompany(string company,string businessconnection)
//		{
//			if (Companys.ContainsKey(company))
//			{
//				Companys[company] = businessconnection;
//			}
//			Companys.Add(company,businessconnection);
//		}
//
//		public static string  GetConnectionString()
//		{
//			string company = GetCurrentCompany();
//			if (Companys.ContainsKey(company))
//				return Companys[company].ToString();
//			else
//				return null;
//		}
//		public static string GetCurrentCompany()
//		{
//			return null;
//		}


		
//
//
	}
}
