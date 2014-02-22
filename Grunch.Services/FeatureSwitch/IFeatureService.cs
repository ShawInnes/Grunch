using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunch.Services
{
    public interface IFeatureService
    {
        bool HasFeature(Feature feature);
        T GetFeatureSwitch<T>(Feature feature) where T : struct;
    }
}
