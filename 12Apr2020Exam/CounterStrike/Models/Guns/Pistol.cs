using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns.Contracts
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletcount) : base(name, bulletcount)
        {
        }
        public override int Fire()
        {
            if (this.BulletsCount >= 1)
            {
                this.BulletsCount -= 1;
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
