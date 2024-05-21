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

namespace WindowsFormsApp1
{
    public partial class FrmInsert : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Mpumi\Desktop\Advanced C#(212)\WindowsFormsApp1\DBSMovies.mdf;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet dataset;
        public FrmInsert()
        {
            InitializeComponent();
        }

        private void btnInsertMovie_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMovieRating, "Invalid Movie Rating !!!");
            errorProvider1.SetError(txtMovieYear, "Invalid Movie Year !!!");

            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand($"INSERT INTO TableMovies VALUES('{txtMovieName.Text}', '{txtMovieDirector.Text}', '{txtMovieRating.Text}', '{txtMovieYear.Text}'", con);
                adapter = new SqlDataAdapter();

                adapter.InsertCommand = sqlcommand;
                adapter.InsertCommand.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data inserted successfully into the table !!");
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
