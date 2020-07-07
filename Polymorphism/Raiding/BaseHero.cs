using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name, int power) 
        {
            this.Name = name;
            this.Power = power;
        }
        public string Name { get; set; }
        public int Power { get; set; }
        
        public virtual string CastAbility() 
        {
            return $"{this.GetType().Name} - {this.Name} ";
        }
    }
}
