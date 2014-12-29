using System;
using System.Data;

using Wicresoft.BusinessObject;

namespace CWXT.ProcessFlow
{
    /// <summary>
    /// Summary description for AccountController.
    /// </summary>
    public class AccountController
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AccountController()
        {
        }


        /// <summary>
        ///	用户登录密码状态
        /// </summary>
        internal enum Result
        {
            UNKNOWN = -1,
            /// <summary>
            /// 第一次登录系统
            /// </summary>
            FIRST_LOGIN = 0,
            /// <summary>
            /// 未到期，但到了需要提示的时候
            /// </summary>
            CAN_CANCEL = 1,
            /// <summary>
            /// 到期，必须立即更改密码
            /// </summary>
            MUST_MODIFY = 2
        }

        /// <summary>
        /// 判断密码修改状态
        /// </summary>
        internal Result CheckResult
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["CheckResult"] != null)
                    return (Result)Convert.ToInt32(System.Web.HttpContext.Current.Session["CheckResult"]);
                else
                    return Result.UNKNOWN;
            }
            set
            {
                System.Web.HttpContext.Current.Session["CheckResult"] = value;
            }
        }

        /// <summary>
        /// 记录还有多少时间必须修改密码
        /// </summary>
        private string LastDays
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["LastDays"] != null)
                    return System.Web.HttpContext.Current.Session["LastDays"].ToString();
                else
                    return string.Empty;
            }
            set
            {
                System.Web.HttpContext.Current.Session["LastDays"] = value;
            }
        }



        /// <summary>
        /// Process User Login Flow
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ProcessLogin(string userid, string password)
        {
            BusinessFilter filter = new BusinessFilter("User");
            filter.AddFilterItem("Alias", userid, Operation.Equal, FilterType.StringType, AndOr.AND);
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);
            filter.AddFilterItem("IsActive", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);

            BusinessMapping.User bo = new BusinessMapping.User();
            bo.SessionInstance = new Wicresoft.Session.Session();
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord && GlobalFacade.EncryptionManager.VerifyPassword(password, bo.Password.Value))
            {
                GlobalFacade.SystemContext context = GlobalFacade.SystemContext.GetContext();
                context.CurrentUser = bo;
                GlobalFacade.SystemContext.SaveContext(context);

                if (NeedModifyPassword())
                {
                    System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.ApplicationPath + "/SystemManage/UserManage/CheckPassword.aspx");
                }
                else
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(userid, false);
                    System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.ApplicationPath + "/" + Enums.Constants.DefaultUrl);
                }

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="inputpwd"></param>
        /// <param name="currentpwd"></param>
        /// <returns></returns>
        public bool VerifyPassword1(string inputpwd, string currentpwd)
        {
            string pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(inputpwd, "MD5");
            return pwd == currentpwd ? true : false;
        }


        /// <summary>
        /// 用户修改过密码后，重新颁发身份验证票
        /// </summary>
        /// <param name="userid">当前登录用户的Alias</param>
        internal void ProcessLogin(string userid)
        {
            System.Web.Security.FormsAuthentication.SetAuthCookie(userid, false);
            System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.ApplicationPath + "/" + Enums.Constants.DefaultUrl);
        }


        /// <summary>
        /// 验证用户是否需要修改登录密码
        /// </summary>
        /// <returns></returns>
        private bool NeedModifyPassword()
        {
            // 登录密码修改周期（天）
            string passwordDays = System.Configuration.ConfigurationManager.AppSettings["PasswordDays"];
            // 登录密码修改提醒提前天数
            string passwordAlertDays = System.Configuration.ConfigurationManager.AppSettings["PasswordAlertDays"];

            DateTime lastModifyTime = GlobalFacade.SystemContext.GetContext().CurrentUser.LastModifyPasswordTime.Value;
            if (lastModifyTime == DateTime.MinValue)
            {
                // 第一次登录
                this.CheckResult = Result.FIRST_LOGIN;
                return true;
            }
            else
            {
                TimeSpan ts = DateTime.Now.Subtract(lastModifyTime);
                int lastDays = Convert.ToInt32(passwordDays) - Convert.ToInt32(ts.TotalDays);

                if (lastDays <= Convert.ToInt32(passwordAlertDays) && lastDays > 0)
                {
                    // 未到期，但到了需要提醒的时间
                    this.LastDays = lastDays.ToString();
                    this.CheckResult = Result.CAN_CANCEL;
                    return true;
                }
                else if (lastDays <= 0)
                {
                    // 到期，需要立刻修改密码
                    this.CheckResult = Result.MUST_MODIFY;
                    return true;
                }
                else
                {
                    // 正常登录
                    return false;
                }
            }
        }

        /// <summary>
        /// 登出系统，清空Session
        /// </summary>
        public void SignOut()
        {
            // Clear the authentication ticket
            System.Web.Security.FormsAuthentication.SignOut();
            // Clear the contents of their session
            System.Web.HttpContext.Current.Session.Clear();
            // Tell the system to drop the session reference so that it does 
            // not need to be carried around with the user
            System.Web.HttpContext.Current.Session.Abandon();
        }

    }
}