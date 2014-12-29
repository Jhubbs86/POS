using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using Wicresoft.BusinessObject;
using System.Text;


namespace CodeGenerator
{
	/// <summary>
	/// FrmMain 的摘要说明。
	/// </summary>
	public class FrmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmbObjectList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxNamespace;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnPreview;
		private System.Windows.Forms.ComboBox cmbTemplate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxPreview1;
		private System.Windows.Forms.TextBox tbxPreview2;
		private System.Windows.Forms.TextBox tbxObjectDesc;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbLevel;

		private string objectName;
		private string objectDesc;
		private string nameSpace;
		private string level;
		private string tempateName;
		private System.Windows.Forms.Button btnCopy1;
		private System.Windows.Forms.Button btnCopy2;


		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmMain()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.cmbObjectList = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbxNamespace = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxObjectDesc = new System.Windows.Forms.TextBox();
			this.btnPreview = new System.Windows.Forms.Button();
			this.cmbTemplate = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxPreview1 = new System.Windows.Forms.TextBox();
			this.tbxPreview2 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbLevel = new System.Windows.Forms.ComboBox();
			this.btnCopy1 = new System.Windows.Forms.Button();
			this.btnCopy2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmbObjectList
			// 
			this.cmbObjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbObjectList.Location = new System.Drawing.Point(168, 16);
			this.cmbObjectList.Name = "cmbObjectList";
			this.cmbObjectList.Size = new System.Drawing.Size(208, 20);
			this.cmbObjectList.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Business Object Name:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "BusinessRule Namespace:";
			// 
			// tbxNamespace
			// 
			this.tbxNamespace.Location = new System.Drawing.Point(168, 48);
			this.tbxNamespace.Name = "tbxNamespace";
			this.tbxNamespace.Size = new System.Drawing.Size(208, 21);
			this.tbxNamespace.TabIndex = 3;
			this.tbxNamespace.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(416, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(184, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Business Object Description:";
			// 
			// tbxObjectDesc
			// 
			this.tbxObjectDesc.Location = new System.Drawing.Point(592, 16);
			this.tbxObjectDesc.Name = "tbxObjectDesc";
			this.tbxObjectDesc.Size = new System.Drawing.Size(208, 21);
			this.tbxObjectDesc.TabIndex = 5;
			this.tbxObjectDesc.Text = "";
			// 
			// btnPreview
			// 
			this.btnPreview.Location = new System.Drawing.Point(24, 80);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(112, 23);
			this.btnPreview.TabIndex = 6;
			this.btnPreview.Text = "Preview";
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// cmbTemplate
			// 
			this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTemplate.Items.AddRange(new object[] {
															 "BusinessMapping模版",
															 "BusinessRule模版",
															 "BusinessView模版",
															 "新增页面模版",
															 "编辑页面模版",
															 "查看页面模版",
															 "查询页面模版",
															 "列表页面模版",
															 "对象用户控件模版（仅主档）",
															 "对象用户控件模版（主明细）"});
			this.cmbTemplate.Location = new System.Drawing.Point(592, 48);
			this.cmbTemplate.Name = "cmbTemplate";
			this.cmbTemplate.Size = new System.Drawing.Size(208, 20);
			this.cmbTemplate.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(496, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Code Template:";
			// 
			// tbxPreview1
			// 
			this.tbxPreview1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tbxPreview1.Location = new System.Drawing.Point(24, 112);
			this.tbxPreview1.Multiline = true;
			this.tbxPreview1.Name = "tbxPreview1";
			this.tbxPreview1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbxPreview1.Size = new System.Drawing.Size(800, 192);
			this.tbxPreview1.TabIndex = 9;
			this.tbxPreview1.Text = "";
			// 
			// tbxPreview2
			// 
			this.tbxPreview2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tbxPreview2.Location = new System.Drawing.Point(24, 320);
			this.tbxPreview2.Multiline = true;
			this.tbxPreview2.Name = "tbxPreview2";
			this.tbxPreview2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbxPreview2.Size = new System.Drawing.Size(800, 192);
			this.tbxPreview2.TabIndex = 10;
			this.tbxPreview2.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(544, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 16);
			this.label5.TabIndex = 11;
			this.label5.Text = "Level:";
			// 
			// cmbLevel
			// 
			this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLevel.Items.AddRange(new object[] {
														  "1",
														  "2",
														  "3"});
			this.cmbLevel.Location = new System.Drawing.Point(592, 80);
			this.cmbLevel.Name = "cmbLevel";
			this.cmbLevel.Size = new System.Drawing.Size(56, 20);
			this.cmbLevel.TabIndex = 12;
			// 
			// btnCopy1
			// 
			this.btnCopy1.Location = new System.Drawing.Point(144, 80);
			this.btnCopy1.Name = "btnCopy1";
			this.btnCopy1.Size = new System.Drawing.Size(112, 23);
			this.btnCopy1.TabIndex = 13;
			this.btnCopy1.Text = "Copy Window 1";
			this.btnCopy1.Click += new System.EventHandler(this.btnCopy1_Click);
			// 
			// btnCopy2
			// 
			this.btnCopy2.Location = new System.Drawing.Point(264, 80);
			this.btnCopy2.Name = "btnCopy2";
			this.btnCopy2.Size = new System.Drawing.Size(112, 23);
			this.btnCopy2.TabIndex = 14;
			this.btnCopy2.Text = "Copy Window 2";
			this.btnCopy2.Click += new System.EventHandler(this.btnCopy2_Click);
			// 
			// FrmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(848, 517);
			this.Controls.Add(this.btnCopy2);
			this.Controls.Add(this.btnCopy1);
			this.Controls.Add(this.cmbLevel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbxPreview2);
			this.Controls.Add(this.tbxPreview1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbTemplate);
			this.Controls.Add(this.btnPreview);
			this.Controls.Add(this.tbxObjectDesc);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbxNamespace);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbObjectList);
			this.Name = "FrmMain";
			this.Text = "FrmMain";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmMain_Load(object sender, System.EventArgs e)
		{
			GetObjectList();
			this.cmbTemplate.SelectedIndex = 0;
			this.cmbLevel.SelectedIndex = 0;
		}

		private void GetObjectList()
		{
			Type[] types = Wicresoft.Global.GetBusinessLogicAssembly().GetTypes();
			ArrayList list = new ArrayList();

			for(int i = 0; i < types.Length; i ++)
			{
				list.Add(types[i].ToString());
			}
			list.Sort();
			this.cmbObjectList.DataSource = list;
		}

		private string GetResourceContent(string resourceFullName)
		{
			System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceFullName);
			System.IO.StreamReader sr = new System.IO.StreamReader(stream, System.Text.Encoding.Default);
			return sr.ReadToEnd();
		}

