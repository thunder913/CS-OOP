using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Box
    {
        private double lenght;
        public double Lenght
        {
            get
            {
                return this.lenght;
            }

            set {
                if (value<5)
                {
                    throw  new Exception("test");
                }

                    this.lenght = value;

            }

        }

        public Box(double len)
        {
            this.Lenght = len;
        }
    }
}
