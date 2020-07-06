using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBirthdate,IName
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }

        public Pet(string name, DateTime birthdate) 
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
    }
}
