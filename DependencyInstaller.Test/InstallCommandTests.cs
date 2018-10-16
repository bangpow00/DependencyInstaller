using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInstaller.Commands;

namespace DependencyInstaller.Test
{
    [TestClass]
    public class InstallCommandTests
    {
        [TestMethod]
        public void TestInstall()
        {
            InstallItemManager mgr = new InstallItemManager();
            InstallItem item = mgr.Retrieve("A");

            InstallCommand.Run(new string[] { "INSTALL", "A" }, mgr);

            Assert.AreEqual(1, mgr.Installed().Count);
        }

        [TestMethod]
        public void TestInstallWithDependency()
        {
            InstallItemManager mgr = new InstallItemManager();
            InstallItem a = mgr.Retrieve("A");
            InstallItem b = mgr.Retrieve("B");
            InstallItem c = mgr.Retrieve("C");

            a.AddDependency(b);
            a.AddDependency(c);

            InstallCommand.Run(new string[] { "INSTALL", "A" }, mgr);

            Assert.AreEqual(3, mgr.Installed().Count);
        }

        [TestMethod]
        public void TestInstallWithDependency2()
        {
            InstallItemManager mgr = new InstallItemManager();
            InstallItem a = mgr.Retrieve("A");
            InstallItem b = mgr.Retrieve("B");
            InstallItem c = mgr.Retrieve("C");

            a.AddDependency(b);
            a.AddDependency(c);

            InstallCommand.Run(new string[] { "INSTALL", "A" }, mgr);

            InstallItem d = mgr.Retrieve("D");

            InstallCommand.Run(new string[] { "INSTALL", "D" }, mgr);

            Assert.AreEqual(4, mgr.Installed().Count);
        }
    }
}
