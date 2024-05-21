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

namespace MovieDatabase
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Mpumi\Desktop\Advanced C#(212)\WindowsFormsApp1\DBSMovies.mdf;Integrated Security=True");
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataSet dataset;
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand(@"SELECT * FROM TableMovies", con);
                adapter = new SqlDataAdapter();
                dataset = new DataSet();

                adapter.SelectCommand = sqlcommand;
                adapter.Fill(dataset, "TableMovies");

                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember = "TableMovies";

                con.Close();
            }
              catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand(@"SELECT * FROM PLAYERS",con);
                reader = sqlcommand.ExecuteReader();

                while (reader.Read())
                {
                    lbOutput.Items.Add(reader.GetValue(0) + "\t" + reader.GetValue(1) + "\t" + reader.GetValue(2) + "\t" + reader.GetValue(3));
                }

                con.Close();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBSMoviesDataSet2.TableMovies' table. You can move, or remove it, as needed.
            this.tableMoviesTableAdapter2.Fill(this.dBSMoviesDataSet2.TableMovies);

            hScrollBar1.Value = 0;
            hScrollBar1.Minimum = 1990;
            hScrollBar1.Maximum = 2019;
            hScrollBar1.LargeChange = 1;
            hScrollBar1.SmallChange = 1;

            lblSearchByYear.Text = hScrollBar1.Value.ToString();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand($"SELECT * FROM TableMovies WHERE MovieName LIKE '%" + txtSearchName.Text + "%'",con);
                reader = sqlcommand.ExecuteReader();

                while (reader.Read())
                {
                    lbOutput.Items.Add(reader.GetValue(0) + "\t" + reader.GetValue(1) + "\t" + reader.GetValue(2) + "\t" + reader.GetValue(3));
                }

                con.Close();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            lblSearchByYear.Text = hScrollBar1.Value.ToString();
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand($"SELECT * FROM TableMovies WHERE MovieYear = '" + hScrollBar1.Value + "'", con);
                reader = sqlcommand.ExecuteReader();

                while (reader.Read())
                {
                    lbOutput.Items.Add(reader.GetValue(0) + "\t" + reader.GetValue(1) + "\t" + reader.GetValue(2) + "\t" + reader.GetValue(3));
                }

                con.Close();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void cbSearchRating_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand($"SELECT * FROM TableMovies WHERE MovieRating = '{cbSearchRating.SelectedValue}'", con);
                reader = sqlcommand.ExecuteReader();

                while (reader.Read())
                {
                    lbOutput.Items.Add(reader.GetValue(0) + "\t" + reader.GetValue(1) + "\t" + reader.GetValue(2) + "\t" + reader.GetValue(3));
                }

                con.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand($"DELETE FROM TableMovies WHERE MovieName = '{cbDelete.SelectedValue}'", con);
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            FrmInsert child = new FrmInsert();
            child.Show();
        }
    }
}
