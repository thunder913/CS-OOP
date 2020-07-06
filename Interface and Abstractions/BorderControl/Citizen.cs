using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    class Citizen : IIndividual, IBirthdate,IName
    {
        public string Name { get; set; }
        public string Id { get; set; }
        private int Age { get; set; }
        public DateTime Birthdate { get; set; }

        public Citizen(string name, int age, string id, DateTime birthdate) 
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

    }
}
