using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using OOP_Console;

namespace oop_project
{
    public partial class ViewAllFlightsForm : Form
    {
        private static int maxCustomers = 100;
        private static int maxFlights = 100;
        private static int maxBookings = 100;
        private Coordinator coord = new Coordinator(new BookingManager(maxBookings), new CustomerManager(maxCustomers), new FlightManager(maxFlights));

        public ViewAllFlightsForm()
        {
            InitializeComponent();
            flightList.AutoGenerateColumns = true;

        }


        private void ViewAllFlights_Load(object sender, EventArgs e)
        {
            flightList.DataSource = coord.getFlights();
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDelete";
            deleteButton.HeaderText = "Action";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            flightList.Columns.Add(deleteButton);
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 mainForm = new Form1();
            mainForm.Show();
        }

        private void flightList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedFlightNumber;
            //if click is on new row or header row
            if (e.RowIndex == flightList.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == flightList.Columns["btnDelete"].Index)
            {
                selectedFlightNumber = Int32.Parse(flightList.Rows[e.RowIndex].Cells[0].Value.ToString());
                string managerResponse;
                if ((managerResponse = coord.deleteFlight(selectedFlightNumber)) == "success")
                {
                    MessageBox.Show("Flight Successfully Deleted!");
                }
                
                this.Close();
                ViewAllCustomersForm vacf = new ViewAllCustomersForm();
                vacf.Show();
            }
        }
    }
}
