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

namespace TheatreManagement
{ 
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Mpumi\Desktop\Advanced C#(212)\41566599_SU2_Act6\DBSThreatre.mdf;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet dataset;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Mpumi\Desktop\Advanced C#(212)\41566599_SU2_Act6\DBSThreatre.mdf;Integrated Security=True";
                con = new SqlConnection(conString);
                MessageBox.Show("Database connection successful !!!");

                cbDelete.Items.Add(120);
                cbDelete.Items.Add(148);
                cbDelete.Items.Add(453);
                cbDelete.Items.Add(541);
                cbDelete.Items.Add(1079);
                cbDelete.Items.Add(1458);
                cbDelete.Items.Add(2513);
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand(@"SELECT * FROM TableThreatres", con);
                adapter = new SqlDataAdapter();
                dataset = new DataSet();

                adapter.SelectCommand = sqlcommand;
                adapter.Fill(dataset, "TableThreatres");

                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "TableThreatres";

                con.Close();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnSeats50_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand(@"SELECT * FROM TableThreatres WHERE OpenSeats < 50", con);
                adapter = new SqlDataAdapter();
                dataset = new DataSet();

                adapter.SelectCommand = sqlcommand;
                adapter.Fill(dataset, "TableThreatres");

                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "TableThreatres";

                con.Close();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnSeats120_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand(@"SELECT * FROM TableThreatres WHERE TotalSeats >= 120, TotalSeats <= 260", con);
                adapter = new SqlDataAdapter();
                dataset = new DataSet();

                adapter.SelectCommand = sqlcommand;
                adapter.Fill(dataset, "TableThreatres");

                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "TableThreatres";

                con.Close();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            FormAdd child = new FormAdd();
            child.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand($"DELETE FROM TableThreatres WHERE ThreatreNumber = '{int.Parse(cbDelete.SelectedItem.ToString())}'", con);
                adapter = new SqlDataAdapter();

                adapter.DeleteCommand = sqlcommand;
                adapter.DeleteCommand.ExecuteNonQuery();

                con.Close();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        
    }
}
