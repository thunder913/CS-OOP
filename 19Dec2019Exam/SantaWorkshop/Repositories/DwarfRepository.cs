using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private List<IDwarf> dwarfs = new List<IDwarf>();
        public IReadOnlyCollection<IDwarf> Models => dwarfs;

        public void Add(IDwarf model)
        {
            dwarfs.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            return dwarfs.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDwarf model)
        {
            return dwarfs.Remove(model);
        }
    }
}
