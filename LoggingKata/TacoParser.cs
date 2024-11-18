﻿using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log error message and return null
                return null; 
            }

            var latitude = double.Parse(cells[0]);

           
            var longitude = double.Parse(cells[1]);

           

            string name = cells[2];

          


          
            Point point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

          
            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;
            
           

            return tacoBell;
        }
    }
}

