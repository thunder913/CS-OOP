using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FootballTeamGeneratorV2
{
    class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public int AverageStats => CalculateStat();

        private int CalculateStat() 
        {
            double sum = Endurance + Sprint + Dribble + Passing + Shooting;
            sum /= 5;
            sum = Math.Round(sum);
            return int.Parse(sum.ToString());
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            set
            {
                StatValidation(value, "Endurance");
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            set
            {
                StatValidation(value, "Sprint");
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            set
            {
                StatValidation(value, "Dribble");
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            set
            {
                StatValidation(value, "Passing");
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            set
            {
                StatValidation(value, "Shooting");
                this.shooting = value;
            }
        }

        public Player(string name, int endurance, int sprint, int dribble, int pasing, int shooting) 
        {
            this.name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = pasing;
            this.shooting = shooting;
        }


        private void StatValidation(int stat, string name)
        {
            if (stat < 0 || stat > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }
    }
}
