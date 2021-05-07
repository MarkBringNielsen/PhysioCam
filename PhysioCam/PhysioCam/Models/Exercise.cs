using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PhysioCam.Data
{
    public class Exercise
    {

        public Exercise() { }

        public Exercise(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        //public List<Image> Images { get; set; }

        public string Description { get; set; }



    }
}
