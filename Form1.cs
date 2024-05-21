using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2(); //Instantiates and display a new form.
            child.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Closes the form.
        }
    }
}
