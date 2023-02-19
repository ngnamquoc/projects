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
using System.Configuration;

using System.Data.SqlClient;

namespace oop_project
{
    public partial class ViewAllCustomersForm : Form
    {
        private static int maxCustomers = 100;
        private static int maxFlights = 100;
        private static int maxBookings = 100;
        private static int pageIndex = 0;
        private Coordinator coord = new Coordinator(new BookingManager(maxBookings), new CustomerManager(maxCustomers), new FlightManager(maxFlights));

        public ViewAllCustomersForm()
        {
            InitializeComponent();
            



        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fillData()
        {
            // TODO: This line of code loads data into the 'flight_dbDataSet.customers' table. You can move, or remove it, as needed.
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection db_con = new SqlConnection(connectionString);
            db_con.Open();

            SqlCommand db_com = db_con.CreateCommand();
            db_com.CommandType = CommandType.Text;
            db_com.CommandText = "select * from customers";
            db_com.ExecuteNonQuery();

            DataTable dTable = new DataTable();
            SqlDataAdapter dAdapter = new SqlDataAdapter(db_com);
            dAdapter.Fill(dTable);
            customerList.DataSource = dTable;
            db_con.Close();
        }

        private void ViewAllCustomersForm_Load(object sender, EventArgs e)
        {
            fillData();
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDelete";
            deleteButton.HeaderText = "Action";
            deleteButton.Text = "Delete Button";
            deleteButton.UseColumnTextForButtonValue = true;
            customerList.Columns.Add(deleteButton);
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 mainForm = new Form1();
            mainForm.Show();
        }

        private void customerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedCustomerId;
            //if click is on new row or header row
            if (e.RowIndex == customerList.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == customerList.Columns["btnDelete"].Index)
            {
                selectedCustomerId = Int32.Parse(customerList.Rows[e.RowIndex].Cells[0].Value.ToString());
                string managerResponse;

                if((managerResponse = coord.deleteCustomer(selectedCustomerId)) == "success") {
                    MessageBox.Show("Customer Successfully Deleted!");
                } else if(managerResponse == "customer_has_booking")
                {
                    MessageBox.Show("Customer Has Bookings. Cannot be deleted");
                } else
                {
                    MessageBox.Show(managerResponse);
                }

                this.Close();
                ViewAllCustomersForm vacf = new ViewAllCustomersForm();
                vacf.Show();
            }
        }
    }
}
