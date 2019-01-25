using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveloperHelper
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime(2011, 2, 19);
            textBox3.Text = String.Format(date.ToString(textBox1.Text),Int32.Parse(textBox2.Text));
            textBox6.Text = (date.ToString(textBox1.Text) == date.ToString(textBox4.Text)) ? String.Format(date.ToString(textBox4.Text), Int32.Parse(textBox2.Text)+1) : String.Format(date.ToString(textBox4.Text), 1);
           
        }
    }
}
