using System;

using Wicresoft.BusinessObject;

namespace GlobalFacade
{
    /// <summary>
    /// 页面状态对象
    /// </summary>
    public class PageContext
    {
        public PageContext()
        {
            this.parms = new System.Collections.Hashtable();
            this.foreignkeys = new System.Collections.Hashtable();
            this.lastPageNumber = new System.Collections.Specialized.StringDictionary();
            this.lastQueryCondition = new System.Collections.Hashtable();
            this.lastSortExpression = new System.Collections.Specialized.StringDictionary();
            this.lastPageSize = new System.Collections.Specialized.StringDictionary();
            this.lastSelectedRecord = new System.Collections.Specialized.StringDictionary();
        }

        /// <summary>
        /// 数据对象的PKID
        /// </summary>
        public int PKID
        {
            get
            {
                if (System.Web.HttpContext.Current.Request.QueryString["__PKID"] != null)
                    return Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["__PKID"]);
                else
                    return 0;
            }
        }

        /// <summary>
        /// 上次浏览页面的查询条件
        /// </summary>
        /// <remarks>
        /// 页面上可以有多个需要记录状态的控件，分别以各自的UniqueID作为Key
        /// </remarks>
        private System.Collections.Hashtable lastQueryCondition;

        public System.Collections.Hashtable LastQueryCondition
        {
            get { return this.lastQueryCondition; }
            set { this.lastQueryCondition = value; }
        }

        /// <summary>
        /// 上次浏览页面的页码
        /// </summary>
        /// <remarks>
        /// 页面上可以有多个需要记录状态的控件，分别以各自的UniqueID作为Key
        /// </remarks>
        private System.Collections.Specialized.StringDictionary lastPageNumber;
        public System.Collections.Specialized.StringDictionary LastPageNumber
        {
            get { return this.lastPageNumber; }
            set { this.lastPageNumber = value; }
        }

        /// <summary>
        /// 上次浏览页面的排序表达式
        /// </summary>
        /// <remarks>
        /// 页面上可以有多个需要记录状态的控件，分别以各自的UniqueID作为Key
        /// </remarks>
        private System.Collections.Specialized.StringDictionary lastSortExpression;
        public System.Collections.Specialized.StringDictionary LastSortExpression
        {
            get { return this.lastSortExpression; }
            set { this.lastSortExpression = value; }
        }

        /// <summary>
        /// 上次浏览页面的页大小
        /// </summary>
        /// <remarks>
        /// 页面上可以有多个需要记录状态的控件，分别以各自的UniqueID作为Key
        /// </remarks>
        private System.Collections.Specialized.StringDictionary lastPageSize;
        public System.Collections.Specialized.StringDictionary LastPageSize
        {
            get { return this.lastPageSize; }
            set { this.lastPageSize = value; }
        }

        /// <summary>
        /// 上次选中的记录
        /// </summary>
        /// <remarks>
        /// 页面上可以有多个需要记录状态的控件，分别以各自的UniqueID作为Key
        /// </remarks>
        private System.Collections.Specialized.StringDictionary lastSelectedRecord;
        public System.Collections.Specialized.StringDictionary LastSelectedRecord
        {
            get { return this.lastSelectedRecord; }
            set { this.lastSelectedRecord = value; }
        }

        /// <summary>
        /// 自定义参数
        /// </summary>
        private System.Collections.Hashtable parms;
        public System.Collections.Hashtable Parms
        {
            get
            {
                return parms;
            }
        }

        public void AddParameter(object key, object Value)
        {
            if (!parms.Contains(key))
            {
                parms.Add(key, Value);
            }
            else
            {
                parms[key] = Value;
            }
        }

        public void ClearParameter()
        {
            parms.Clear();
        }


        /// <summary>
        /// 外键服务
        /// </summary>
        private System.Collections.Hashtable foreignkeys;
        public System.Collections.Hashtable ForeignKeys
        {
            get { return foreignkeys; }
        }

        public void AddForeignKeyValue(object key, object value)
        {
            if (!this.foreignkeys.Contains(key))
            {
                this.foreignkeys.Add(key, value);
            }
            else
                this.foreignkeys[key] = value;
        }

        public void ForeignKeyClear()
        {
            this.foreignkeys.Clear();
        }
    }

    /// <summary>
    /// 系统上下文
    /// </summary>
    public class SystemContext
    {
        /// <summary>
        /// 阻止实例化对象
        /// </summary>
        protected SystemContext()
        {
            contextCollection = new System.Collections.Hashtable();
        }

        private void GetCurrentUser()
        {
            string id = System.Web.HttpContext.Current.User.Identity.Name;

            BusinessFilter filter = new BusinessFilter("User");
            filter.AddFilterItem("Alias", id, Operation.Equal, FilterType.StringType, AndOr.AND);
            filter.AddFilterItem("IsValid", "1", Operation.Equal, FilterType.NumberType, AndOr.AND);

            BusinessMapping.User bo = new BusinessMapping.User();
            bo.SessionInstance = new Wicresoft.Session.Session();
            bo.AddFilter(filter);
            bo.Load();

            if (bo.HaveRecord)
                this.currentUser = bo;
            else
                throw new Exception("无法取得当前用户信息！");
        }

        /// <summary>
        /// 页面上下文集合
        /// </summary>
        private System.Collections.Hashtable contextCollection;

        private BusinessMapping.User currentUser = new BusinessMapping.User();
        public BusinessMapping.User CurrentUser
        {
            get
            {
                if (!this.currentUser.HaveRecord)
                    GetCurrentUser();
                return this.currentUser;
            }
            set { this.currentUser = value; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get
            {
                return this.CurrentUser.PKID.Value;
            }
        }

        /// <summary>
        /// Alias
        /// </summary>
        public string Alias
        {
            get
            {
                return this.CurrentUser.Alias.Value;
            }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName
        {
            get
            {
                return this.CurrentUser.ChineseName.Value;
            }
        }

        /// <summary>
        /// 用户角色ID
        /// </summary>
        public int UserRoleID
        {
            get
            {
                return this.CurrentUser.FK_Role.Value;
            }
        }

        #region 静态方法，操作系统上下文
        /// <summary>
        /// 获取当前系统上下文
        /// </summary>
        /// <returns></returns>
        public static SystemContext GetContext()
        {
            if (System.Web.HttpContext.Current.Session == null || System.Web.HttpContext.Current.Session["__Wicresoft_SystemContext"] == null)
            {
                System.Web.HttpContext.Current.Session.Add("__Wicresoft_SystemContext", new SystemContext());
            }
            return System.Web.HttpContext.Current.Session["__Wicresoft_SystemContext"] as SystemContext;
        }

        /// <summary>
        /// 保存当前系统上下文
        /// </summary>
        /// <param name="ctx"></param>
        public static void SaveContext(SystemContext ctx)
        {
            System.Web.HttpContext.Current.Session["__Wicresoft_SystemContext"] = ctx;
        }
        #endregion

        #region 实例方法，操作页面上下文
        /// <summary>
        /// 获取页面上下文
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns></returns>
        public PageContext GetPageContext(string pageId)
        {
            if (!this.contextCollection.Contains(pageId))
                return new PageContext();
            else
                return this.contextCollection[pageId] as PageContext;
        }

        /// <summary>
        /// 保存页面上下文
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="ctx"></param>
        public void SavePageContext(string pageId, PageContext ctx)
        {
            this.contextCollection[pageId] = ctx;
        }
        #endregion
    }
}
