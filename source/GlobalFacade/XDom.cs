using System;
using System.Xml ; 

namespace GlobalFacade
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class XDom
	{
		public XDom()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static System.Xml.XmlDocument GenXmlDocument(string root,out System.Xml.XmlElement rootnode)
		{
			System.Xml.XmlDocument doc = new XmlDocument();
			System.Xml.XmlDeclaration declare = doc.CreateXmlDeclaration("1.0","UTF-8",null);
			doc.InsertBefore(declare,doc.DocumentElement);
			rootnode = doc.CreateElement(root);
			doc.AppendChild(rootnode);
			return doc;
		}

		public static void SetNodeAttribute(System.Xml.XmlDocument doc ,System.Xml.XmlElement element,string AttributeName,string value)
		{
			System.Xml.XmlAttribute attribute = doc.CreateAttribute(AttributeName);
			attribute.Value = value;
			element.Attributes.Append(attribute);
		}

		public static System.Xml.XmlElement CreateDocumentElement(System.Xml.XmlDocument doc,string ElementName)
		{
			System.Xml.XmlElement element = doc.CreateElement(ElementName);
			return element;
		}
		
		public static void AddElement(System.Xml.XmlElement parent ,System.Xml.XmlElement child)
		{
			parent.AppendChild(child);
		}

		#region Operate Tree
		private  void QueryAllNode(Microsoft.Web.UI.WebControls.TreeNode parent,string nodedata)
		{
			this.Push(parent);
			foreach (Microsoft.Web.UI.WebControls.TreeNode child in parent.Nodes)
			{
				QueryAllNode(child,nodedata);
			}
		}
		public  Microsoft.Web.UI.WebControls.TreeNode  GetNode(string nodedata,Microsoft.Web.UI.WebControls.TreeView tv)
		{
			Stack.Clear();
			foreach ( Microsoft.Web.UI.WebControls.TreeNode node in tv.Nodes)
			{
				QueryAllNode(node,nodedata); 
			}
			Microsoft.Web.UI.WebControls.TreeNode StackNode = null ;
			for (int i = 0 ; i<Stack.Count ; i++)
			{
				StackNode = (Microsoft.Web.UI.WebControls.TreeNode)Stack[i];
				if (StackNode.Text == nodedata)
				{
					break;
				}
			}
			if (Stack!=null)
			{
				Stack.Clear();
			}
			if (StackNode!=null)
				return StackNode;
			else
				return null;
		}

		#endregion

		#region Stack
		private System.Collections.ArrayList Stack ; 

		public Microsoft.Web.UI.WebControls.TreeNode Top()
		{
			
			Microsoft.Web.UI.WebControls.TreeNode node ; 
			if (Stack.Count<=0)
				return null;
			else
			{
				node = (Microsoft.Web.UI.WebControls.TreeNode)Stack[Stack.Count];
				Stack.Remove(node);
				return node ;
			}
		}

		public void Push(Microsoft.Web.UI.WebControls.TreeNode node)
		{
			if (Stack== null)
				Stack = new System.Collections.ArrayList();
			Stack.Add(node);
		}
		#endregion
	}
}

