using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using GlobalFacade; 

namespace CWXT
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Global()
        {
            InitializeComponent();
        }

        protected void Application_Start(Object sender, EventArgs e)
        {

        }

        protected void Session_Start(Object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            Resources.EmbedResources.HandleResourceRequest();
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["Alert"].ToLower() == "true")
            {
                string strError = "Error in: " + Request.Path +
                    "\nUrl: " + Request.RawUrl + "\n\n";

                // Get the exception object for the last error message that occured.
                Exception ErrorInfo = Server.GetLastError().GetBaseException();
                strError += "Error Message: " + ErrorInfo.Message +
                    "\nError Source: " + ErrorInfo.Source +
                    "\nError Target Site: " + ErrorInfo.TargetSite +
                    "\n\nQueryString Data:\n-----------------\n";

                // Gathering QueryString information
                for (int i = 0; i < Context.Request.QueryString.Count; i++)
                    strError += Context.Request.QueryString.Keys[i] + ":\t\t" + Context.Request.QueryString[i] + "\n";
                strError += "\nPost Data:\n----------\n";

                // Gathering Post Data information
                for (int i = 0; i < Context.Request.Form.Count; i++)
                    strError += Context.Request.Form.Keys[i] + ":\t\t" + Context.Request.Form[i] + "\n";
                strError += "\n";

                if (User.Identity.IsAuthenticated) strError += "User:\t\t" + User.Identity.Name + "\n\n";

                strError += "Exception Stack Trace:\n----------------------\n" + Server.GetLastError().StackTrace +
                    "\n\nServer Variables:\n-----------------\n";

                // Gathering Server Variables information
                for (int i = 0; i < Context.Request.ServerVariables.Count; i++)
                    strError += Context.Request.ServerVariables.Keys[i] + ":\t\t" + Context.Request.ServerVariables[i] + "\n";
                strError += "\n";
              
            }
        }

        protected void Session_End(Object sender, EventArgs e)
        {

        }

        protected void Application_End(Object sender, EventArgs e)
        {

        }

        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        }
        #endregion
    }
}