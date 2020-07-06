using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public class Citizen : IResident,IPerson
    {

        public Citizen(string name, string country, int age) 
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        string IResident.GetName() 
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
        string IPerson.GetName()
        {
            return this.Name;
        }
    }
}
