using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInstaller.Test
{
    [TestClass]
    public class InstallItemManagerTests
    {
        [TestMethod]
        public void TestInstallItemManagerAddItem()
        {

            InstallItemManager mgr = new InstallItemManager();

            var name = "A";
            InstallItem item = mgr.Retrieve(name);

            Assert.AreEqual(item.Name, name);
        }

        [TestMethod]
        public void TestInstallItemManagerAddItemDependancies()
        {

            InstallItemManager mgr = new InstallItemManager();

            InstallItem a = mgr.Retrieve("A");
            InstallItem b = mgr.Retrieve("B");
            InstallItem c = mgr.Retrieve("C");

            a.AddDependency(b);
            a.AddDependency(c);

            InstallItem item = mgr.Retrieve("A");
            Assert.AreEqual(2, item.Dependancies.Count);
        }

        [TestMethod]
        public void TestInstallItemManagerInstall()
        {

            InstallItemManager mgr = new InstallItemManager();

            InstallItem item = mgr.Retrieve("A");

            mgr.Install(item.Name);

            Assert.AreEqual(1, mgr.Installed().Count);
        }

        [TestMethod]
        public void TestInstallItemManagerInstallsOnlyValidItems()
        {

            InstallItemManager mgr = new InstallItemManager();

            InstallItem item = mgr.Retrieve("A");

            mgr.Install(item.Name);
            InstallItem bogus = mgr.Install("unknown");

            Assert.AreEqual(1, mgr.Installed().Count);
            Assert.IsNull(bogus);
        }

        [TestMethod]
        public void TestInstallItemManagerInstallWithDependacies()
        {

            InstallItemManager mgr = new InstallItemManager();

            InstallItem item = mgr.Retrieve("item");
            InstallItem dep1 = mgr.Retrieve("dep1");
            InstallItem dep2 = mgr.Retrieve("dep2");

            item.AddDependency(dep1);
            item.AddDependency(dep2);

            InstallItem i = mgr.Install(item.Name);

            Assert.AreEqual(1, mgr.Installed().Count);
            Assert.AreEqual(2, i.Dependancies.Count);
        }

        [TestMethod]
        public void TestInstallItemManagerRemove()
        {

            InstallItemManager mgr = new InstallItemManager();

            InstallItem item = mgr.Retrieve("item");

            mgr.Install(item.Name);
            mgr.Remove(item.Name);

            Assert.AreEqual(0, mgr.Installed().Count);
        }

        [TestMethod]
        public void TestInstallItemManagerInstallRemove()
        {

            InstallItemManager mgr = new InstallItemManager();

            InstallItem item1 = mgr.Retrieve("item1");
            InstallItem item2 = mgr.Retrieve("item2");

            mgr.Install(item1.Name);
            mgr.Install(item2.Name);
            mgr.Remove(item1.Name);

            Assert.AreEqual(1, mgr.Installed().Count);
            Assert.AreEqual(mgr.Installed()[0].Name, item2.Name);
        }
    }
}
