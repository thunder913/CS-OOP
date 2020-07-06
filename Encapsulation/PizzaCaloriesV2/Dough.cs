using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PizzaCaloriesV2
{
    class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private float weight;

        private string FlourType
        {
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

        private string BakingTechnique
        {
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

        private float Weight
        {
            get => this.weight;
            set
            {
                if (value<1 || value>200)
                {
                    Console.WriteLine("Dough weight should be in the range [1..200].");
                    Environment.Exit(0);
                }
                else
                {
                    this.weight = value;
                }
            }
        }
        public float caloriesPerGram => CalculateCalories();

        public Dough(string flourType, string bakingTechnique, float weight) 
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private float typeModifier;
        private float techniqueModifier;
        private float CalculateCalories() 
        {
            switch (this.FlourType)
            {
                case "White":
                    typeModifier = 1.5F;
                    break;
                case "Wholegrain":
                    typeModifier = 1.0f;
                    break;
            }

            switch (this.BakingTechnique)
            {
                case "Crispy":
                    this.techniqueModifier = 0.9F;
                    break;
                case "Chewy":
                    this.techniqueModifier = 1.1F;
                    break;
                case "Homemade":
                    this.techniqueModifier = 1.0F;
                break;
            }

            return this.Weight * 2 * techniqueModifier * typeModifier;
        }
    }
}
