using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace CWXT
{
    public class CommonNode
    {
        [XmlAttribute("TEXT")]
        public string text { get; set; }

        [XmlAttribute("NODEDATA")]
        public string id { get; set; }

        [XmlAttribute("TARGET")]
        public string target { get; set; }

        [XmlAttribute("NAVIGATEURL")]
        public string url { get; set; }

        [DataMember(Name = "attributes")]
        public Attributes attributes
        {
            get { return new Attributes() { Url = url, Target = target }; }
            set { value = new Attributes() { Url = url, Target = target }; }
        }
    }

    [Serializable]
    public class Attributes
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "target")]
        public string Target { get; set; }
    }
    [Serializable, XmlRoot("TREENODES")]
    public class MenuConfig
    {
        private string _text = "打开所有菜单";
        [DataMember(Name = "text")]
        public string text
        {
            get
            {
                return _text;
            }
            set
            {
                value = _text;
            }
        }

        [XmlElement("TREENODE")]
        public List<TreeNode> children { get; set; }
    }
    [Serializable, XmlType("TreeNode")]
    public class TreeNode : CommonNode
    {
        [XmlElement("TREENODE")]
        public List<TreeNodeChildren> children { get; set; }
    }

    [Serializable, XmlType("TreeNodeChildren")]
    public class TreeNodeChildren : CommonNode
    {
        [XmlElement("TREENODE")]
        public List<TreeNodeChildrenOfChildren> children { get; set; }
    }

    public class TreeNodeChildrenOfChildren : CommonNode
    {
        public string children { get; set; }
    }

}