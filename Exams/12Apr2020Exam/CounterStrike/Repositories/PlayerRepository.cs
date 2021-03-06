﻿using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        public PlayerRepository() { }
        private List<IPlayer> players = new List<IPlayer>();
        public IReadOnlyCollection<IPlayer> Models => players;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }
            this.players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            var player = players.FirstOrDefault(x => x.Username == name);
            if (player == null)
            {
                return null;
            }
            return player;
        }

        public bool Remove(IPlayer model)
        {

            if (players.Contains(model))
            {
                players.Remove(model);
                return true;
            }
            return false;
        }
    }
}
