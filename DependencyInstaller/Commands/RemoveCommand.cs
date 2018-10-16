namespace DependencyInstaller.Commands
{
    public class RemoveCommand
    {
        public static void Run(string[] args, IInstallItemManager manager)
        {

            if (args.Length < 1)
            {
                return;
            }

            InstallItem item = manager.Retrieve(args[1]);

            foreach (var dep in item.Dependancies)
            {
                manager.Remove(dep.Name);
            }

            manager.Remove(item.Name);
        }
    }
}
