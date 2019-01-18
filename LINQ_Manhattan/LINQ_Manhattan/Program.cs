using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LINQ_Manhattan.Classes;

namespace LINQ_Manhattan
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(@"C:\Users\MBG\codefellows\401\Lab08-LINQ-Manhattan\LINQ_Manhattan\data.json"))
            {
                JObject objManhattan = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                string manhattan = objManhattan.ToString();

                IEnumerable<string> neighborhoods = from FeatureCollection.Properties

                //Console.WriteLine(manhattan);
                //JObject deserializedProduct = JsonConvert.DeserializeObject<JObject>(o);
            }
        }
    }
}
