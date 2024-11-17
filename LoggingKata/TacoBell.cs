using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LoggingKata
{
    internal class TacoBell : ITrackable
    {

        public TacoBell()
        {

        }
        public string Name { get; set; }
        public Point Location { get; set; }
    }

}
