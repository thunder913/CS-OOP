using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : Contracts.IRepository<IGun>
    {
        public GunRepository() { }
        private List<IGun> weapons = new List<IGun>();
        public IReadOnlyCollection<IGun> Models {get=>this.weapons; }

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }
            this.weapons.Add(model);
        }

        public IGun FindByName(string name)
        {
            var gun = weapons.FirstOrDefault(x => x.Name == name);
            if (gun == null)
            {
                return null;
            }
            return gun;
        }

        public bool Remove(IGun model)
        {
            if (weapons.Contains(model))
            {
                weapons.Remove(model);
                return true;
            }
            return false;
        }
    }
}
