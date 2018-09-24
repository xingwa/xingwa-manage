using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace xingwaWinFormUI.Win32
{
	public static class ShellHelper
	{
		private static readonly Regex r = new Regex("c=\\[c:(?<key>.+)\\]", RegexOptions.Compiled);
		public static void ApplicationExit()
		{
			ShellHelper.ApplicationExit(0);
		}
		public static void ApplicationExit(int exitCode)
		{
			try
			{
				Environment.Exit(exitCode);
			}
			catch
			{
			}
		}
		public static string ParseUrl(string url, IDictionary<string, string> credentials)
		{
			if (credentials != null)
			{
				Match match = ShellHelper.r.Match(url);
				if (!match.Success)
				{
					return url;
				}
				string str = "";
				string text = match.Result("${key}");
				if (string.IsNullOrEmpty(text))
				{
					return url;
				}
				if (credentials.ContainsKey(text))
				{
					str = HttpWebRequestHelper.UrlEncode(credentials[text]);
				}
				url = ShellHelper.r.Replace(url, "c=" + str);
			}
			return url;
		}
		public static void StartUrl(string url)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder(ShellHelper.ParseString((string)Registry.ClassesRoot.OpenSubKey("HTTP\\shell\\open\\command", false).GetValue(string.Empty, string.Empty)));
				stringBuilder.Append(" ");
				stringBuilder.Append(url);
				NativeMethods.WinExec(stringBuilder.ToString(), 5);
			}
			catch
			{
				try
				{
					StringBuilder stringBuilder2 = new StringBuilder(ShellHelper.ParseString((string)Registry.ClassesRoot.OpenSubKey("Applications\\iexplore.exe\\shell\\open\\command", false).GetValue(string.Empty, string.Empty)));
					stringBuilder2.Append(" ");
					stringBuilder2.Append(url);
					NativeMethods.WinExec(stringBuilder2.ToString(), 5);
				}
				catch
				{
				}
			}
		}
		public static void StartUrl(string url, IDictionary<string, string> credentials)
		{
			ShellHelper.StartUrl(ShellHelper.ParseUrl(url, credentials));
		}
		private static string ParseString(string value)
		{
			if (value.Substring(0, 1) == "\"")
			{
				int num = value.IndexOf("\"", 1);
				return value.Substring(0, num + 1);
			}
			return value.Split(new char[]
			{
				' '
			})[0];
		}
	}
}
