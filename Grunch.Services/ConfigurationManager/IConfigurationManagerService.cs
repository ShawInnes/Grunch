using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunch.Services
{
    public interface IConfigurationManagerService
    {
        NameValueCollection AppSettings { get; }

        string ConnectionStrings(string name);

        T GetSection<T>(string sectionName);
    }
}