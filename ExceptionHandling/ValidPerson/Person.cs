using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ValidPerson
{
    public class Person
    {

        public Person(string firstName, string lastName, int age) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
        private int age;
        private string firstName;
        private string lastName;
        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (CheckName(value))
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                if (CheckName(value))
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }
            }
        }
        public int Age
        {
            get => this.age; set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("The age should be between [0:120]");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
        private bool CheckName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return true;
            }
            return false;
        }
    }
}
