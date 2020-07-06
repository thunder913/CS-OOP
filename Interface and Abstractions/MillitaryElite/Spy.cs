using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public class Spy : ISpy
    {
        public Spy(string firstName, string lastName, string id, int codenumber) 
        {
            this.CodeNumber = codenumber;
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public int CodeNumber { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString().TrimEnd();
        }
    }
}
