using System;

using Wicresoft.BusinessObject;

namespace GlobalFacade
{
    /// <summary>
    /// ҳ��״̬����
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
        /// ���ݶ����PKID
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
        /// �ϴ����ҳ��Ĳ�ѯ����
        /// </summary>
        /// <remarks>
        /// ҳ���Ͽ����ж����Ҫ��¼״̬�Ŀؼ����ֱ��Ը��Ե�UniqueID��ΪKey
        /// </remarks>
        private System.Collections.Hashtable lastQueryCondition;

        public System.Collections.Hashtable LastQueryCondition
        {
            get { return this.lastQueryCondition; }
            set { this.lastQueryCondition = value; }
        }

        /// <summary>
        /// �ϴ����ҳ���ҳ��
        /// </summary>
        /// <remarks>
        /// ҳ���Ͽ����ж����Ҫ��¼״̬�Ŀؼ����ֱ��Ը��Ե�UniqueID��ΪKey
        /// </remarks>
        private System.Collections.Specialized.StringDictionary lastPageNumber;
        public System.Collections.Specialized.StringDictionary LastPageNumber
        {
            get { return this.lastPageNumber; }
            set { this.lastPageNumber = value; }
        }

        /// <summary>
        /// �ϴ����ҳ���������ʽ
        /// </summary>
        /// <remarks>
        /// ҳ���Ͽ����ж����Ҫ��¼״̬�Ŀؼ����ֱ��Ը��Ե�UniqueID��ΪKey
        /// </remarks>
        private System.Collections.Specialized.StringDictionary lastSortExpression;
        public System.Collections.Specialized.StringDictionary LastSortExpression
        {
            get { return this.lastSortExpression; }
            set { this.lastSortExpression = value; }
        }

        /// <summary>
        /// �ϴ����ҳ���ҳ��С
        /// </summary>
        /// <remarks>
        /// ҳ���Ͽ����ж����Ҫ��¼״̬�Ŀؼ����ֱ��Ը��Ե�UniqueID��ΪKey
        /// </remarks>
        private System.Collections.Specialized.StringDictionary lastPageSize;
        public System.Collections.Specialized.StringDictionary LastPageSize
        {
            get { return this.lastPageSize; }
            set { this.lastPageSize = value; }
        }

        /// <summary>
        /// �ϴ�ѡ�еļ�¼
        /// </summary>
        /// <remarks>
        /// ҳ���Ͽ����ж����Ҫ��¼״̬�Ŀؼ����ֱ��Ը��Ե�UniqueID��ΪKey
        /// </remarks>
        private System.Collections.Specialized.StringDictionary lastSelectedRecord;
        public System.Collections.Specialized.StringDictionary LastSelectedRecord
        {
            get { return this.lastSelectedRecord; }
            set { this.lastSelectedRecord = value; }
        }

        /// <summary>
        /// �Զ������
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
        /// �������
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
    /// ϵͳ������
    /// </summary>
    public class SystemContext
    {
        /// <summary>
        /// ��ֹʵ��������
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
                throw new Exception("�޷�ȡ�õ�ǰ�û���Ϣ��");
        }

        /// <summary>
        /// ҳ�������ļ���
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
        /// �û�ID
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
        /// �û�����
        /// </summary>
        public string UserName
        {
            get
            {
                return this.CurrentUser.ChineseName.Value;
            }
        }

        /// <summary>
        /// �û���ɫID
        /// </summary>
        public int UserRoleID
        {
            get
            {
                return this.CurrentUser.FK_Role.Value;
            }
        }

        #region ��̬����������ϵͳ������
        /// <summary>
        /// ��ȡ��ǰϵͳ������
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
        /// ���浱ǰϵͳ������
        /// </summary>
        /// <param name="ctx"></param>
        public static void SaveContext(SystemContext ctx)
        {
            System.Web.HttpContext.Current.Session["__Wicresoft_SystemContext"] = ctx;
        }
        #endregion

        #region ʵ������������ҳ��������
        /// <summary>
        /// ��ȡҳ��������
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
        /// ����ҳ��������
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
