using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInstaller.Commands;

namespace DependencyInstaller.Test
{
    [TestClass]
    public class DependCommandTests
    {
        [TestMethod]
        public void TestDepend()
        {
            InstallItemManager mgr = new InstallItemManager();

            DependCommand.Run(new string[] { "DEPEND", "A" }, mgr);

            Assert.AreEqual(1, mgr.Count());
        }

        [TestMethod]
        public void TestDependWithDependencies()
        {
            InstallItemManager mgr = new InstallItemManager();

            DependCommand.Run(new string[] { "DEPEND", "A", "B", "C" }, mgr);

            Assert.AreEqual(3, mgr.Count());
        }
    }
}
