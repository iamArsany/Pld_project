using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using com.calitha.commons;
using com.calitha.goldparser;

namespace pld_project
{
    public partial class Form1 : Form
    {
        MyParser myparser;

        public Form1()
        {
            InitializeComponent();
            myparser = new MyParser("asdf_bnf.cgt", listBox1);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implement your logic here
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                string text = richTextBox1.Text;
                // Parse the text entered in the richTextBox1
                myparser.Parse(text);
                // Display the parsed result in the listBox1
                //listBox1.Items.AddRange(result.ToArray()); // assuming result is a collection of strings
            }
            catch (Exception ex)
            {
                // Handle parsing errors
                MessageBox.Show("Parsing error: " + ex.Message);
            }
        }
    }
}
