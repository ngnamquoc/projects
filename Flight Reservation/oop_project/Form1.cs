/*
 *
 *Mohammadali Talaie 
- Student ID 101400831
  
  Jaqueline Duarte de Oliveira Medeiros
- Student ID 101400994
  
  Nam Quoc Nguyen 
- Student ID: 101396830
  
  Mahshad Elanlout
- Student ID: 101400600

 */

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

namespace oop_project
{
    public partial class Form1 : Form
    {
        private static int maxCustomers = 100;
        private static int maxFlights = 100;
        private static int maxBookings = 100;
        private static int pageIndex = 0;
        private Coordinator coord = new Coordinator(new BookingManager(maxBookings), new CustomerManager(maxCustomers), new FlightManager(maxFlights));

        public Form1()
        {
            InitializeComponent();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCustomerForm acf = new AddCustomerForm();
            acf.Show();
           
        }

        private void viewAllCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAllCustomersForm acf = new ViewAllCustomersForm();
            acf.Show();
        }

        private void viewAllBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAllBookingsForm acf = new ViewAllBookingsForm();
            acf.Show();
        }

        private void addBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddBookingForm acf = new AddBookingForm();
            acf.Show();
        }

        private void viewAllFlightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAllFlightsForm acf = new ViewAllFlightsForm();
            acf.Show();
        }

        private void addFlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddFlightForm acf = new AddFlightForm();
            acf.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
