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
using Ploeh.AutoFixture.Kernel;
using System.Reflection;

namespace Grunch.Tests
{
    public class CodeWordServiceTests
    {
        [Fact]
        public void CodeWordServiceCheckLists()
        {
            TestableCodeWordService service = new TestableCodeWordService();

            Assert.Equal(100, service.Adjectives.Length);
            Assert.Equal(100, service.Nouns.Length);
            Assert.Equal(100, service.Verbs.Length);
        }

        [Fact]
        public void CodeWordServiceMockRandomValue()
        {
            var service = Substitute.For<ITestableCodeWordService>();

            Assert.NotEqual(100, service.GetRandom(10));

            service.GetRandom(100).Returns(10);

            Assert.Equal(10, service.GetRandom(100));
        }

        [Fact]
        public void CodeWordServiceMockLists()
        {
            var service = Substitute.For<ITestableCodeWordService>();

            string[] adjectives = new string[] { "adjective1", "adjective2", "adjective3" };
            service.Adjectives.Returns(adjectives);

            string[] nouns = new string[] { "noun1", "noun2", "noun3" };
            service.Nouns.Returns(nouns);

            string[] verbs = new string[] { "verb1", "verb2", "verb3" };
            service.Verbs.Returns(verbs);

            Assert.Equal(adjectives, service.Adjectives);
            Assert.Equal(nouns, service.Nouns);
            Assert.Equal(verbs, service.Verbs);
        }

        [Fact]
        public void CodeWordServiceMockListsAndRandomValue()
        {
            var service = Substitute.For<TestableCodeWordService>();
            
            service.GetRandom(1).ReturnsForAnyArgs(10);

            Assert.Equal("national world will", service.GetCodeWord());
        }
    }
}
