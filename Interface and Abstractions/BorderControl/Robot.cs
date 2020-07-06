using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IIndividual
    {
        public string Id { get; set; }
        private string Model { get; set; }

        public Robot(string id, string model) 
        {
            this.Id = id;
            this.Model = model;
        }
    }
}
