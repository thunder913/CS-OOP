using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Problem1
{
    class Box
    {
        private double length;
        private double Length
        {
            set
            {
                if (Validate(value, nameof(Length)))
                {
                    this.length = value;
                }
            }

            get
            {
                return this.length;
            }
        }

        private double width;
        private double Width
        {
            set
            {
                if (Validate(value,nameof(Width)))
                {
                    this.width = value;
                }
            }
            get { return this.width; }
        }

        private double height;
        private double Height
        {
            set
            {
                if (Validate(value, nameof(Height)))
                {
                    this.height = value;
                }
            }
            get { return this.height; }
        }

        private double SurfaceArea;
        private double LateralSurfaceArea;
        private double Volume;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public void FindSurfaceArea()
        {
            this.SurfaceArea = 2 * this.length * this.width+ 2 * this.length* this.height+
                               2 * this.width * this.height;
        }

        public void FindLateralArea()
        {
            this.LateralSurfaceArea = 2 * this.length * this.height + 2 * this.width* this.height;
        }

        public void FindVolume()
        {
            this.Volume = this.length * this.height * this.width;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea:f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea:f2}");
            sb.AppendLine($"Volume - {this.Volume:f2}");
            return sb.ToString().TrimEnd();
        }

        private bool Validate(double side, string parameter)
        {
            if (side < 0)
            {
                Console.WriteLine($"{parameter} cannot be zero or negative.");
                Environment.Exit(0);
            }

            return true;
            
        }
    }
}

