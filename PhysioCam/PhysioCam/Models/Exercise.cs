using System.Collections.Generic;

namespace PhysioCam.Models
{
    public class Exercise
    {
        public IList<string> Images { get; set; }

        public string Description { get; set; }
        
        public string Name { get; set; }
    }
}