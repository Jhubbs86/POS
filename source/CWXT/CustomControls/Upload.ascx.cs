using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;

namespace CWXT.CustomControls
{
    public partial class Upload : System.Web.UI.UserControl
	{
		protected string folderName = string.Empty;
		protected string uploadFolder = string.Empty;
		public ArrayList filePathCollection = new ArrayList();
		protected int singleFileSize = int.MaxValue;
		protected bool singleFileUpload = false;
		protected string[] extFilter = new string[]{""};

		public delegate void InvalidFileHandler(string fileName, string errorMessage, FileErrorType fileErrorType);
		public event InvalidFileHandler InvalidFileEvent;

		/// <summary>
		/// 文件错误类型
		/// </summary>
		public enum FileErrorType
		{
			/// <summary>
			/// 文件长度错误
			/// </summary>
			FILE_LENGTH_ERROR = 0x0001,
			/// <summary>
			/// 文件格式错误
			/// </summary>
			FILE_FORMAT_ERROR = 0x0010
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			
		}

		public void SaveAllFiles()
		{
			// 文件存储位置：..\8E8A8E9A-9E48-40dd-9AD8-27E9B7A95636\文件名

			CheckFolder(uploadFolder);

			HttpFileCollection files = Request.Files;
			for(int i = 0; i < files.Count; i ++)
			{
				SaveSingleFile(files[i]);
			}
		}

		public string AttachmentList
		{
			get
			{
				string attList = string.Empty;
				foreach(string file in this.filePathCollection)
				{
					attList += file + ";";
				}

				for(int i = 0; i < this.rptExistedAttachments.Items.Count; i++)
				{
					if((this.rptExistedAttachments.Items[i].Controls[1] as CheckBox).Checked)
						attList += (this.rptExistedAttachments.Items[i].Controls[3] as Label).Text + ";";
				}

				if(attList != string.Empty)
					attList = attList.Substring(0, attList.Length - 1);

				return attList;
			}
			set
			{
				if(value == null || value == string.Empty)
					return;

				DataTable tbl = new DataTable();
				tbl.Columns.Add(new DataColumn("Checked", typeof(bool)));
				tbl.Columns.Add(new DataColumn("FileFullName", typeof(string)));
				tbl.Columns.Add(new DataColumn("FileName", typeof(string)));
				tbl.Columns.Add(new DataColumn("FileLength", typeof(string)));

				DataRow row;
				foreach(string str in value.Split(';'))
				{
					string name = str.Split('\\')[1];

					row = tbl.NewRow();
					row["Checked"] = true;
					row["FileFullName"] = str;
					row["FileName"] = name;
					row["FileLength"] = this.GetFileLength_KB(str);
					tbl.Rows.Add(row);
				}

				this.rptExistedAttachments.DataSource = tbl.DefaultView;
				this.rptExistedAttachments.DataBind();
			}
		}

		/// <summary>
		/// 文件大小限制（单个文件，单位KB）
		/// </summary>
		public int SingleFileSize
		{
			get { return this.singleFileSize; }
			set { this.singleFileSize = value; }
		}

		/// <summary>
		/// 设置控件只读属性
		/// </summary>
		public bool Readonly
		{
			set
			{
				if(value)
					this.uploadDiv.Visible = false;
			}
		}

		/// <summary>
		/// 后缀名过滤串
		/// 以分号分割，i.e.：gif;jpeg;jpg;
		/// </summary>
		public string ExtensionFilter
		{
			set
			{
				if(value != null && value != string.Empty)
				{
					this.extFilter = value.Split(';');
					for(int i = 0; i < extFilter.Length; i++)
					{
						extFilter[i] = extFilter[i].ToLower();
					}
				}
			}
		}

		/// <summary>
		/// 上传单个文件控制
		/// </summary>
		public bool SingleFileUpload
		{
			get
			{
				return this.singleFileUpload;
			}
			set
			{
				this.singleFileUpload = value;
				this.addAnotherDiv.Visible = !value;
			}
		}

		private void CheckFolder(string folderPath)
		{
			if(! System.IO.Directory.Exists(folderPath))
			{
				System.IO.Directory.CreateDirectory(folderPath);
			}
		}

		private string BuildPath(string fileName)
		{
			return uploadFolder + this.folderName + "\\" + fileName;
		}

		private void SaveSingleFile(HttpPostedFile file)
		{
			// check
            if (CheckFile(file))
            {
                folderName = Guid.NewGuid().ToString();
                this.CheckFolder(uploadFolder + this.folderName);
                file.SaveAs(this.BuildPath(this.FileName(file)));
                this.filePathCollection.Add(this.folderName + "\\" + this.FileName(file));
            }
		}

		private bool CheckFile(HttpPostedFile file)
		{
			if(file.ContentLength < 0 || file.FileName == string.Empty)
			{
				//InvalidFileEvent(System.IO.Path.GetFileName(file.FileName), "没有选择文件");
				return false;
			}
			else
			{
				// 检查文件大小
				if((file.ContentLength / 1024.0) > this.singleFileSize)
				{
					if(InvalidFileEvent != null)
						InvalidFileEvent(System.IO.Path.GetFileName(file.FileName), ResourceManager.Instance.GetString("ValidateFileLength") + this.singleFileSize.ToString() + "KB", FileErrorType.FILE_LENGTH_ERROR);
					return false;
				}

				//检查文件后缀名
				if(! CheckExtension(ExtName(file)))
				{
					if(InvalidFileEvent != null)
						InvalidFileEvent(System.IO.Path.GetFileName(file.FileName), ResourceManager.Instance.GetString("ValidateFileStyle"), FileErrorType.FILE_FORMAT_ERROR);
					return false;
				}
				return true;
			}
		}

		/// <summary>
		/// 检查文件扩展名是否正确
		/// </summary>
		/// <param name="ext"></param>
		/// <returns></returns>
		private bool CheckExtension(string ext)
		{
			if(extFilter.Length > 0 && extFilter[0] == string.Empty)
				return true;

			for(int i = 0; i < this.extFilter.Length; i++)
			{
				if(ext == extFilter[i])
					return true;
			}
			return false;
		}

		/// <summary>
		/// 获得文件扩展名，并转换成小写
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		private string ExtName(HttpPostedFile file)
		{
			string fileName = FileName(file);
			int pos = fileName.LastIndexOf('.');
			if(pos < 0) return string.Empty;

			return fileName.Substring(pos + 1).ToLower();
		}

		/// <summary>
		/// 获得文件全名
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		private string FileName(HttpPostedFile file)
		{
			int pos = FullPathName(file).Replace('/', '\\').LastIndexOf('\\');
            int pos1 = FullPathName(file).Replace('/', '\\').LastIndexOf('\\');
            if (pos1 == -1) return file.FileName;
			if(pos < 0) return string.Empty;

			return FullPathName(file).Substring(pos + 1);
		}

		private string FullPathName(HttpPostedFile file)
		{
			return file.FileName;
		}

		private Stream InputStream(HttpPostedFile file)
		{
			return file.InputStream;
		}

		private string GetFileLength_KB(string fileName)
		{
			int fileLength = 0;
			string path = uploadFolder + fileName;

			if(System.IO.File.Exists(path))
			{
				System.IO.FileStream fs = System.IO.File.OpenRead(path);
				fileLength = (int)(fs.Length / 1024);
			}
			return fileLength.ToString() + "KB";
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
			uploadFolder = Page.Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["UploadFolder"]) + "\\";
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion
	}
}