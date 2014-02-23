using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunch.Services
{
    public class TestableCodeWordService : CodeWordService, ITestableCodeWordService
    {
        public string[] Adjectives { get { return adjectives; } }
        public string[] Nouns { get { return nouns; } }
        public string[] Verbs { get { return verbs; } }
    }
}
