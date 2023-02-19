using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace OOP_Console
{
    public class FlightManager
    {
        private Flight[] flightList;
        private int numFlights;
        private int maxFlights = 100;
        private int lastUsedFlightNumber = 0;

        public FlightManager(int max)
        {
            numFlights = getNumberOfFlights();
            maxFlights = max;
            flightList = new Flight[max];
        }


        private int getNumberOfFlights()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try {
                int flightNumber;
                
                string query = "select count(*) from flights";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                flightNumber = Convert.ToInt32(cmd.ExecuteScalar());
                return flightNumber;
            }
            catch (Exception exception) {
                throw exception;
            }
            finally
            {
                conn.Close();
            }
        }

        private int search(int flightNumber)
        {
            for (int x = 0; x < numFlights; x++)
            {
                if (flightList[x].getFlightNumber() == flightNumber)
                {
                    return x;
                }

            }
            return -1;
        }

        public bool addFlight(string flightOrigin, string flightDestination, int flightCapacity)
        {
            bool success;
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);


            try { 
                string query = "insert into flights (flightOrigin, flightDestination, flightCapacity) values ('" + flightOrigin + "','" + flightDestination + "','" + flightCapacity + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                success = true ;
            }
            catch (Exception exception)
            {
                success = false;
                throw exception;
                
            } finally
            {
                conn.Close();
            }
            return success;
        }

        private int getCustomersNumber(int flightNumber) // this method will return the number of customers who are boarding this instance of flight
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            int customerNumber;
            try {
                string query = "select count(*) from bookings where flightNumber = '" + flightNumber + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                customerNumber = Convert.ToInt32(cmd.ExecuteScalar());
                return customerNumber;
            }
            catch (Exception exception) {
                throw exception;
            }
            finally
            {
                conn.Close();
            }
        }

        public string deleteFlight(int flightNumber)
        {
            string response;
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            if(getCustomersNumber(flightNumber) > 0) // if there already is a customer who has booked this flight we should't allow delete flight
            {
                return "customer_on_flight"; 
            }
            
            try
            {
                string query = "delete from flights where flightNumber = '" + flightNumber + "'";
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

        public DataTable getFlights()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection db_con = new SqlConnection(connectionString);
            DataTable dTable = new DataTable();
            try
            {
                db_con.Open();
                SqlCommand db_com = db_con.CreateCommand();
                db_com.CommandType = CommandType.Text;
                db_com.CommandText = "select * from flights";
                db_com.ExecuteNonQuery();
                
                SqlDataAdapter dAdapter = new SqlDataAdapter(db_com);
                dAdapter.Fill(dTable);
            }
            catch (Exception exception)
            {
                throw exception;
            } finally
            {
                db_con.Close();
            }

            return dTable;

        }

        public int getFlightIndex(int flightNumber)
        {
            
                int loc = search(flightNumber);
                if (loc != -1)
                {
                    return loc;
                }
                return -1;

        }

        public string viewFlight(int flightNumber)
        {
            int loc = search(flightNumber);
            if (loc != -1)
            {
                return flightList[loc].ToString();
            }
            return "Flight not found...";
        }

        public string viewAllFlights()
        {
            string s = "---FLIGHT LIST---\n";
            for (int i = 0; i < numFlights; i++)
            {
                s += flightList[i].ToString() + "\n";
            }
            return s;
        }
    }
}