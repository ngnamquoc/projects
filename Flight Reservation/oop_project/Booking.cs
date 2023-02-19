using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Console
{
    public class Booking
    {
        private int customerId;
        private int flightNumber;
        private string bookingDate;
        private int bookingNumber;

        public Booking(int customerId, int flightNumber, string bookingDate)
        {
            this.customerId = customerId;
            this.flightNumber = flightNumber;
            this.bookingDate = bookingDate;
        }

        public int getCustomerId()
        {
            return customerId;
        }

        public int getFlightNumber() {
            return flightNumber;
        }   

        public string getBookingDate()
        {
            return bookingDate;
        }

        public int getBookingNumber()
        {
            return bookingNumber;
        }

        public override string ToString()
        {
            string s = "Booking Date: " + bookingDate + "\n";
            s += "Booking Number: " + bookingNumber + "\n";
            s += "\nCustomer Id: \n ----------------------------- \n" + customerId.ToString() + "\n";
            s += "\nFlight Id: \n ----------------------------- \n" + flightNumber.ToString();
            return s;
        }
    }
}