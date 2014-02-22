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

        public T GetFeatureSwitch<T>(Feature feature)
            where T : struct
        {
            return default(T);
        }
    }
}
