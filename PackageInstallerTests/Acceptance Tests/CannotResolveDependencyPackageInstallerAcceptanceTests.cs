using NUnit.Framework;
using PackageInstaller;

namespace PackageInstallerTests
{
	[TestFixture]
	public class CannotResolveDependencyPackageInstallerAcceptanceTests
	{
		[Test]
		public void UnrecognizedPackageDependencyDetected()
		{
			var packageInputLines = new[]
			{
				"Leetmeme: Unknown"
			};

			var installationDependencyResolver = new InstallationDependencyResolver();
			Assert.Throws<UnrecognizedPackageDependencyException>(() => installationDependencyResolver.Resolver(packageInputLines));
		}

		[Test]
		public void CyclicDependencyDetected()
		{
			var packageInputLines = new[]
			{
				"KittenService: ",
				"Leetmeme: Cyberportal",
				"Cyberportal: Ice",
				"CamelCaser: KittenService",
				"Fraudstream: ",
				"Ice: Leetmeme"
			};

			var installationDependencyResolver = new InstallationDependencyResolver();
			Assert.Throws<CyclicDependencyException>(() => installationDependencyResolver.Resolver(packageInputLines));
		}
	}
}