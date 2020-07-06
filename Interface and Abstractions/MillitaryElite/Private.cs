using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public class Private : IPrivate
    {
        public decimal Salary { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Private(string firstName, string lastName, string id, decimal salary) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}";
        }
    }
}
