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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//Exits from the program
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 child = new Form3();
            child.Show();//Displays a new form.
        }
    }
}