		private string Process(string content)
		{
			/***********************************************************************
			 *			<%Namespace%>			--	命名空间，".SystemManage"
			 *			<%ObjectName%>			--	对象名称，"UserLevel"
			 *			<%ObjectDescription%>	--	对象描述，"用户级别"
			 *			<%Declaration%>			--	声明区域
			 *			<%Initialization%>		--	初始化区域
			 *			<%RelativeLevel%>		--	相对于虚拟目录的路径，"../"	
			 ***********************************************************************/
			
			content = Regex.Replace(content, "<%Namespace%>", (nameSpace == string.Empty)?string.Empty:"." + nameSpace, RegexOptions.IgnoreCase);
			content = Regex.Replace(content, "<%ObjectName%>", objectName, RegexOptions.IgnoreCase);
			content = Regex.Replace(content, "<%ObjectDescription%>", objectDesc, RegexOptions.IgnoreCase);
			content = Regex.Replace(content, "<%Declaration%>", "", RegexOptions.IgnoreCase);
			content = Regex.Replace(content, "<%Initialization%>", "", RegexOptions.IgnoreCase);
			content = Regex.Replace(content, "<%RelativeLevel%>", level, RegexOptions.IgnoreCase);

			return content;
		}

		private void btnPreview_Click(object sender, System.EventArgs e)
		{
			if(this.cmbObjectList.SelectedIndex > -1 && 
				this.cmbTemplate.SelectedIndex > -1 &&
				this.cmbLevel.SelectedIndex > -1 &&
				this.tbxObjectDesc.Text != string.Empty)
			{
				objectName = this.cmbObjectList.Items[this.cmbObjectList.SelectedIndex].ToString().Split('.')[1];
				objectDesc = this.tbxObjectDesc.Text.Trim();
				nameSpace = this.tbxNamespace.Text.Trim();
				tempateName = this.cmbTemplate.Items[this.cmbTemplate.SelectedIndex].ToString();
				level = "../";

				for(int i = 1; i < Convert.ToInt32(this.cmbLevel.Items[this.cmbLevel.SelectedIndex]); i++)
				{
					level += "../";
				}
				
				switch(tempateName)
				{
					case "BusinessMapping模版":
						MessageBox.Show("功能未实现！");
						break;
					case "BusinessRule模版":
						this.tbxPreview1.Text = Process(GetResourceContent("CodeGenerator.Templates.BusinessRule_Template"));
						this.tbxPreview2.Text = string.Empty;
						break;
					case "BusinessView模版":
						this.tbxPreview1.Text = Process(GetResourceContent("CodeGenerator.Templates.BusinessView_Template"));
						this.tbxPreview2.Text = string.Empty;
						break;
					case "新增页面模版":
						this.tbxPreview1.Text = Process(GetResourceContent("CodeGenerator.Templates.CreateObject_ASPX_Template"));
						this.tbxPreview2.Text = Process(GetResourceContent("CodeGenerator.Templates.CreateObject_CS_Template"));
						break;
					case "编辑页面模版":
						this.tbxPreview1.Text = Process(GetResourceContent("CodeGenerator.Templates.EditObject_ASPX_Template"));
						this.tbxPreview2.Text = Process(GetResourceContent("CodeGenerator.Templates.EditObject_CS_Template"));
						break;
					case "查看页面模版":
						this.tbxPreview1.Text = Process(GetResourceContent("CodeGenerator.Templates.ViewObject_ASPX_Template"));
						this.tbxPreview2.Text = Process(GetResourceContent("CodeGenerator.Templates.ViewObject_CS_Template"));
						break;
					case "查询页面模版":
						this.tbxPreview1.Text = Process(GetResourceContent("CodeGenerator.Templates.QueryObject_ASPX_Template"));
						this.tbxPreview2.Text = Process(GetResourceContent("CodeGenerator.Templates.QueryObject_CS_Template"));
						break;
					case "列表页面模版":
						this.tbxPreview1.Text = Process(GetResourceContent("CodeGenerator.Templates.ObjectList_ASPX_Template"));
						this.tbxPreview2.Text = Process(GetResourceContent("CodeGenerator.Templates.ObjectList_CS_Template"));
						break;
					case "对象用户控件模版（仅主档）":
						this.tbxPreview1.Text = Process(GetResourceContent("CodeGenerator.Templates.Object_ASCX_NoDetail_Template"));
						this.tbxPreview2.Text = Process(GetResourceContent("CodeGenerator.Templates.Object_CS_NoDetail_Template"));
						break;
					case "对象用户控件模版（主明细）":
						MessageBox.Show("功能未实现！");
						break;
					default:
						break;
				}
			}
			else
			{
				MessageBox.Show("请将运行参数填写完整！");
			}
		}

