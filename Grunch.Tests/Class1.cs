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
        private Feature feature;
        [Theory, PropertyData("FeatureList")]
        public void FullFeatureSwitchTests(Feature feature, bool expected)
        {
            IFeatureService service = new FullFeatureService();

            Assert.Equal(expected, service.HasFeature(feature));
        }

        public static IEnumerable<object[]> FeatureList
        {
            get
            {
                return Enum.GetValues(typeof(Feature)).Cast<Feature>().Select(p => new object[] { p, true });
            }
        }

        [Fact]
        public void AppConfigFeatureSwitchTests()
        {
            var mock = Substitute.For<IConfigurationManagerService>();

            // this seems a bit messy, but it'll do.
            NameValueCollection collection = new NameValueCollection();
            collection.Add(Feature.Login.ToString(), "True");
            collection.Add(Feature.Menus.ToString(), "False");
            mock.AppSettings.Returns(collection);

            IFeatureService service = new AppConfigFeatureService() { ConfigurationManagerService = mock };

            Assert.True(service.HasFeature(Feature.Login));
            Assert.False(service.HasFeature(Feature.Menus));
        }
    }
}
