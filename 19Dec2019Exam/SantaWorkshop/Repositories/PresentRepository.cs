using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        public List<IPresent> presents = new List<IPresent>();
        public IReadOnlyCollection<IPresent> Models => this.presents;

        public void Add(IPresent model)
        {
            this.presents.Add(model);
        }

        public IPresent FindByName(string name)
        {
            return this.presents.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPresent model)
        {
            return this.presents.Remove(model);
        }
    }
}
