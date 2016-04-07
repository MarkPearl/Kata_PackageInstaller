using System;

namespace PackageInstaller
{
	public class UnrecognizedPackageDependencyException : Exception
	{
		public UnrecognizedPackageDependencyException(string unrecognizedPackageName) : 
			base("Package not recognized : " + unrecognizedPackageName)
		{
			
		}
	}
}