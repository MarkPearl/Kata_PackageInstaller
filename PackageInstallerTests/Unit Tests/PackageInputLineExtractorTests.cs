using NUnit.Framework;
using PackageInstaller;

namespace PackageInstallerTests
{
	[TestFixture]
	public class PackageInputLineExtractorTests
	{
		private PackageInputLineExtractor _packageInputLineExtractor;

		[SetUp]
		public void Initialize()
		{
			_packageInputLineExtractor = new PackageInputLineExtractor();
		}

		[TestCase("CamelCaser: ", "CamelCaser")]
		[TestCase("KittenService: ", "KittenService")]
		public void GetPackageName(string packageInputLine, string expected)
		{
			var result = _packageInputLineExtractor.GetPackageName(packageInputLine);
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase("CamelCaser: KittenSerivice, Blah", "KittenSerivice, Blah")]
		[TestCase("KittenService: ", "")]
		public void GetPackageDependencyText(string packageInputLine, string expected)
		{
			var result = _packageInputLineExtractor.GetPackageDependencyText(packageInputLine);
			Assert.That(result, Is.EqualTo(expected));
		}
		 
	}
}