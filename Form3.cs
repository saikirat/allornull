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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);

             

            foreach (CultureInfo cul in cinfo)

            {
                textBox1.Text += cul.DisplayName + " ## " + cul.Name + " ## " + cul.DateTimeFormat.LongDatePattern + " ## " + cul.DateTimeFormat.LongTimePattern + " ## " + cul.DateTimeFormat.FullDateTimePattern + " ## " + cul.DateTimeFormat.ShortDatePattern + " ## " + cul.DateTimeFormat.ShortTimePattern + " ## " + cul.NumberFormat.CurrencySymbol + " ## " + cul.NumberFormat.CurrencyDecimalSeparator + " ## " + cul.NumberFormat.NumberDecimalSeparator + " @@";

            }

             
        }
    }
}
