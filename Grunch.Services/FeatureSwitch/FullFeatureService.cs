using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grunch.Services
{
    public class FullFeatureService : IFeatureService
    {
        public bool HasFeature(Feature feature)
        {
            return true;
        }

        public Dictionary<Feature, bool> GetFeatures()
        {
            return Enum.GetValues(typeof(Feature)).Cast<Feature>().ToDictionary(k => k, v => true);
        }


        public void SetFeature(Feature feature, bool enabled)
        {
            
        }
    }
}