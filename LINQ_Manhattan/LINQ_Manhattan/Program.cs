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

            BeginQuery(path);
        }

        /// <summary>
        /// Begins the query chain to gather neighborhoods from the data.json file, then remove blank listings, then remove duplicates.
        /// </summary>
        /// <param name="path">File path of data.json</param>
        public static void BeginQuery(string path)
        {
            // Output all neighborhood names in the data set
            using (StreamReader reader = File.OpenText(path))
            {
                var data = "";
                data = reader.ReadToEnd();

                FeatureCollection root = JsonConvert.DeserializeObject<FeatureCollection>(data);

                var queryOne = from n in root.Features
                               select n.Properties.Neighborhood;

                Console.WriteLine("Neighborhood data (raw)");
                Console.WriteLine("=======================");
                foreach (string hood in queryOne)
                {
                    Console.WriteLine(hood);
                }
                Console.WriteLine();
                Console.WriteLine();


                // Output neighborhood names that aren't blank
                var queryTwo = from b in queryOne
                               where b != ""
                               select b;

                Console.WriteLine("Neighborhood data (filtered blanks)");
                Console.WriteLine("=======================");
                foreach (string hood in queryTwo)
                {
                    Console.WriteLine(hood);
                }
                Console.WriteLine();
                Console.WriteLine();


                // Output neighborhood names whithout duplicates
                var queryThree = queryTwo.Distinct();

                Console.WriteLine("Neighborhood data (filtered duplicates)");
                Console.WriteLine("=======================");
                foreach (string hood in queryThree)
                {
                    Console.WriteLine(hood);
                }
                Console.WriteLine();
                Console.WriteLine();


                // Output neighborhood names whithout blanks AND duplicates in one query
                var queryFour = from n in root.Features
                               where n.Properties.Neighborhood != ""
                               group n by n.Properties.Neighborhood into hoods
                               select hoods.Key;

                Console.WriteLine("Neighborhood data (filtered blanks and duplicates)");
                Console.WriteLine("=======================");
                foreach (string hood in queryFour)
                {
                    Console.WriteLine(hood);
                }
                Console.WriteLine();
                Console.WriteLine();


                // Output neighborhood names whithout blanks using lambda expressions
                var queryFive = queryOne.Where(x => x != "");

                Console.WriteLine("Neighborhood data (lambda)");
                Console.WriteLine("=======================");
                foreach (string hood in queryFive)
                {
                    Console.WriteLine(hood);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
