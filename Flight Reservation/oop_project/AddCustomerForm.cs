using OOP_Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_project
{
    public partial class AddCustomerForm : Form
    {
        private static int maxCustomers = 100;
        private static int maxFlights = 100;
        private static int maxBookings = 100;
        private static int pageIndex = 0;
        private Coordinator coord = new Coordinator(new BookingManager(maxBookings), new CustomerManager(maxCustomers), new FlightManager(maxFlights));

        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 mainForm = new Form1();
            mainForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public static bool validateInput(string inputValue, string regex)
        {
            return Regex.Match(inputValue, regex).Success;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;

            while (!validateInput(firstName, @"^[a-zA-Z].*[\s\.]*$"))
            {
                MessageBox.Show("Please enter a valid first name.");
                return;
            }

           string lastName = txtLastName.Text;

            while (!validateInput(lastName, @"^[a-zA-Z].*[\s\.]*$"))
            {
                MessageBox.Show("Please enter a valid last name.");
                return;
            }

            string phoneNumber = txtPhoneNumber.Text;

            while (!validateInput(phoneNumber, @"([0-9]{3})[-]([0-9]{3})[-]([0-9]{4})$"))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }

            string managerResponse;

            if ((managerResponse = coord.addCustomer(firstName, lastName, phoneNumber)) == "success")
            {
                MessageBox.Show("Customer successfully added!");
                this.Close();
                ViewAllCustomersForm newForm = new ViewAllCustomersForm();
                newForm.Show();
            }
            else if (managerResponse == "first_name_taken")
            {
                MessageBox.Show("This First Name Is Already Taken!");
            }
            else if (managerResponse == "last_name_taken")
            {
                MessageBox.Show("This Last Name Is Already Taken!");
            }
            else if (managerResponse == "phone_number_taken")
            {
                MessageBox.Show("This Phone Number Is Already Taken!");
            }
        }
    }
}
