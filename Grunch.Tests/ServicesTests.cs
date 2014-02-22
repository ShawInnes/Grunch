using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Grunch.Services;
using Xunit.Extensions;
using Ploeh.AutoFixture;
using NSubstitute;
using System.Collections.Specialized;

namespace Grunch.Tests
{
    public class ServicesTests
    {
        [Theory, PropertyData("FullFeatureList")]
        public void FullFeatureHasFeature(Feature feature, bool expected)
        {
            IFeatureService service = new FullFeatureService();

            Assert.Equal(expected, service.HasFeature(feature));
        }

        public static IEnumerable<object[]> FullFeatureList
        {
            get
            {
                return Enum.GetValues(typeof(Feature)).Cast<Feature>().Select(p => new object[] { p, true });
            }
        }

        [Theory, PropertyData("ZeroFeatureList")]
        public void ZeroFeatureHasFeature(Feature feature, bool expected)
        {
            IFeatureService service = new ZeroFeatureService();

            Assert.Equal(expected, service.HasFeature(feature));
        }

        public static IEnumerable<object[]> ZeroFeatureList
        {
            get
            {
                return Enum.GetValues(typeof(Feature)).Cast<Feature>().Select(p => new object[] { p, false });
            }
        }

        [Fact]
        public void FullFeatureGetFeatures()
        {
            IFeatureService service = new FullFeatureService();

            Dictionary<Feature, bool> expected = Enum.GetValues(typeof(Feature)).Cast<Feature>().ToDictionary(k => k, v => true);

            Dictionary<Feature, bool> actual = service.GetFeatures();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ZeroFeatureGetFeatures()
        {
            IFeatureService service = new ZeroFeatureService();

            Dictionary<Feature, bool> expected = Enum.GetValues(typeof(Feature)).Cast<Feature>().ToDictionary(k => k, v => false);

            Dictionary<Feature, bool> actual = service.GetFeatures();

            Assert.Equal(expected, actual);
        }

        private static IFeatureService GetAppConfigFeatureService()
        {
            var mock = Substitute.For<IConfigurationManagerService>();

            NameValueCollection collection = new NameValueCollection();
            collection.Add(Feature.Login.ToString(), "True");
            mock.AppSettings.Returns(collection);

            IFeatureService service = new AppConfigFeatureService(mock);
            
            return service;
        }

        [Fact]
        public void AppConfigFeatureHasFeature()
        {
            IFeatureService service = GetAppConfigFeatureService();

            Assert.True(service.HasFeature(Feature.Login));
            Assert.False(service.HasFeature(Feature.Menus));
        }

        [Fact]
        public void AppConfigFeatureGetFeatures()
        {
            IFeatureService service = GetAppConfigFeatureService();
            
            Dictionary<Feature, bool> expected = Enum.GetValues(typeof(Feature)).Cast<Feature>().ToDictionary(k => k, v => false);
            expected[Feature.Login] = true;

            Dictionary<Feature, bool> actual = service.GetFeatures();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AppConfigFeatureSetFeature()
        {
            IFeatureService service = GetAppConfigFeatureService();

            Dictionary<Feature, bool> expected = Enum.GetValues(typeof(Feature)).Cast<Feature>().ToDictionary(k => k, v => false);
            expected[Feature.Login] = true;

            Assert.Equal(expected, service.GetFeatures());

            //expected[Feature.Menus] = true;
            //service.SetFeature(Feature.Menus, true);

            Assert.Equal(expected, service.GetFeatures());
        }
    }
}
