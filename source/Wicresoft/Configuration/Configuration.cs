using System;
using System.Collections;
using System.Xml;

namespace Wicresoft
{
	/// <summary>
	/// Summary description for Const.
	/// </summary>
	public class Configuration
	{
		#region "系统配置键值"


		public const string Connectionstring = "DBConfigure/Connectionstring";
		public const string DBFactory = "DBConfigure/DBFactory";
		public const string Resource = "ResourceManage/Resource";
		public const string Language = "ResourceManage/Language";
		public const string BusinessLogic = "DBConfigure/BusinessLogic";
		#endregion

		#region 系统配置值
		public static string ConnectionStringValue	= string.Empty ;
		public static string DBFactoryValue = string.Empty ;
		public static string ResourceValue	= string.Empty ; 
		public static string LanguageValue	= string.Empty ;
		public static string BusinessLogicValue	= "BusinessMapping" ;
		#endregion


		public static string GetKeyValue(string Key)
		{
			
			switch(Key)
			{
				case Connectionstring :
					return (ConnectionStringValue != string.Empty)?ConnectionStringValue:GetString(Key);
				case DBFactory:
					return (DBFactoryValue != string.Empty)?DBFactoryValue:GetString(Key);
				case Resource:
					return (ResourceValue != string.Empty)?ResourceValue:GetString(Key);
				case Language:
					return (LanguageValue != string.Empty)?LanguageValue:GetString(Key);
				case BusinessLogic:
					return (BusinessLogicValue != string.Empty)?BusinessLogicValue:GetString(Key);
				default :
					return null; 
			}
			
		}

		private static string GetString(string Key)
		{
			string KeyValue;
			string AssemblyPath;
			AssemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)  + "\\App.Config.xml";
			
			System.Xml.XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(AssemblyPath);
				KeyValue = GetConfig(doc.DocumentElement, Key);
			}
			catch(System.Exception ex)
			{
				throw ex;
			}
			//KeyValue = "C:\\Inetpub\\wwwroot\\TestWeb\\bin\\BusinessLogic";
			return KeyValue;
		}
		private static XmlNode GetNode(XmlNode parentNode, string childNodeName)
		{
			IEnumerator e = parentNode.GetEnumerator();
			while(e.MoveNext())
			{
				if(childNodeName == (e.Current as XmlNode).Name)
					return e.Current as XmlNode;
			}
			return null;
		}

		private static string GetConfig(XmlNode rootNode, string Key)
		{
			string[] keys = Key.Split('/');
			XmlNode tempNode = rootNode;

			for(int i = 0; i < keys.Length; i++ )
			{
				tempNode = GetNode(tempNode, keys[i]);
			}

			return (tempNode == null)?string.Empty:tempNode.InnerText;
		}
	}
}
