using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns.Contracts
{
    public class Rifle : Gun
    {
        public Rifle(string name, int bulletcount) : base(name, bulletcount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount >= 10)
            {
                this.BulletsCount -= 10;
                return 10;
            }
            int bullets = this.BulletsCount;
            this.BulletsCount = 0;
            return bullets;
        }
    }
}
