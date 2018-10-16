using System.Collections.Generic;
using System.Linq;

namespace DependencyInstaller
{
    public class InstallItemManager : IInstallItemManager
    {
        private List<InstallItem> _items;

        public InstallItemManager()
        {
            _items = new List<InstallItem>();
        }

        public InstallItem Retrieve(string name)
        {
            InstallItem item = _items.FirstOrDefault(x => (x.Name == name));
            if (item == null)
            {
                item = new InstallItem(name);
                _items.Add(item);
            }
            return item;
        }

        public InstallItem Install(string name)
        {
            InstallItem item = _items.FirstOrDefault(x => (x.Name == name)); ;
            if (item == null)
            {
                return null;
            }

            item.InstallCount++;

            return item;
        }

        public InstallItem Remove(string name)
        {
            InstallItem item = _items.FirstOrDefault(x => (x.Name == name)); ;
            if (item == null)
            {
                return null;
            }

            if (item.InstallCount > 0)
            {
                item.InstallCount--;
            }

            return item;
        }

        public List<InstallItem> Installed()
        {
            return _items.Where(x => x.InstallCount > 0).ToList();
        }

        public int Count()
        {
            return _items.Count;
        }
    }
}
