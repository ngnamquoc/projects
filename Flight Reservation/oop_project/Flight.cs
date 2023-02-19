using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Console
{
    public class Flight
    {
        private int flightNumber;
        private string flightDestination;
        private string flightOrigin;
        private int flightCapacity;
        public Flight(string flightDestination, string flightOrigin, int flightCapacity)
        { 
            this.flightDestination = flightDestination;
            this.flightOrigin = flightOrigin;
            this.flightCapacity = flightCapacity;
        }

        public int getFlightNumber()
        {
            return flightNumber;
        }
        public string getFlightDestination()
        {
            return flightDestination;
        }
        public string getFlightOrigin()
        {
            return flightOrigin;
        }

        public override string ToString()
        {
            string s = "flight number: " + flightNumber + "\n";
            s += "flight destination: " + flightDestination + "\n";
            s += "flight origin: " + flightOrigin;

            return s;
        }
    }
}