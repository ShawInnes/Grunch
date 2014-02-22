using Grunch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite
{
    public static class View
    {
        public static IFeatureService FeatureService { get; set; }

        public static bool HasFeature(Feature feature)
        {
            return FeatureService.HasFeature(feature);
        }
    }
}