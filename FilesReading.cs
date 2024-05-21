using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FilesReading_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {             
                //SaveDialog
                if(saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter outFile;
                    outFile = File.AppendText(saveDialog.FileName + ".txt");

                    outFile.WriteLine(txtName.Text);

                    MessageBox.Show("Data saved to text file.");

                    outFile.Close();
                }
                else
                {
                    MessageBox.Show("No file selected !");
                }
            }
            catch(IOException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveDialog
                if(openDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamReader inFile;
                    inFile = File.OpenText(openDialog.FileName);

                    while (!inFile.EndOfStream)
                    {
                        listOutput.Items.Add(inFile.ReadLine());
                    }
                    inFile.Close();
                }
                else
                {
                    MessageBox.Show("No file selected !!");
                }
            }
            catch(IOException exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
