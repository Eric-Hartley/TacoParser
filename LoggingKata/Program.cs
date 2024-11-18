using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Runtime.ExceptionServices;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            

            logger.LogInfo("Log initialized");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            var locations = lines.Select(parser.Parse).ToArray();

  
            
            ITrackable locationA = null;
            ITrackable locationB = null;

          
            double currentDistance = 0;
            
            foreach (var locA in locations)
            {
                GeoCoordinate corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                foreach (var locB in locations)
                {
                    GeoCoordinate corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    double distanceBetween = corB.GetDistanceTo(corA);
                    if (distanceBetween > currentDistance)
                    {
                        currentDistance = distanceBetween;
                        locationA = locA;
                        locationB = locB;
                    }
                }
            }
           
            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
    

            Console.WriteLine($"The two Taco Bell locations furthest away are:");
            Console.WriteLine($"Location 1: {locationA.Name}, {locationA.Location.Latitude}, {locationA.Location.Longitude}");
            Console.WriteLine($"Location 2: {locationB.Name}, {locationB.Location.Latitude}, {locationB.Location.Longitude}");

        }
    }
}
