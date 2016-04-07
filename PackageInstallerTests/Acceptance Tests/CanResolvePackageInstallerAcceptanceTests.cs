using NUnit.Framework;
using PackageInstaller;

namespace PackageInstallerTests
{
	[TestFixture]
	public class CanResolvePackageInstallerAcceptanceTests
	{
		[Test]
		public void Case1()
		{
			var packageInputLines = new[]
			{
				"KittenService: ",
				"Leetmeme: Cyberportal",
				"Cyberportal: Ice",
				"CamelCaser: KittenService",
				"Fraudstream: Leetmeme",
				"Ice: "
			};

			var installationDependencyResolver = new InstallationDependencyResolver();
			var result = installationDependencyResolver.Resolver(packageInputLines);
			Assert.That(result, Is.EqualTo("KittenService, Ice, Cyberportal, Leetmeme, CamelCaser, Fraudstream"));
		}

		[Test]
		public void Case2()
		{
			var packageInputLines = new[]
			{
				"A: F",
				"B: A",
				"C: B",
				"D: C",
				"E: D",
				"F: "
			};

			var installationDependencyResolver = new InstallationDependencyResolver();
			var result = installationDependencyResolver.Resolver(packageInputLines);
			Assert.That(result, Is.EqualTo("F, A, B, C, D, E"));
		}

		[Test]
		public void Case3()
		{
			var packageInputLines = new string[]{};

			var installationDependencyResolver = new InstallationDependencyResolver();
			var result = installationDependencyResolver.Resolver(packageInputLines);
			Assert.That(result, Is.EqualTo(""));
		}

		[Test]
		public void Case4()
		{
			var packageInputLines = new[]
			{
				"A: C",
				"B: D",
				"C: E",
				"D: ",
				"E: B",
				"F: D"
			};

			var installationDependencyResolver = new InstallationDependencyResolver();
			var result = installationDependencyResolver.Resolver(packageInputLines);
			Assert.That(result, Is.EqualTo("D, B, E, C, F, A"));
		}
	}
}