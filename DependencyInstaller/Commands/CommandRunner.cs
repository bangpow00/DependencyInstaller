using System;
using System.Collections.Generic;

namespace DependencyInstaller.Commands
{
    public class CommandRunner
    {
        private IInstallItemManager _mgr;
        private List<string> _lastcmd;

        public string[] LastCommand
        {
            get
            {
                return _lastcmd.ToArray();
            }
        }

        // use interface for mock testing if needed
        public CommandRunner(IInstallItemManager installmanager)
        {
            _mgr = installmanager;
            _lastcmd = new List<string>();

        }

        public void Run(string cmd)
        {
            string[] commands = Array.ConvertAll(cmd.Split(' '), item => item.Trim());
            switch (commands[0])
            {
                case "DEPEND":
                    DependCommand.Run(commands, _mgr);
                    break;
                case "INSTALL":
                    InstallCommand.Run(commands, _mgr);
                    break;
                case "LIST":
                    ListCommand.Run(_mgr);
                    break;
                case "REMOVE":
                    RemoveCommand.Run(commands, _mgr);
                    break;
                default:
                    break;

            }
        }
    }
}
