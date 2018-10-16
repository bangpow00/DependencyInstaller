using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInstaller.Commands;

namespace DependencyInstaller.Test
{
    [TestClass]
    public class RemoveCommandTest
    {
        [TestMethod]
        public void TestRemove()
        {
            InstallItemManager mgr = new InstallItemManager();
            InstallItem item = mgr.Retrieve("A");

            mgr.Install(item.Name);

            RemoveCommand.Run(new string[] { "REMOVE", "A" }, mgr);
            Assert.AreEqual(0, mgr.Installed().Count);
        }

        [TestMethod]
        public void TestRemoveBogus()
        {
            InstallItemManager mgr = new InstallItemManager();
            InstallItem item = mgr.Retrieve("A");

            mgr.Install(item.Name);

            RemoveCommand.Run(new string[] { "REMOVE", "bogus" }, mgr);
            Assert.AreEqual(1, mgr.Installed().Count);
        }

        [TestMethod]
        public void TestRemoveWithDependency()
        {
            InstallItemManager mgr = new InstallItemManager();
            InstallItem a = mgr.Retrieve("A");
            InstallItem b = mgr.Retrieve("B");
            InstallItem c = mgr.Retrieve("C");

            a.AddDependency(b);
            a.AddDependency(c);

            mgr.Install(a.Name);
            mgr.Install(b.Name);
            mgr.Install(c.Name);

            RemoveCommand.Run(new string[] { "REMOVE", "A" }, mgr);

            Assert.AreEqual(0, mgr.Installed().Count);
        }

        [TestMethod]
        public void TestRemoveWithDependencyLeavesInstalled()
        {
            InstallItemManager mgr = new InstallItemManager();
            InstallItem a = mgr.Retrieve("A");
            InstallItem b = mgr.Retrieve("B");
            InstallItem c = mgr.Retrieve("C");
            InstallItem d = mgr.Retrieve("D");

            a.AddDependency(b);
            a.AddDependency(c);

            mgr.Install(a.Name);
            mgr.Install(b.Name);
            mgr.Install(c.Name);
            mgr.Install(d.Name);

            RemoveCommand.Run(new string[] { "REMOVE", "A" }, mgr);

            Assert.AreEqual(1, mgr.Installed().Count);
        }
    }
}
