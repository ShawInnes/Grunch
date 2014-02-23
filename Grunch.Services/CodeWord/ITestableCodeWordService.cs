using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunch.Services
{
    public interface ITestableCodeWordService : ICodeWordService
    {
        string[] Verbs { get; }
        string[] Nouns { get; }
        string[] Adjectives { get; }

        int GetRandom(int maxValue);
    }
}
