using NUnit.Framework;
using PackageInstaller;

namespace PackageInstallerTests
{
	[TestFixture]
	public class InstallationDependencyResolverTests
	{
		private InstallationDependencyResolver _installationDependencyResolver;

		[SetUp]
		public void Initialize()
		{
			_installationDependencyResolver = new InstallationDependencyResolver();
		}

		[TestCase("CamelCaser: ", "CamelCaser")]
		[TestCase("KittenService: ", "KittenService")]
		public void PackageWithNoDependencies_Returns_PackageName(string packageInputLine, string expected)
		{
			var packageInputLines = new[] { packageInputLine };

			var result = _installationDependencyResolver.Resolver(packageInputLines);
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void TwoPackagesWithNoDependencies_Returns_PackageNamesInOrder()
		{
			var packageInputLines = new[] { "KittenService: ", "CamelCaser: " };

			var result = _installationDependencyResolver.Resolver(packageInputLines);
			Assert.That(result, Is.EqualTo("KittenService, CamelCaser"));
		}

		[Test]
		public void TwoPackagesWithOneDependency_Returns_DependencyFirstThenDependentPackage()
		{
			var packageInputLines = new[] { "KittenService: CamelCaser", "CamelCaser: " };

			var result = _installationDependencyResolver.Resolver(packageInputLines);
			Assert.That(result, Is.EqualTo("CamelCaser, KittenService"));
		}

		[Test]
		public void ResolvePackagesInCorrectOrder()
		{
			var packageInputLines = new[]
			{
				"Leetmeme: Cyberportal",
				"Cyberportal: Ice",
				"Ice: "
			};

			var result = _installationDependencyResolver.Resolver(packageInputLines);
			Assert.That(result, Is.EqualTo("Ice, Cyberportal, Leetmeme"));
		}
	}
}
