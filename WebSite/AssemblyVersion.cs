﻿// 
// This code was generated by a tool. Any changes made manually will be lost
// the next time this code is regenerated.
// 

using System.Reflection;

[assembly: AssemblyVersion("0.1.0.1513")]
[assembly: AssemblyFileVersion("0.1.0.1513")]

namespace WebSite
{
	public static class VersionInfo
	{
		private static string _version = null;

		public static string Version { 
			get 
			{ 
				if (_version == null)
					_version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

				return _version;
			} 
		}
	}
}

