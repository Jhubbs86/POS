﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CWXT.JHSY.CWBirthInfo
{
	public partial class CWBirthInfoView : EnterpriseWebsite.WebUI.ScrollPage
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				ucCWBirthInfo.LoadData(this.PKID,Enums.PageStatus.View);
			}
		}

		private bool btnReturn_ButtonClick(object sender, EventArgs e)
		{
            base.GoBack("CWBirthInfoList.aspx");
			return false;
		}
	
		private bool btnEdit_ButtonClick(object sender, EventArgs e)
		{
            base.PageTransfer("CWBirthInfoEdit.aspx", Enums.Constants.PKID + "=" + this.PKID.ToString());
			return false;
		}

		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
			this.AppendServerEvents();
		}

		private void AppendServerEvents()
		{
			this.btnReturn.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnReturn_ButtonClick);
			this.btnEdit.ButtonClick += new Microsoft.Web.UI.WebControls.ToolbarItemEventHandler(btnEdit_ButtonClick);
		}
	
		private void InitializeComponent(){}
	}
}