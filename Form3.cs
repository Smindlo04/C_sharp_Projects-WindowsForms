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

namespace RestaurantManagement
{
    public partial class Form3 : Form
    {
        SqlConnection con;//Declarations
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataSet dataset;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbsFoodDataSet.TblFood' table. You can move, or remove it, as needed.
            this.tblFoodTableAdapter.Fill(this.dbsFoodDataSet.TblFood);
            // TODO: This line of code loads data into the 'databaseDrinksDataSet.TableDrinks' table. You can move, or remove it, as needed.
            this.tableDrinksTableAdapter.Fill(this.databaseDrinksDataSet.TableDrinks);
            try
            {
                //Sets up a connection
                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseDrinks.mdf;Integrated Security=True");
                con.Open();//Open connection
                SqlCommand sqlcommand = new SqlCommand(@"SELECT * FROM TableDrinks", con);
                adapter = new SqlDataAdapter();
                dataset = new DataSet();

                adapter.SelectCommand = sqlcommand;
                adapter.Fill(dataset, "TableDrinks");//Displaying data into a dataGridView

                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "TableDrinks";

                con.Close();//Close connection
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            try
            {
                //Setting up a connection
                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DbsFood.mdf;Integrated Security=True");
                con.Open();//Opens conection
                SqlCommand sqlcommand = new SqlCommand(@"SELECT * FROM TblFood", con);
                adapter = new SqlDataAdapter();
                dataset = new DataSet();

                adapter.SelectCommand = sqlcommand;
                adapter.Fill(dataset, "TblFood");

                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "TblFood";//Fills the dataGridview

                con.Close();//Close connection
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            lbOutput.Items.Add("ID" + "\tName" + "\tType" + "\tPrice");
        }

        private void btnAddDrinks_Click(object sender, EventArgs e)
        {
            int ID;

            ID = int.Parse(txtDrinks.Text);
            
            try
            {
                //Connection set up
                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseDrinks.mdf;Integrated Security=True");
                con.Open();//open Connection
                SqlCommand sqlcommand = new SqlCommand($"SELECT * FROM TableDrinks WHERE ID = '{ID}'", con);
                reader = sqlcommand.ExecuteReader();

                while (reader.Read())//Read data
                {
                    lbOutput.Items.Add(reader.GetValue(0) + "\t" + reader.GetValue(1) + "\t" + reader.GetValue(2) + "\t" + reader.GetValue(3));
                }
                
                con.Close();//Close connection
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            txtDrinks.Text = "";
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            int Food_ID; 

            Food_ID = int.Parse(txtFood.Text);
            try
            {
                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DbsFood.mdf;Integrated Security=True");
                con.Open();//Open connection
                SqlCommand sqlcommand = new SqlCommand($"SELECT * FROM TblFood WHERE Food_ID = '{Food_ID}'", con);
                reader = sqlcommand.ExecuteReader();
                double FoodTotal = 0;
                 
                while (reader.Read())//Read data
                {
                    lbOutput.Items.Add(reader.GetValue(0) + "\t" + reader.GetValue(1) + "\t" + reader.GetValue(2) + "\t" + reader.GetValue(3));
                }
                
                
                con.Close();//Close connection
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            txtFood.Text = "";
        }

        private void lbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbOutput.SelectedIndex != -1)
            {
                lbOutput.Items.Remove(lbOutput.SelectedItem);//Deletes selected Items
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 child = new Form4(lbOutput);
            child.Show();//Shows a new form
        }
    }
}
