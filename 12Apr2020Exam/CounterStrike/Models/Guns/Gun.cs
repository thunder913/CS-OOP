using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns.Contracts
{
    public abstract class Gun : IGun
    {
        public Gun(string name, int bulletcount) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidGun);
            }
            if (bulletcount < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
            }
            this.Name = name;
            this.BulletsCount = bulletcount;
        }
        public string Name { get;private set; }

        public int BulletsCount { get;protected set; }

        public abstract int Fire();
    }
}