		private void btnCopy1_Click(object sender, System.EventArgs e)
		{
			this.tbxPreview1.SelectAll();
			this.tbxPreview1.Copy();
		}

		private void btnCopy2_Click(object sender, System.EventArgs e)
		{
			this.tbxPreview2.SelectAll();
			this.tbxPreview2.Copy();
		}


//		private void BuildObjectReference()
//		{
//			Type[] types = Wicresoft.Global.GetBusinessLogicAssembly().GetTypes();
//			foreach(Type type in types)
//			{
//				BuildSingleObjectRelationship(type, types);
//			}
//		}

//		private string  BuildSingleObjectRelationship(Type type, Type[] types)
//		{
//			foreach(Type t in types)
//			{
//				if(t == type)
//					continue;
//				else
//				{
//					string objectName = type.Name;
//					StringBuilder sb = new StringBuilder();
//					
//					FieldInfo[] fields = t.GetFields();
//					foreach(FieldInfo fi in fields)
//					{
//						ForeignKeyAttribute[] fkAttrs = fi.GetCustomAttributes(typeof(ForeignKeyAttribute), false) as ForeignKeyAttribute[];
//						if(fkAttrs != null)
//						{
//							foreach(ForeignKeyAttribute fkAttr in fkAttrs)
//							{
//								if(fkAttr.TableName == objectName)
//								{
//									sb.Append(t.Name);
//									sb.Append(";");
//									break;
//								}
//							}
//						}
//
//
//					}
//				}
//			}
//		}

	}
}
