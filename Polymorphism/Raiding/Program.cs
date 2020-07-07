using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroesCount = int.Parse(Console.ReadLine());
            var list = new List<BaseHero>();

            while(list.Count() != heroesCount)
            {
                var name = Console.ReadLine();
                var type = Console.ReadLine();
                switch (type)
                {
                    case "Paladin": list.Add(new Paladin(name));break;
                    case "Rogue": list.Add(new Rogue(name));break;
                    case "Druid": list.Add(new Druid(name));break;
                    case "Warrior": list.Add(new Warrior(name)); break;
                    default: Console.WriteLine("Invalid hero!");break;
                }
            }

            var bossHp = int.Parse(Console.ReadLine());
            int damage = 0;
            foreach (var item in list)
            {
                Console.WriteLine(item.CastAbility());
                damage += item.Power;
            }
            if (damage >= bossHp)
            {
                Console.WriteLine($"Victory!");
            }
            else 
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
