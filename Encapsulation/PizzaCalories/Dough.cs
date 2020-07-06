using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Dough
    {
        private double weight;
        private double caloriesPerGram;
        private string bakingTechnique;
        private string BakingTechnique {
            get => this.bakingTechnique;
            set
            {
                if (value != "Crispy" && value != "Chewy" && value != "Homemade")
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(0);
                }
                else
                {
                    this.bakingTechnique = value;
                }
            }
        }
        private string flourType;
        private string FlourType {
            get => this.flourType;
            set
            {
                if (value != "White" && value != "Wholegrain")
                {
                    Console.WriteLine("Invalid type of dough");
                    Environment.Exit(0);
                }
                else
                {
                    this.flourType = value;
                }
            }
        }
        private double Weight { get { return this.weight; } set 
            {
                if (value>=1 && value<=200)
                {
                    this.weight = value;
                }
                else 
                {
                    Console.WriteLine("Dough weight should be in the range [1..200].");
                    Environment.Exit(0);

                }

            } }
        private const int defaultCalories = 2;
        public Dough(string bakingTechnique, string flourType, double weight) 
        {
            this.BakingTechnique = bakingTechnique;
            this.FlourType = flourType;
            this.Weight = weight;
        }

        public double CaloriesPerGram => GetCalories();
        private double GetCalories() 
        {
            double bakingTechniqueModifier = 1;
            double flourTypeModifier = 1;
            switch (this.BakingTechnique) 
            {
                case "Crispy": bakingTechniqueModifier = 0.9; break;
                case "Chewy": bakingTechniqueModifier = 1.1;break;
                case "Homemade": bakingTechniqueModifier = 1;break;
            }
            switch (this.FlourType)
            {
                case "White": flourTypeModifier = 1.5;break;
                case "Wholegrain": flourTypeModifier = 1;break;
            }

            return this.Weight * defaultCalories * bakingTechniqueModifier * flourTypeModifier;
        }

    }
}
