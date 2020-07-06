using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Coffee:HotBeverage
    {
        public double CoffeeMillilitres = 50;
        public decimal CoffeePrice = 3.50M;
        public double Caffeine { get; set; }

        public Coffee(string name, double caffein)
            : base(name, 3.50M, 50) 
        {
            this.Caffeine = caffein;
        }
    }
}
