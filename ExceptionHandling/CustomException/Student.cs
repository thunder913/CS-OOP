using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomException
{
    class Student
    {
        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
        private string name;
        public string Name
        {
            get => this.name; set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NameException("The name cannot be null, empty or whitespace!");
                }
                else if (value.Any(x => !char.IsLetter(x)))
                {
                    throw new NameException("Names should consist of only letters!");
                }
                this.name = value;
            }
        }

        public string Email { get; set; }
    }
}
