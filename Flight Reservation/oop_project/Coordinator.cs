using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace OOP_Console
{
    public class Coordinator
    {
        private BookingManager bm;
        private CustomerManager cm;
        private FlightManager fm;

        public Coordinator(BookingManager bm, CustomerManager cm, FlightManager fm)
        {
            this.bm = bm;
            this.cm = cm;
            this.fm = fm;
        }

        public bool addFlight(string flightOrigin, string flightDestination, int flightCapacity)
        {
            return fm.addFlight(flightOrigin, flightDestination, flightCapacity);
        }

        public int getCustomerIndex(int cusId)
        {
            return cm.getCustomerIndex(cusId);
        }

        public Customer[] getCustomers()
        {
            return cm.getCustomers();
        }

        public string deleteFlight(int flightNumber)
        {
            return fm.deleteFlight(flightNumber);
        }

        public int getFlightIndex(int flightNumber)
        {
            return fm.getFlightIndex(flightNumber);
        }

         public string viewFlight(int flightNumber)
        {
            return fm.viewFlight(flightNumber);
        }

        public DataTable getFlights()
        {
            return fm.getFlights();
        }

        public string viewAllFlights()
        {
            return fm.viewAllFlights();
        }

        // ----------------------------------------------------------------------------------------------------

        public string addBooking(int customerId, int flightNumber, string bookingDate)
        {
            return bm.addBooking(customerId, flightNumber, bookingDate);
        }

        public string deleteBooking(int bookingNumber)
        {
            return bm.deleteBooking(bookingNumber);
        }

        public string viewBooking(int bookingNumber)
        {
            return bm.viewBooking(bookingNumber);
        }

        public string viewAllBookings()
        {
            return bm.viewAllBookings();
        }

        // ----------------------------------------------------------------------------------------------------

        public string addCustomer(string customerFirstName, string CustomerLastName, string customerPhoneNumber)
        {
            return cm.addCustomer(customerFirstName, CustomerLastName, customerPhoneNumber);
        }

        public string deleteCustomer(int cusId)
        {
            return cm.deleteCustomer(cusId);
        }

        public string viewCustomer(int cusId)
        {
            return cm.viewCustomer(cusId);
        }

        public string viewAllCustomers()
        {
            return cm.viewAllCustomers();
        }


    }
}