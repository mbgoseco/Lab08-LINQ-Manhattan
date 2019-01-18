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
            string path = @"C:\Users\MBG\codefellows\401\Lab08-LINQ-Manhattan\LINQ_Manhattan\data.json";

            OutputRaw(path);
            OutputBlankless(path);
            OutputNoDupes(path);
            OutputBlanklessAndDupeless(path);
            OutputBlanklessLambda(path); 
        }

        public static void OutputRaw(string path)
        {
            // Output all neighborhood names in the data set
            using (StreamReader reader = File.OpenText(path))
            {
                var data = "";
                data = reader.ReadToEnd();

                FeatureCollection root = JsonConvert.DeserializeObject<FeatureCollection>(data);

                var hoodData = from n in root.Features
                               select n.Properties.Neighborhood;

                Console.WriteLine("Neighborhood data (raw)");
                Console.WriteLine("=======================");
                foreach (string hood in hoodData)
                {
                    Console.WriteLine(hood);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public static void OutputBlankless(string path)
        {
            // Output neighborhood names that aren't blank
            using (StreamReader reader = File.OpenText(path))
            {
                var data = "";
                data = reader.ReadToEnd();

                FeatureCollection root = JsonConvert.DeserializeObject<FeatureCollection>(data);

                var hoodData = from n in root.Features
                               where n.Properties.Neighborhood != ""
                               select n.Properties.Neighborhood;

                Console.WriteLine("Neighborhood data (filtered blanks)");
                Console.WriteLine("=======================");
                foreach (string hood in hoodData)
                {
                    Console.WriteLine(hood);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public static void OutputNoDupes(string path)
        {
            // Output neighborhood names whithout duplicates
            using (StreamReader reader = File.OpenText(path))
            {
                var data = "";
                data = reader.ReadToEnd();

                FeatureCollection root = JsonConvert.DeserializeObject<FeatureCollection>(data);

                var hoodData = from n in root.Features
                               group n by n.Properties.Neighborhood into hoods
                               select hoods.Key;

                Console.WriteLine("Neighborhood data (filtered duplicates)");
                Console.WriteLine("=======================");
                foreach (string hood in hoodData)
                {
                    Console.WriteLine(hood);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public static void OutputBlanklessAndDupeless(string path)
        {
            // Output neighborhood names whithout blanks AND duplicates
            using (StreamReader reader = File.OpenText(path))
            {
                var data = "";
                data = reader.ReadToEnd();

                FeatureCollection root = JsonConvert.DeserializeObject<FeatureCollection>(data);

                var hoodData = from n in root.Features
                               where n.Properties.Neighborhood != ""
                               group n by n.Properties.Neighborhood into hoods
                               select hoods.Key;

                Console.WriteLine("Neighborhood data (filtered blanks and duplicates)");
                Console.WriteLine("=======================");
                foreach (string hood in hoodData)
                {
                    Console.WriteLine(hood);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public static void OutputBlanklessLambda(string path)
        {
            // Output neighborhood names whithout blanks using lambda expressions
            using (StreamReader reader = File.OpenText(path))
            {
                var data = "";
                data = reader.ReadToEnd();

                FeatureCollection root = JsonConvert.DeserializeObject<FeatureCollection>(data);

                var hoodData = root.Features.Where(n => n.Properties.Neighborhood != "");

                Console.WriteLine("Neighborhood data (lambda)");
                Console.WriteLine("=======================");
                foreach (Features hood in hoodData)
                {
                    Console.WriteLine(hood.Properties.Neighborhood);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
