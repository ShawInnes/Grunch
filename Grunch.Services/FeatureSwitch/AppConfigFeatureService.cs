using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Configuration;

namespace Grunch.Services
{
    public class AppConfigFeatureService : IFeatureService
    {
        private IConfigurationManagerService ConfigurationManagerService { get; set; }

        /// <summary>
        /// Initializes a new instance of the AppConfigFeatureService class.
        /// </summary>
        public AppConfigFeatureService(IConfigurationManagerService service)
        {
            ConfigurationManagerService = service;
        }

        private T GetFeatureSwitch<T>(Feature feature) where T : struct
        {
            var value = GetSwitchSetting(feature);

            T returnVal = default(T);
            if (String.IsNullOrEmpty(value))
                return returnVal;

            TryParse(value, out returnVal);
            return returnVal;
        }

        private string GetSwitchSetting(Feature feature)
        {
            string key = "feature:" + feature.ToString();

            return ConfigurationManagerService.AppSettings.Get(key);
        }

        private static bool TryParse<T>(string s, out T value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                value = (T)converter.ConvertFromString(s);
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }

        public bool HasFeature(Feature feature)
        {
            return GetFeatureSwitch<bool>(feature);
        }

        public Dictionary<Feature, bool> GetFeatures()
        {
            return Enum.GetValues(typeof(Feature)).Cast<Feature>().ToDictionary(k => k, k => HasFeature(k));
        }

        public void SetFeature(Feature feature, bool enabled)
        {
            Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
            string key = "feature:" + feature.ToString();
            
            if (!configuration.AppSettings.Settings.AllKeys.Any(p => p == key))
                configuration.AppSettings.Settings.Add(key, enabled.ToString());
            else
                configuration.AppSettings.Settings[key].Value = enabled.ToString();

            configuration.Save();
        }
    }
}
