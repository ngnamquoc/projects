using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace OOP_Console
{
    public class CustomerManager
    {
        private Customer[] cusList;
        private int numCustomers;
        private int maxCustomers;
        private int lastUsedId = 0;
        private int lastUsedBookingNumber = 0;

        public CustomerManager(int max)
        {
            numCustomers = 0;
            maxCustomers = max;
            cusList = new Customer[max];
        }
        private int search(int cusId)
        {
            for (int x = 0; x < numCustomers; x++)
            {
                if (cusList[x].getCustomerId() == cusId)
                {
                    return x;
                }

            }
            return -1;
        }

        public string addCustomer(string customerFirstName, string CustomerLastName, string customrPhoneNumber)
        {
            string response;
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            if (customerFirstNameAlreadyExists(customerFirstName))
            {
                return "first_name_taken";
            }
            if (customerLastNameAlreadyExists(CustomerLastName))
            {
                return "last_name_taken";
            }
            if (customerPhoneNumberAlreadyExists(customrPhoneNumber))
            {
                return "phone_number_taken";
            }

            try
            {
                string query = "insert into customers (customerBookingNumber, customerFirstName, customerLastName, customerPhoneNumber) values ('" + lastUsedBookingNumber + "', '" + customerFirstName + "','" + CustomerLastName + "','" + customrPhoneNumber + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                response = "success";
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }

            return response;
        }

        public string viewCustomer(int cusId)
        {
            int loc = search(cusId);
            if (loc != -1)
            {
                return cusList[loc].ToString();
            }
            return "No Customers were found with the given Id!";
        }
        //********
        public int getCustomerIndex(int cusId)
        {
            int loc = search(cusId);
            if (loc != -1)
            {
                return loc;
            }
            return -1;
        }

        public string deleteCustomer(int cusID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            string response;

            if(customerHasBooking(cusID))
            {
                return "customer_has_booking";
            }

            try
            {
                string query = "delete from customers where id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", cusID);
                conn.Open();
                cmd.ExecuteNonQuery();
                return "success";
            }
            catch (Exception exception)
            { 
                throw exception;
            } finally
            {
                conn.Close();
            }

            return "unknown_error_occured";
        }

        private bool customerHasBooking(int customerId) {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            int numberOfRecordsWithGivenData;

            try
            {
                string query = "select count(*) from bookings where customerId = '" + customerId + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                numberOfRecordsWithGivenData = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }


            if (numberOfRecordsWithGivenData > 0)
            {
                return true;
            }


            return false;
        }

        private bool customerFirstNameAlreadyExists(string firstName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            int numberOfRecordsWithGivenData;

            try
            {
                string query = "select count(*) from customers where customerFirstName = '" + firstName + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                numberOfRecordsWithGivenData = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }

            if(numberOfRecordsWithGivenData > 0)
            {
                return true;
            }

            return false;
        }

        private bool customerPhoneNumberAlreadyExists(string phoneNumber)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            int numberOfRecordsWithGivenData;

            try
            {
                string query = "select count(*) from customers where customerPhoneNumber = '" + phoneNumber + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                numberOfRecordsWithGivenData = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }

            if (numberOfRecordsWithGivenData > 0)
            {
                return true;
            }

            return false;
        }

        private bool customerLastNameAlreadyExists(string lastName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            int numberOfRecordsWithGivenData;

            try
            {
                string query = "select count(*) from customers where customerLastName = '" + lastName + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                numberOfRecordsWithGivenData = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }

            if (numberOfRecordsWithGivenData > 0)
            {
                return true;
            }

            return false;
        }

        public Customer[] getCustomers()
        {
            return cusList;
        }
        public string viewAllCustomers()
        {
            string s = "---CUSTOMERS LIST---\n";
            for (int i = 0; i < numCustomers; i++)
            {
                s += cusList[i].ToString() + "\n";
            }
            return s;
        }

    }
}