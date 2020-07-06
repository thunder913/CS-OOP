using System;
using System.Collections.Generic;
using System.Text;

namespace MillitaryElite
{
    public class LeutenantGeneral : Private, ILieutenantGeneral
    {
        public List<Private> Privates { get; set; }

        public LeutenantGeneral(string firstName, string lastName, string id, decimal salary) : base(firstName, lastName, id, salary)
        {
            Privates = new List<Private>();
        }

        public void AddPrivate(Private privat)
        {
            Privates.Add(privat);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Privates:");
            foreach (var privat in Privates)
            {
                sb.AppendLine(privat.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
