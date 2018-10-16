namespace DependencyInstaller.Commands
{
    public class InstallCommand
    {
        public static void Run(string[] args, IInstallItemManager manager)
        {

            if (args.Length < 1)
            {
                return;
            }

            InstallItem item = manager.Retrieve(args[1]);
            manager.Install(item.Name);

            foreach (var dep in item.Dependancies )
            {
                manager.Install(dep.Name);
            }

        }
    }
}
