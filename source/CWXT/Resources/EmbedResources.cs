using System;

namespace CWXT.Resources
{
	/// <summary>
	/// EmbedResources 的摘要说明。
	/// </summary>
	public class EmbedResources
	{
		protected EmbedResources()
		{
		}

		/// <summary>
		/// 将资源文件放入缓存
		/// </summary>
		public static void CacheInClient()
		{
//			System.Web.HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddMonths(1));
		}

		public static void HandleResourceRequest()
		{
			string url = System.Web.HttpContext.Current.Request.Url.LocalPath;

			if(url.EndsWith("PageScript.js.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendScriptResource(PageScript_JS);
				return;
			}
			
			if(url.EndsWith("ImageButton.htc.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendHTCResource(ImageButton_HTC);
				return;
			}
			
			if(url.EndsWith("DataGrid.htc.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendHTCResource(DataGrid_HTC);
				return;
			}

			if(url.EndsWith("sort.htc.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendHTCResource(SORT_HTC);
				return;
			}

			if(url.EndsWith("dragdrop.htc.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendHTCResource(DRAGDROP_HTC);
				return;
			}
			
			if(url.EndsWith("CustomerSiteStyle.css.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendCSSResource(CustomerSiteStyle_CSS);
				return;
			}
			
			if(url.EndsWith("Calendar30.js.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendScriptResource(Calendar30_JS);
				return;
			}

			if(url.EndsWith("TAB_FOCUS.gif.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendGIFResource(BTN_CUR_GIF);
				return;
			}

			if(url.EndsWith("TAB_BLUR.gif.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendGIFResource(BTN_GIF);
				return;
			}

			if(url.EndsWith("user.gif.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendGIFResource(USER_GIF);
				return;
			}

			if(url.EndsWith("search.gif.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendGIFResource(SEARCH_GIF);
				return;
			}

			if(url.EndsWith("AlertScript.js.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendScriptResource(AlertScript_JS);
				return;
			}

			if(url.EndsWith("SortTable.js.aspx"))
			{
				CacheInClient();
				GlobalFacade.Utils.SendScriptResource(SortTable_JS);
				return;
			}

		}

		private static System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

		private static string __PageScript_JS = string.Empty;
		public static string PageScript_JS
		{
			get
			{
				if(__PageScript_JS == string.Empty)
				{
					__PageScript_JS = GlobalFacade.Utils.LoadEmbedResource(assembly, "CWXT.Resources.PageScript.js");
				}
				return __PageScript_JS;
			}
		}

		private static string __AlertScript_JS = string.Empty;
		public static string AlertScript_JS
		{
			get
			{
				if(__AlertScript_JS == string.Empty)
				{
					__AlertScript_JS = GlobalFacade.Utils.LoadEmbedResource(assembly, "CWXT.Resources.AlertScript.js");
				}
				return __AlertScript_JS;
			}
		}

		private static string __ImageButton_HTC = string.Empty;
		public static string ImageButton_HTC
		{
			get
			{
				if(__ImageButton_HTC == string.Empty)
				{
					__ImageButton_HTC = GlobalFacade.Utils.LoadEmbedResource(assembly, "CWXT.Resources.ImageButton.htc");
				}
				return __ImageButton_HTC;
			}
		}

		private static string __DataGrid_HTC = string.Empty;
		public static string DataGrid_HTC
		{
			get
			{
				if(__DataGrid_HTC == string.Empty)
				{
					__DataGrid_HTC = GlobalFacade.Utils.LoadEmbedResource(assembly, "CWXT.Resources.DataGrid.htc");
				}
				return __DataGrid_HTC;
			}
		}

		private static string __Calendar30_JS = string.Empty;
		public static string Calendar30_JS
		{
			get
			{
				if(__Calendar30_JS == string.Empty)
				{
					__Calendar30_JS = GlobalFacade.Utils.LoadEmbedResource(assembly, "CWXT.Resources.Calendar30.js");
				}
				return __Calendar30_JS;
			}
		}

		private static string __SortTable_JS = string.Empty;
		public static string SortTable_JS
		{
			get
			{
				if(__SortTable_JS == string.Empty)
				{
					__SortTable_JS = GlobalFacade.Utils.LoadEmbedResource(assembly, "CWXT.Resources.SortTable.js");
				}
				return __SortTable_JS;
			}
		}

		private static string __CustomerSiteStyle_CSS = string.Empty;
		public static string CustomerSiteStyle_CSS
		{
			get
			{
				if(__CustomerSiteStyle_CSS == string.Empty)
				{
					__CustomerSiteStyle_CSS = GlobalFacade.Utils.LoadEmbedResource(assembly, "CWXT.Resources.CustomerSiteStyle.css");
				}
				return __CustomerSiteStyle_CSS;
			}
		}

		private static byte[] __BTN_CUR_GIF = null;
		public static byte[] BTN_CUR_GIF
		{
			get
			{
				if(__BTN_CUR_GIF == null)
				{
					__BTN_CUR_GIF = GlobalFacade.Utils.LoadEmbedImage(assembly, "CWXT.Resources.TAB_FOCUS.gif");
				}
				return __BTN_CUR_GIF;
			}
		}

		private static byte[] __BTN_GIF = null;
		public static byte[] BTN_GIF
		{
			get
			{
				if(__BTN_GIF == null)
				{
					__BTN_GIF = GlobalFacade.Utils.LoadEmbedImage(assembly, "CWXT.Resources.TAB_BLUR.gif");
				}
				return __BTN_GIF;
			}
		}

		private static byte[] __USER_GIF = null;
		public static byte[] USER_GIF
		{
			get
			{
				if(__USER_GIF == null)
				{
					__USER_GIF = GlobalFacade.Utils.LoadEmbedImage(assembly, "CWXT.Resources.user.gif");
				}
				return __USER_GIF;
			}
		}

		private static byte[] __SEARCH_GIF = null;
		public static byte[] SEARCH_GIF
		{
			get
			{
				if(__SEARCH_GIF == null)
				{
					__SEARCH_GIF = GlobalFacade.Utils.LoadEmbedImage(assembly, "CWXT.Resources.search.gif");
				}
				return __SEARCH_GIF;
			}
		}

		private static string __SORT_HTC = null;
		public static string SORT_HTC
		{
			get
			{
				if(__SORT_HTC == null)
				{
					__SORT_HTC = GlobalFacade.Utils.LoadEmbedResource(assembly, "CWXT.Resources.sort.htc");
				}
				return __SORT_HTC;
			}
		}

		private static string __DRAGDROP_HTC = null;
		public static string DRAGDROP_HTC
		{
			get
			{
				if(__DRAGDROP_HTC == null)
				{
					__DRAGDROP_HTC = GlobalFacade.Utils.LoadEmbedResource(assembly, "CWXT.Resources.dragdrop.htc");
				}
				return __DRAGDROP_HTC;
			}
		}

	}
}
