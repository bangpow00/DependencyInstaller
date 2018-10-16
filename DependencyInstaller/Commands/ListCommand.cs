using System;

namespace DependencyInstaller.Commands
{
    public class ListCommand
    {
        public static void Run(IInstallItemManager mgr)
        {
            Console.WriteLine("Installed:");
            foreach (var item in mgr.Installed())
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
