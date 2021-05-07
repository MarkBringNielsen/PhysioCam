using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PhysioCam.Data
{
    class Exercise
    {

        public string name { get; set; }
        public List<Image> Images { get; set; }


    }
}
