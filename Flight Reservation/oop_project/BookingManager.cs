using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OOP_Console
{
    public class BookingManager
    {
        private Booking[] bookingList;
        private int numBookings;
        private int maxBookings;

        public BookingManager(int max)
        {
            numBookings = getNumberOfBookings();
            maxBookings = max;
            bookingList = new Booking[max];
        }


        private int search(int bookingNumber)
        {
            for (int x = 0; x < numBookings; x++)
            {
                if (bookingList[x].getBookingNumber() == bookingNumber)
                {
                    return x;
                }

            }
            return -1;
        }

        public string addBooking(int customerId, int flightNumber, string bookingDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            string response;

            if(customerAlreadyBooked(customerId, flightNumber))
            {
                return "customer_already_booked";
            }

            if(getNumberOfBookingsPerFlight(flightNumber) >= getFlightCapacity(flightNumber))
            {
                return "flight_capacity_exceed";
            }
           
            try
            {
                if (numBookings < maxBookings)
                {
                    string query = "insert into bookings (bookingDate, flightNumber, customerId) values ('" + bookingDate + "','" + flightNumber + "','" + customerId + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    response = "success";
                } else
                {
                    response = "max_booking_exceed";
                }
            }
            catch (Exception exception)
            {
                throw exception;
            } finally
            {
                conn.Close();
            }
            return response;
        }

        private int getNumberOfBookingsPerFlight(int flightNumber)
        {
            int numOfBookingsPerFlight;
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string query = "select count(*) from bookings where flightNumber = '" + flightNumber + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                numOfBookingsPerFlight = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }
            return numOfBookingsPerFlight;
        }

        private int getFlightCapacity(int flightNumber)
        {               
            int capacity;
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string query = "select flightCapacity from flights where flightNumber = '" + flightNumber + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                capacity= Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }
            return capacity;
        }

        private bool customerAlreadyBooked(int customerId, int flightNumber)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            int numberOfRecordsWithGivenData;

            try
            {
                string query = "select count(*) from bookings where customerId = '" + customerId + "' and flightNumber = '" + flightNumber + "'";
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

        public string deleteBooking(int bookingNumber)
        {
            string response;
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string query = "delete from bookings where bookingNumber = '" + bookingNumber + "'";
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

        public string viewBooking(int bookingNumber)
        {
            int loc = search(bookingNumber);
            if (loc != -1)
            {
                return bookingList[loc].ToString();
            }
            return "No booking were found with the given id.";
        }

        public string viewAllBookings()
        {
            string s = "---BOOKING LIST---\n";
            for (int i = 0; i < numBookings; i++)
            {
                s += bookingList[i].ToString() + "\n";
            }
            return s;
        }

        private int getNumberOfBookings()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {   
                int numOfBookings;
                string query = "select count(*) from bookings";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                numOfBookings = Convert.ToInt32(cmd.ExecuteScalar());
                return numOfBookings;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}