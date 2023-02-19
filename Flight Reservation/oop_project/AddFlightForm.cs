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
using OOP_Console;

namespace oop_project
{
    public partial class AddFlightForm : Form
    {
        private static int maxCustomers = 100;
        private static int maxFlights = 100;
        private static int maxBookings = 100;
        private static int pageIndex = 0;
        private Coordinator coord = new Coordinator(new BookingManager(maxBookings), new CustomerManager(maxCustomers), new FlightManager(maxFlights));
        public AddFlightForm()
        {
            InitializeComponent();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 mainForm = new Form1();
            mainForm.Show();
        }

        public static bool validateInput(string inputValue, string regex)
        {
            return Regex.Match(inputValue, regex).Success;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string flightOrigin = txtFlightOrigin.Text;

            while (!validateInput(flightOrigin, @"^[a-zA-Z].*[\s\.]*$"))
            {
                MessageBox.Show("Please enter a valid number for flight origin.");
                return;
            }

            string flightDestination = txtFlightDestination.Text;

            while (!validateInput(flightDestination, @"^[a-zA-Z].*[\s\.]*$"))
            {
                MessageBox.Show("Please enter a valid integer for id.");
                return;
            }

            int flightCapacity;

            if (!Int32.TryParse(txtFlightCapacity.Text, out flightCapacity))
            {
                MessageBox.Show("Please enter a valid integer for flight capacity.");
                return;
            }

            if (coord.addFlight(flightOrigin, flightDestination, flightCapacity))
            {
                
                MessageBox.Show("Flight successfully added!");
                this.Hide();
                ViewAllFlightsForm vaff = new ViewAllFlightsForm();
                vaff.Show();
            }
            else
            {
                Console.WriteLine("A problem occurred");
            }
        }

        private void AddFlightForm_Load(object sender, EventArgs e)
        {

        }
    }
}
