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
    public partial class Form4 : Form
    {
        public Form4(ListBox lbOutput)
        {
            InitializeComponent();
            foreach (var item in lbOutput.Items)
            {
                listBox1.Items.Add(item);//Adds Items from a listbox
             
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Random num = new Random();
            int number = num.Next(100, 1000);//Generates a 3-digit random number
            label3.Text = "#" + number;
            
            listBox1.Items.Add("\nThe total of your order will be calculated at the till.");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
