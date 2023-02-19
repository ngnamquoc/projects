using OOP_Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;

namespace oop_project
{
    public partial class AddBookingForm : Form
    {
        private static int maxCustomers = 100;
        private static int maxFlights = 100;
        private static int maxBookings = 100;
        private static int pageIndex = 0;
        private Coordinator coord = new Coordinator(new BookingManager(maxBookings), new CustomerManager(maxCustomers), new FlightManager(maxFlights));
        public AddBookingForm()
        {
            InitializeComponent();
        }

        public static bool validateInput(string inputValue, string regex)
        {
            return Regex.Match(inputValue, regex).Success;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bookingDate = txtDate.Text;

            while (!validateInput(bookingDate, @"^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$"))
            {
                MessageBox.Show("Please enter date in the correct format (MM/DD/YYYY)");
                return;
            }

            // (flight_combo.SelectedItem as MyComboBoxItem).Text to access combo value (which is the flight number of the selected flight)
            // We gather the flight number and customer Id from the selected items
            int flightNumber = Int32.Parse((flight_combo.SelectedItem as MyComboBoxItem).Text);
            int customerId = Int32.Parse((customer_combo.SelectedItem as MyComboBoxItem).Text);

            // managerResponse is going to store the create booking response from the manager class
            string managerResponse;

            if ((managerResponse = coord.addBooking(customerId, flightNumber, bookingDate)) == "success")
            {

                MessageBox.Show("Booking successfully added!");
                this.Hide();
                ViewAllBookingsForm vabf = new ViewAllBookingsForm();
                vabf.Show();
            }
            else if (managerResponse == "max_booking_exceed")
            {
                MessageBox.Show("Max booking limit exceeded!");
            }
            else if (managerResponse == "customer_already_booked")
            {
                MessageBox.Show("This customer is already on this flight");
            } else if (managerResponse == "flight_capacity_exceed")
            {
                MessageBox.Show("This Flight has no more capacity!");
            }
            else
            {
                MessageBox.Show("Unknown Error");
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 mainForm = new Form1();
            mainForm.Show();

        }

        private void AddBookingForm_Load(object sender, EventArgs e)
        {
            bind_flights_combo();
            bind_customers_combo();
        }

        private void bind_flights_combo()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from flights", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr.ToString());
                    MyComboBoxItem item = new MyComboBoxItem(dr["flightOrigin"].ToString() + " -----> " + dr["flightDestination"].ToString(), dr["flightNumber"].ToString());
                    flight_combo.Items.Add(item);
                    flight_combo.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {

                throw exception; 
            }
        }

        private void bind_customers_combo()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from customers", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr.ToString());
                    MyComboBoxItem item = new MyComboBoxItem(dr["customerFirstName"].ToString() + " " + dr["customerLastName"].ToString(), dr["id"].ToString());
                    customer_combo.Items.Add(item);
                    customer_combo.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }
    }
}
