using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime;

namespace MillitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            var listPeople = new List<ISoldier>();
            var input = Console.ReadLine().Split();
            while(input[0] != "End")
            {
                var soldierType = input[0];
                var id = input[1];
                var firstName = input[2];
                var lastName = input[3];
                var salary = decimal.Parse(input[4]);
                try
                {
                    switch (soldierType)
                    {
                        case "Private":
                            listPeople.Add(new Private(firstName, lastName, id, salary));
                            break;
                        case "LieutenantGeneral":
                            var LeutenantGeneral = new LeutenantGeneral(firstName, lastName, id, salary);
                            for (int i = 5; i < input.Count(); i++)
                            {
                                var privateId = input[i];
                                var privat = (Private)listPeople.FirstOrDefault(x => x.Id == privateId);
                                LeutenantGeneral.AddPrivate(privat);
                            }
                            listPeople.Add(LeutenantGeneral);
                            break;
                        case "Engineer":
                            var engineer = new Engineer(firstName, lastName, id, salary, input[5]);
                            for (int i = 6; i < input.Count(); i++)
                            {
                                var repairPart = input[i];
                                i++;
                                var repairHours = int.Parse(input[i]);
                                var repair = new Repair(repairPart, repairHours);
                                engineer.AddRepair(repair);
                            }
                                listPeople.Add(engineer);
                            break;
                        case "Commando":
                            var commando = new Commando(firstName, lastName, id, salary, input[5]);
                            for (int i = 6; i < input.Count(); i++)
                            {
                                try
                                {
                                    var missionName = input[i];
                                    i++;
                                    var missionState = input[i];
                                    var mission = new Mission(missionName, missionState);
                                    commando.AddMission(mission);
                                }
                                catch(Exception)
                                {
                                    
                                }
                            }
                            listPeople.Add(commando);
                            break;
                        case "Spy":
                            var spy = new Spy(firstName, lastName, id, int.Parse(input[4]));
                            listPeople.Add(spy);
                            break;
                    }
                }
                catch (Exception)
                {
                    
                }

                input = Console.ReadLine().Split();
            }

            foreach (var item in listPeople)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
