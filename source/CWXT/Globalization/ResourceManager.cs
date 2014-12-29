using System;
using System.IO;
using System.Globalization;
using System.Reflection;

namespace CWXT
{
    public class ResourceManager
    {
        private const string resourcePrefix = "strings";
        private System.Resources.ResourceManager resManager;
        private CultureInfo currentCulture;

        public static readonly ResourceManager Instance = new ResourceManager();

        private ResourceManager()
        {
            resManager = new System.Resources.ResourceManager(
                "CWXT.Globalization." + resourcePrefix, Assembly.GetExecutingAssembly());

            switch (System.Configuration.ConfigurationManager.AppSettings["Language"])
            {
                case "Chinese":
                    currentCulture = CultureInfo.CreateSpecificCulture("zh-cn");
                    break;
                case "English":
                    currentCulture = CultureInfo.CreateSpecificCulture("en-us");
                    break;
                case "Japanese":
                    currentCulture = CultureInfo.CreateSpecificCulture("ja-jp");
                    break;
                default:
                    currentCulture = CultureInfo.CreateSpecificCulture("zh-cn");
                    break;
            }
        }

        public string GetString(string key)
        {
            try
            {
                string str = resManager.GetString(key, currentCulture);
                return (str == null) ? string.Empty : str;
            }
            catch (System.Resources.MissingManifestResourceException)
            {
                return string.Empty;
            }
        }
    }
}