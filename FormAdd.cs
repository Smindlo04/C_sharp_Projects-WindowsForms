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

namespace _41566599_SU2_Act6
{
    public partial class FormAdd : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Mpumi\Desktop\Advanced C#(212)\41566599_SU2_Act6\DBSThreatre.mdf;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet dataset;
        public FormAdd()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand sqlcommand = new SqlCommand($"INSERT INTO TableThreatres VALUES('{txtTNumber.Text}', '{txtTotalSeats.Text}', '{txtOpenSeats.Text}', '{txtTSize.Text}')", con);
                adapter = new SqlDataAdapter();

                adapter.InsertCommand = sqlcommand;
                adapter.InsertCommand.ExecuteNonQuery();

                con.Close();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
