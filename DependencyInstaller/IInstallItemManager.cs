using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInstaller
{
    public interface IInstallItemManager
    {
        InstallItem Retrieve(string name);
        InstallItem Install(string name);
        InstallItem Remove(string name);
        List<InstallItem> Installed();
        int Count();
    }
}
