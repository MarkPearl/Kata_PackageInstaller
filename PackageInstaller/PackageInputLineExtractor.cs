﻿using System;

namespace PackageInstaller
{
	public class PackageInputLineExtractor
	{
		private const string PackageInputLineNameToken = ": ";

		public string GetPackageName(string packageInputLine)
		{
			var index = IndexOfNameToken(packageInputLine);
			var packageName = packageInputLine.Substring(0, index);
			return packageName;
		}
	
		public string GetPackageDependencyText(string packageInputLine)
		{
			var index = IndexOfNameToken(packageInputLine);
			return packageInputLine.Substring(index + 1).Trim();
		}

		private static int IndexOfNameToken(string packageInputLine)
		{
			return packageInputLine.IndexOf(PackageInputLineNameToken, StringComparison.Ordinal);
		}

	}
}