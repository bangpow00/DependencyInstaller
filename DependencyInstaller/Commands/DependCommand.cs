using System.Linq;

namespace DependencyInstaller.Commands
{
    public class DependCommand
    {
        public static void Run(string[] args, IInstallItemManager manager)
        {

            if (args.Length < 1)
            {
                return;
            }

            InstallItem item = manager.Retrieve(args[1]);

            foreach (var name in args.Skip(2))
            {
                InstallItem dep = manager.Retrieve(name);
                item.AddDependency(dep);
            }
        }
    }
}
