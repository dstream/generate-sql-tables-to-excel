using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GenerateSqlTablesToExcel
{
    public sealed class AppSettings
    {
        #region singleton
        //http://csharpindepth.com/Articles/General/Singleton.aspx
        private static readonly Lazy<AppSettings> lazy = new Lazy<AppSettings>(() => new AppSettings());

        public static AppSettings Instance { get { return lazy.Value; } }

        private AppSettings()
        {
        }
        #endregion

        public string TablePrefix { get { return GetApplicationSetting("TablePrefix", ""); } }             

        #region functions
        private string GetApplicationSetting(string key, string defaultValue)
        {
            var val = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(val) ? defaultValue : val;
        }

        private int GetApplicationSetting(string key, int defaultValue)
        {
            var val = ConfigurationManager.AppSettings[key];
            if (int.TryParse(val, out int result))
                return result;
            else return defaultValue;
        }

        #endregion
    }
}