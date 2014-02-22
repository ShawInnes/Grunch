using Grunch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebSite.Extensions
{
    public abstract class FeatureWebViewPage<TModel> : WebViewPage<TModel> where TModel : class
    {
        private IFeatureService Feature { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();

            Feature = DependencyResolver.Current.GetService<IFeatureService>();
        }

        public bool HasFeature(Grunch.Services.Feature feature)
        {
            return Feature.HasFeature(feature);
        }
    }

    public abstract class FeatureWebViewPage : WebViewPage
    {
        private IFeatureService Feature { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();
            
            Feature = DependencyResolver.Current.GetService<IFeatureService>();
        }

        public bool HasFeature(Grunch.Services.Feature feature)
        {
            return Feature.HasFeature(feature);
        }
    }
}