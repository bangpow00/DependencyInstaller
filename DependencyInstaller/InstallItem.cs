using System.Collections.Generic;
using System.Linq;


namespace DependencyInstaller
{
    public class InstallItem
    {
        public string Name { get; set; }

        public List<InstallItem> Dependancies { get; }

        public int InstallCount { get; set; } = 0;

        public InstallItem(string name)
        {
            Dependancies = new List<InstallItem>();
            Name = name;
        }

        public void AddDependency(InstallItem dep)
        {
            if ( !Dependancies.Any(x => (x.Name == dep.Name)) )
            {
                Dependancies.Add(dep);
            }
        }
    }
}
