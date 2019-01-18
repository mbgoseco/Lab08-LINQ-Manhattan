using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Manhattan.Classes
{
    public class FeatureCollection
    {

        public class Rootobject
        {
            public string Type { get; set; }
            public Features[] Features { get; set; }
        }

        public class Features
        {
            public string Type { get; set; }
            public Geometry Geometry { get; set; }
            public Properties Properties { get; set; }
        }

        public class Geometry
        {
            public string Type { get; set; }
            public float[] Coordinates { get; set; }
        }

        public class Properties
        {
            public string Zip { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Address { get; set; }
            public string Borough { get; set; }
            public string Neighborhood { get; set; }
            public string County { get; set; }
        }

    }
}
