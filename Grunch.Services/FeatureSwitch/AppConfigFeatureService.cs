using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunch.Services
{
    public class AppConfigFeatureService : IFeatureService
    {
        public IConfigurationManagerService ConfigurationManagerService { get; set; }

        public T GetFeatureSwitch<T>(Feature feature) where T : struct
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
            return ConfigurationManagerService.AppSettings.Get(feature.ToString());
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
    }
}
