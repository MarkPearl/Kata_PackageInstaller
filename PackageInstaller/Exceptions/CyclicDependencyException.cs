using System;

namespace PackageInstaller
{
	public class CyclicDependencyException : Exception
	{
		public CyclicDependencyException(string cyclicDependencyPackage) : base("Package with first detected cyclic reference is : " + cyclicDependencyPackage)
		{
			
		}
	}
}