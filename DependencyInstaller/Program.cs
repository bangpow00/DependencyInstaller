using System;
using DependencyInstaller.Commands;

namespace DependencyInstaller
{
    class Solution
    {

        static void Main(String[] args)
        {

            int _input_size = 0;
            _input_size = Convert.ToInt32(Console.ReadLine());
            string[] _input = new string[_input_size];
            string _input_item;
            for (int _input_i = 0; _input_i < _input_size; _input_i++)
            {
                _input_item = Console.ReadLine();
                _input[_input_i] = _input_item;
            }

            CommandRunner commandRunner = new CommandRunner(new InstallItemManager());
            foreach (var cmd in _input)
            {
                commandRunner.Run(cmd);
            }

        }

    }
 
}
