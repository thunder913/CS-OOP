using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core.Contracts
{
    public class Controller : IController
    {
        public Controller() 
        {
        
        }
        private GunRepository guns = new GunRepository();
        private PlayerRepository players = new PlayerRepository();
        private IMap map = new Map();

        public string AddGun(string type, string name, int bulletsCount)
        {
            switch (type)
            {
                case "Pistol":
                    guns.Add(new Pistol(name, bulletsCount));
                    break;
                case "Rifle":
                    guns.Add(new Rifle(name, bulletsCount));
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            switch (type)
            {
                case "Terrorist":
                    players.Add(new Terrorist(username, health, armor, gun));
                    break;
                case "CounterTerrorist":
                    players.Add(new CounterTerrorist(username, health, armor, gun));
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            var reportPlayers = players.Models.ToList();
            reportPlayers = reportPlayers.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Username).ToList();
            var sb = new StringBuilder();
            foreach (var player in reportPlayers)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var map = new Map();
            var ListToGive = new List<IPlayer>();
            foreach (var item in players.Models.ToList())
            {
                ListToGive.Add(item);
            }
            return map.Start(ListToGive);
        }
    }
}
