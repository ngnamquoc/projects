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
    public partial class ViewAllBookingsForm : Form
    {
        private static int maxCustomers = 100;
        private static int maxFlights = 100;
        private static int maxBookings = 100;
        private static int pageIndex = 0;
        private Coordinator coord = new Coordinator(new BookingManager(maxBookings), new CustomerManager(maxCustomers), new FlightManager(maxFlights));
        public ViewAllBookingsForm()
        {
            InitializeComponent();
            bookingList.AutoGenerateColumns = true;
        }

        private void ViewAllBookingsForm_Load(object sender, EventArgs e)
        {
            fillData();
            // Here We add delete button to each record in the gridView 
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDelete";
            deleteButton.HeaderText = "Action";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            bookingList.Columns.Add(deleteButton);
        }

        private void fillData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection db_con = new SqlConnection(connectionString);
            db_con.Open();

            SqlCommand db_com = db_con.CreateCommand();
            db_com.CommandType = CommandType.Text;
            db_com.CommandText = "select * from bookings";
            db_com.ExecuteNonQuery();

            DataTable dTable = new DataTable();
            SqlDataAdapter dAdapter = new SqlDataAdapter(db_com);

            dAdapter.Fill(dTable);
            bookingList.DataSource = dTable;

            db_con.Close();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 mainForm = new Form1();
            mainForm.Show();
        }

        private void bookingList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedBookingNumber;
            string managerResponse;
            //if click is on new row or header row
            if (e.RowIndex == bookingList.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == bookingList.Columns["btnDelete"].Index)
            {
                selectedBookingNumber = Int32.Parse(bookingList.Rows[e.RowIndex].Cells[0].Value.ToString());
                if ((managerResponse = coord.deleteBooking(selectedBookingNumber)) == "success")
                {
                    MessageBox.Show("Flight Successfully Deleted!");
                }
                else if (managerResponse == "customer_on_flight")
                {
                    MessageBox.Show("Customers are already on this flight");
                }

                this.Close();
                ViewAllBookingsForm vacf = new ViewAllBookingsForm();
                vacf.Show();
            }
        }
    }
}
