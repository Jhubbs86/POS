﻿using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CWXT.CustomControls
{
    public partial class VerificationCodeManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
        }

        public bool ValidateInputCode(string inputCode)
        {
            return (inputCode == Code) ? true : false;
        }

        private string Code
        {
            get
            {
                if (this.Session["__VerificationCode"] == null)
                    this.Session["__VerificationCode"] = string.Empty;
                return this.Session["__VerificationCode"].ToString();
            }
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}