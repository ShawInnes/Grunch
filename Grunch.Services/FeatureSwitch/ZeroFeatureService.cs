using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grunch.Services
{
    public class ZeroFeatureService : IFeatureService
    {
        public bool HasFeature(Feature feature)
        {
            return false;
        }

        public Dictionary<Feature, bool> GetFeatures()
        {
            return Enum.GetValues(typeof(Feature)).Cast<Feature>().ToDictionary(k => k, v => false);
        }


        public void SetFeature(Feature feature, bool enabled)
        {
            
        }
    }
}
