using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Console
{
    public class Customer
    {
        private int customerId;
        private string customerFirstName;
        private string CustomerLastName;
        private string customerPhoneNumber;
        private int customerBookingNumber; // The number of bookings that user has made 
        public Customer(int customerId, string customerFirstName, string CustomerLastName, string customerPhoneNumber, int customerBookingNumber)
        {
            this.customerId = customerId;
            this.customerFirstName = customerFirstName;
            this.CustomerLastName = CustomerLastName;
            this.customerPhoneNumber = customerPhoneNumber;
            this.customerBookingNumber = customerBookingNumber;

        }
        public int getCustomerId()
        {
            return customerId;
        }
        public string getCustomerFirstName()
        {
            return customerFirstName;
        }
        public string getCustomerLastName()
        {
            return CustomerLastName;
        }
        public string getCustomerPhoneNumber()
        {
            return customerPhoneNumber;
        }
        public int getCustomerBookingNumber()
        {
            return customerBookingNumber;
        }
        public override string ToString()
        {
            string s = "customer Id: " + customerId + "\n";
            s += "customer first name: " + customerFirstName + "\n";
            s += "customer last name: " + CustomerLastName + "\n";
            s += "customer phone number: " + customerPhoneNumber + "\n";
            s += "customer booking number: " + customerBookingNumber + "\n";
            return s;
        }
        
    }
}