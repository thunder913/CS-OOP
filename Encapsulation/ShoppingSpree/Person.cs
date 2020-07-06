using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace ShoppingSpree
{
    class Person
    {
        public string name;
        private decimal money;
        private List<Product> bag;

        private string Name 
        {
            get 
            {
                return this.name;
            }
            set 
            {
                if (value == string.Empty || value == "" || value == " ")
                {
                    throw new Exception("Name cannot be empty");
                }
                else 
                {
                    this.name = value;
                }
            }
        }

        private decimal Money 
        {
            get 
            {
                return this.money;
            }
            set
            {
                if (value<0)
                {
                    throw new Exception("Money cannot be negative");
                }
                else 
                {
                    this.money = value;
                }
            }
        }

        public Person(string name, decimal money) 
        {
            this.Name = name;
            this.Money = money;
            bag = new List<Product>();
        }

        public string AddProduct(Product product) 
        {
            if (this.money >= product.cost)
            {
                this.bag.Add(product);
                this.money -= product.cost;
                return $"{this.name} bought {product.Name}";
            }
            return $"{this.name} can't afford {product.Name}";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.name} - ");
            if (bag.Any())
            {
                sb.Append(string.Join(", ", bag.Select(x => x.Name)));
            }
            else 
            {
                sb.Append("Nothing bought");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
