using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Product
    {
        public decimal cost;
        public string Name { get; set; }
        private decimal Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
                else
                {
                    this.cost = value;
                }
            }
        }

        public Product(string name, decimal cost) 
        {
            this.Name = name;
            this.Cost = cost;
        }
    }
}
