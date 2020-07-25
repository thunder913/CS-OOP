using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        public Player(string name, int health, int armor, IGun gun)
        {
            this.Username = name;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
            }
            if (health <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
            }
            if (armor < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
            }
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGun);
            }
            IsAlive = true;
        }

        public string Username { get;private set; }

        public int Health { get; private set; }

        public int Armor { get; private set; }

        public IGun Gun { get; private set; }
        public bool IsAlive { get; private set; }

        public void TakeDamage(int points)
        {
            if (this.Armor > 0)
            {
                this.Armor -= points;
                if (Armor < 0)
                {
                    points = Math.Abs(Armor);
                    this.Armor = 0;
                }
                else
                {
                    return;
                }
            }

            if (this.Health > 0 && points > 0)
            {
                this.Health -= points;
                if (this.Health <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");
            return sb.ToString().TrimEnd();
        }
    }
}


