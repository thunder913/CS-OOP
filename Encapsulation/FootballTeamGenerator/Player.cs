using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int sprint;
        private int endurance;
        private int dribble;
        private int passing;
        private int shooting;
        public float AverageStat => CalculateAverageStat();
        public float CalculateAverageStat() 
        {
            float sum = this.Sprint + this.Endurance + this.Dribble + this.Passing + this.Shooting;
            sum /= 5;
            sum = (float)Math.Round(((double)sum));
            return sum;
        }

        public string Name { get => this.name;
            set
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public int Sprint { get => this.sprint;
            set 
            {
                ValidateSkill(value, nameof(this.Sprint));
                this.sprint = value;
            } 
        }

        public int Endurance { get => this.endurance;
            set
            {
                ValidateSkill(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            set
            {
                ValidateSkill(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            set
            {
                ValidateSkill(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            set
            {
                ValidateSkill(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public Player(string name, int end, int spr, int dribl, int pass, int shoot) 
        {
            this.Name = name;
            this.Endurance = end;
            this.Sprint = spr;
            this.Dribble = dribl;
            this.Passing = pass;
            this.Shooting = shoot;

        }
        private void ValidateSkill(int number, string statName) 
        {
            if (number<0 || number>100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }
    }


    
}
