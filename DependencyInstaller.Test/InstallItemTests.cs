using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInstaller.Test
{
    [TestClass]
    public class InstallItemTests
    {
        [TestMethod]
        public void TestInstallItemCreate()
        {
            var name = "foo";
            InstallItem item = new InstallItem(name);

            Assert.AreEqual(item.Name, name);
        }

        [TestMethod]
        public void TestInstallItemDependancy()
        {
            InstallItem item = new InstallItem("item");
            InstallItem dep = new InstallItem("dep");

            item.AddDependency(dep);

            Assert.AreEqual(item.Dependancies[0], dep);

        }

        [TestMethod]
        public void TestInstallItemDependancies()
        {
            InstallItem item = new InstallItem("item");
            InstallItem dep1 = new InstallItem("dep1");
            InstallItem dep2 = new InstallItem("dep2");
            InstallItem dep3 = new InstallItem("dep3");

            item.AddDependency(dep1);
            item.AddDependency(dep2);
            item.AddDependency(dep3);

            Assert.AreEqual(3, item.Dependancies.Count);
        }

    }
}
